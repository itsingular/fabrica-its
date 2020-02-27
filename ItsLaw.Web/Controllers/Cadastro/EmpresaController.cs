using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Web.ViewModels;
using ItsLaw.Infra;
using ItsLaw.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;



namespace ItsLaw.Web.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresa        _Empresa;
        private readonly ITabAuxiliar    _TabAuxiliar;
        private readonly IUsuarioPerfil  _Perfil;
        private readonly IUsuario        _UsuarioID;
        protected ItsLawContext _contexto = new ItsLawContext();

        public EmpresaController()
        {
            _Empresa     = new EmpresaService();
            _TabAuxiliar = new TabAuxiliarService();
            _Perfil      = new UsuarioPerfilService();
            _UsuarioID   = new UsuarioService();
        }


        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida    = new List<EmpresaViewModel>();
                var listagem = _Empresa.EmpresaListagem(UsuarioSession.Instance.SessionMasterID);    //Somente ativo=1
                foreach (var item in listagem)
                {
                    var registro = new EmpresaViewModel(item);
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
        public ActionResult AbrirAlterarEmpresa(int id)
        {
            var dados               = _Empresa.EmpresaGetById(id);
            var saida               = new EmpresaViewModel(dados);
            ViewBag.TabAuxEstado    = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADO") && s.Ativo.Equals(true));
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirEmpresa()
        {
            ViewBag.EstadoDescricao = _TabAuxiliar.EstadoListagem();           ////EGS 30.08.2018 - Listagem de Estado
            return View();
        }

        [HttpPost]
        public ActionResult IncluirEmpresa(EmpresaViewModel Itens)
        {
            try
            {
                if (Itens.ImageUpload != null)
                {
                    var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
                    if (Itens.ImageUpload == null || Itens.ImageUpload.ContentLength == 0)
                    {
                        ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
                    }
                    else if (!imageTypes.Contains(Itens.ImageUpload.ContentType))
                    {
                        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
                    }

                    // Salvar a imagem para a pasta e pega o caminho
                    using (var binaryReader = new BinaryReader(Itens.ImageUpload.InputStream))
                    {
                        Itens.Logotipo = binaryReader.ReadBytes(Itens.ImageUpload.ContentLength);
                        Itens.ImageUpload = null;
                    }
                }

                if (Itens.IDEstado == 0) { Itens.IDEstado = 3001; }   //São Paulo
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _Empresa.EmpresaAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empresa").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarEmpresa(EmpresaViewModel Itens)
        {
            try
            {
                if (Itens.ImageUpload != null)
                {
                    var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
                    if (Itens.ImageUpload == null || Itens.ImageUpload.ContentLength == 0)
                    {
                        ModelState.AddModelError("ImageUpload", "Este campo é obrigatório");
                    }
                    else if (!imageTypes.Contains(Itens.ImageUpload.ContentType))
                    {
                        ModelState.AddModelError("ImageUpload", "Escolha uma iamgem GIF, JPG ou PNG.");
                    }

                    // Salvar a imagem para a pasta e pega o caminho
                    using (var binaryReader = new BinaryReader(Itens.ImageUpload.InputStream))
                    {
                        Itens.Logotipo = binaryReader.ReadBytes(Itens.ImageUpload.ContentLength);
                        Itens.ImageUpload = null;
                    }
                }
                if (Itens.IDEstado == 0) { Itens.IDEstado = 3001; }   //São Paulo
                if (Itens.IdMaster == 0) { Itens.IdMaster = UsuarioSession.Instance.SessionMasterID; }   //(nao informado)
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _Empresa.EmpresaUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empresa").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarEmpresa(int id)
        {
            try
            {
                var dados                 = _Empresa.EmpresaGetById(id);
                dados.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao = DateTime.Now;
                dados.Ativo               = false;
                _Empresa.EmpresaUpdate(dados);
                return RedirectToAction("Index", "Empresa").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Empresa").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }

}