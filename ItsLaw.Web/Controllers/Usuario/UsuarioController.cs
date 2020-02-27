using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Web.ViewModels;
using ItsLaw.Funcoes;
using ItsLaw.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;



namespace ItsLaw.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario           _Usuario           = new UsuarioService();
        private readonly IUsuarioPerfil     _Perfil            = new UsuarioPerfilService();
        private readonly IEmpresa           _Empresa           = new EmpresaService();
        private readonly IUsuario           _UsuarioID         = new UsuarioService();
        private readonly ServicoEnvioEmail  _ServicoEnvioEmail = new ServicoEnvioEmail();
        protected ItsLawContext             _contexto          = new ItsLawContext();
        private readonly CriptoDescripto    md5                = new CriptoDescripto();



        public UsuarioController()
        {
            //
        }

        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida    = new List<UsuarioViewModel>();
                var listagem = _Usuario.UsuarioListagem(UsuarioSession.Instance.SessionMasterID);   //Somente ativo=1
                foreach (var item in listagem)
                {
                    var registro = new UsuarioViewModel(item);
                    saida.Add(registro);
                }
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //EGS --------------------------------------------- Abrir o registro --------------------------------------
        [AutorizarUsuario(AccessLevel = "Abrir")]
        public ActionResult AbrirAlterarUsuario(int id)
        {
            var dados            = _Usuario.UsuarioGetById(id);
            ViewBag.TabPerfil    = _contexto.UsuarioPerfil.Where(s => s.Ativo.Equals(true));
            ViewBag.TabEmpresa   = _contexto.Empresa.Where(s => s.Ativo.Equals(true));
            var saida = new UsuarioViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirUsuario()
        {
            ViewBag.PerfilDescricao  = _Perfil.UsuarioPerfilListagem(UsuarioSession.Instance.SessionMasterID);             ////EGS 30.08.2018 - Listagem dos Perfis existentes
            ViewBag.EmpresaDescricao = _Empresa.EmpresaListagem(UsuarioSession.Instance.SessionMasterID);                  ////EGS 30.08.2018 - Listagem das Empresas
            return View();
        }

        [HttpPost]
        public ActionResult IncluirUsuario(UsuarioViewModel Itens)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Usuario").Mensagem("Dados inválidos... !", "Atenção");
                }
                else
                {
                    if (Itens.ImageUpload != null)
                    {
                        var imageTypes = new string[]{
                        "image/gif",
                        "image/jpeg",
                        "image/pjpeg",
                        "image/png"
                        };
                        if (!imageTypes.Contains(Itens.ImageUpload.ContentType))
                        {
                            return RedirectToAction("Index", "Usuario").Mensagem("Escolha uma iamgem GIF, JPG ou PNG.", "Atenção");
                        }

                        // Salvar a imagem para a pasta e pega o caminho
                        using (var binaryReader = new BinaryReader(Itens.ImageUpload.InputStream))
                        {
                            Itens.Fotografia  = binaryReader.ReadBytes(Itens.ImageUpload.ContentLength);
                            Itens.ImageUpload = null;
                        }
                    }
                    else
                    {
                        // Salvar a imagem para a pasta e pega o caminho
                        using (var binaryReader = new BinaryReader(Itens.ImageUpload.InputStream))
                        {
                            Itens.Fotografia  = binaryReader.ReadBytes(Itens.ImageUpload.ContentLength);
                            Itens.ImageUpload = null;
                        }
                    }

                    if (Itens.IdUsuarioPerfil == 0) { Itens.IdUsuarioPerfil = 1; }   //(nao informado)
                    var unique = Guid.NewGuid().ToString();
                    Itens.IdMaster = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                    Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                    Itens.DtUsuarioInclusao = DateTime.Now;
                    Itens.AtivoEmail = false;
                    Itens.Ativo = true;
                    Itens.CodigoAtivacao = unique.ToString();
                    //verifica duplicidade de email
                    if (!ItsLawBancoFuncoes.VerificaEmailDuplicado(Itens.IdUsuario, Itens.Email))
                    {
                        _Usuario.UsuarioAdd(Itens.ToDomain());
                        bool bEmailEnviado = _ServicoEnvioEmail.EnvioEmail_IncluirUsuario(Itens.ToDomain());
                        if (bEmailEnviado == true)
                        {
                            return RedirectToAction("Index", "Usuario").Mensagem("Email enviado ao usuario para confirmar o registro !", "Informação");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Usuario").Mensagem("Impossível enviar email para o usuario continuar o registro!", "Atenção");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Index", "Usuario").Mensagem("Email já cadastrado, usuário não incluido !", "Atenção");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario").Mensagem("Impossível incluir o registro:: " + ex.Message, "Atenção");
            }
        }

        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarUsuario(UsuarioViewModel Itens)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("Index", "Usuario").Mensagem("Dados inválidos... !", "Atenção");
                }
                else { 
                    if (Itens.ImageUpload != null)
                    {
                        var imageTypes = new string[]{
                        "image/gif",
                        "image/jpeg",
                        "image/pjpeg",
                        "image/png"
                        };
                        if (!imageTypes.Contains(Itens.ImageUpload.ContentType))
                        {
                            return RedirectToAction("Index", "Usuario").Mensagem("Escolha uma iamgem GIF, JPG ou PNG.", "Atenção");
                        }

                        // Salvar a imagem para a pasta e pega o caminho
                        using (var binaryReader = new BinaryReader(Itens.ImageUpload.InputStream))
                        {
                            Itens.Fotografia = binaryReader.ReadBytes(Itens.ImageUpload.ContentLength);
                            Itens.ImageUpload = null;
                        }
                    }
                    if (Itens.IdUsuarioInclusao == 0)
                    {
                        var dados = _Usuario.UsuarioGetById(Itens.IdUsuario);
                        Itens.IdUsuarioInclusao = dados.IdUsuarioInclusao;
                        Itens.DtUsuarioInclusao = dados.DtUsuarioInclusao;
                    }
                    if (Itens.IdUsuarioPerfil == 0) { Itens.IdUsuarioPerfil = UsuarioSession.Instance.SessionPerfilID; }   //(nao informado)
                    if (Itens.IdMaster        == 0) { Itens.IdMaster        = UsuarioSession.Instance.SessionMasterID; }   //(nao informado)
                    Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                    Itens.DtUsuarioAlteracao = DateTime.Now;

                    //verifica duplicidade de email
                    if (!ItsLawBancoFuncoes.VerificaEmailDuplicado(Itens.IdUsuario, Itens.Email))
                    {
                        _Usuario.UsuarioUpdate(Itens.ToDomain());
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Usuario").Mensagem("Email já cadastrado, usuário não alterado !", "Atenção");
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario").Mensagem("Impossível salvar o registro selecionado !" + ex.Message + " " + ex.InnerException, "Atenção");
            }
        }

        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarUsuario(int id)
        {
            try
            {
                var dados                 = _Usuario.UsuarioGetById(id);
                dados.Ativo               = false;
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                _Usuario.UsuarioUpdate(dados);
                return RedirectToAction("Index", "Usuario").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

        //EGS --------------------------------------------- Após Inserir Usuario, enviar email --------------------
        //EGS 30.11.2018 Rotina para enviar email ao incluir usuarios
        public ActionResult IncluirUsuarioEmail(UsuarioViewModel Itens)
        {
            try
            {
                var unique = Guid.NewGuid().ToString();
                var dados            = _Usuario.UsuarioGetById(3);
                dados.CodigoAtivacao = unique.ToString();
                _Usuario.UsuarioUpdate(dados);
                bool bEmailEnviado   = _ServicoEnvioEmail.EnvioEmail_IncluirUsuario(dados);
                if (bEmailEnviado == true)
                {
                    return RedirectToAction("Index", "Usuario").Mensagem("Email enviado ao usuario para confirmar o registro !", "Informação");
                }
                else
                {
                    return RedirectToAction("Index", "Usuario").Mensagem("Impossível enviar email para o usuario continuar o registro!", "Atenção");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Usuario").Mensagem("Impossível incluir o usuario selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Alterar Senha do Usuario-------------------------------
        //EGS --------------------------------------------- Alterar Senha do Usuario-------------------------------
        [AutorizarUsuario(AccessLevel = "AlterarSenha")]
        public ActionResult UsuarioAlterarSenha()
        {
            ViewBag.Msg               = "";
            Usuario UsuarioLogado     = _Usuario.UsuarioGetById(UsuarioSession.Instance.SessionUserID);
            ViewBag.UsuarioEmailAtual = UsuarioLogado.Email;
            ViewBag.UsuarioLoginAtual = UsuarioLogado.Nome;
            return View();
        }

        [HttpPost]
        public ActionResult UsuarioAlterarSenha(string txtSenhaAtual, string txtSenhaNova, string txtSenhaNova2)
        {
            try
            {
                CriptoDescripto md5   = new CriptoDescripto();
                Usuario UsuarioLogado = _Usuario.UsuarioGetById(UsuarioSession.Instance.SessionUserID);
                string senhaAntigaMD5 = md5.RetornarMD5(txtSenhaAtual);
                Boolean ComparaSenha  = md5.ComparaMD5(UsuarioLogado.SenhaCripto, senhaAntigaMD5);
                if (ComparaSenha == false)
                {
                    ViewBag.Msg = "Senha atual incorreta";
                    return View();
                }
                else
                {
                    if (txtSenhaNova.ToUpper().Trim() == "")
                    {
                        ViewBag.Msg = "Senha nova não pode estar em branco !";
                        return View();
                    }
                    else
                    {
                        if (txtSenhaNova.ToUpper().Trim() != txtSenhaNova2.ToUpper().Trim())
                        {
                            ViewBag.Msg = "Senhas novas diferentes";
                            return View();
                        } else
                        {
                            string senhaNovaMD5            = md5.RetornarMD5(txtSenhaNova);
                            UsuarioLogado.SenhaCripto      = senhaNovaMD5;
                            UsuarioLogado.DtSenhaAlteracao = DateTime.Now;
                            _Usuario.UsuarioUpdate(UsuarioLogado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = "Impossível alterar a senha, ocorreu um erro: " + ex.Message + " " + ex.InnerException;
                return View();
            }
            return RedirectToAction("Index", "Home").Mensagem("Senha alterada com sucesso !", "Informação"); 
        }
    }
}