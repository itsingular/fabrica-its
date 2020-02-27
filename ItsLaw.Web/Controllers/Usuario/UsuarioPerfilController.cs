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
using System.Web;
using System.Web.Mvc;



namespace ItsLaw.Web.Controllers
{
    public class UsuarioPerfilController : Controller
    {
        private readonly IUsuarioPerfil   _Perfil;
        private readonly IUsuario         _UsuarioID;



        public UsuarioPerfilController()
        {
            _Perfil         = new UsuarioPerfilService();
            _UsuarioID      = new UsuarioService();
        }


        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida              = new List<UsuarioPerfilViewModel>();
                var listagem           = _Perfil.UsuarioPerfilListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new UsuarioPerfilViewModel(item);
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
        public ActionResult AbrirAlterarUsuarioPerfil(int id)
        {
            var dadosPerfil         = _Perfil.UsuarioPerfilGetById(id);
            ViewBag.PerfilDescricao = "Batatinha :: " + dadosPerfil.Descricao;
            var dadosAcesso         = _Perfil.RetornaDireitosDoUsuario(id);
            var saidaAcesso = new List<UsuarioPerfilDireitoViewModel>();
            foreach (var item in dadosAcesso)
            {
                var registro = new UsuarioPerfilDireitoViewModel(item);
                saidaAcesso.Add(registro);
               //break;
            }
            return View(saidaAcesso);
        }


        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarUsuarioPerfil(List<UsuarioPerfilDireitoViewModel> Itens )
        {
            var dadosPerfil = new UsuarioPerfil();
            try
            {
                foreach (var item in Itens)
                {
                    dadosPerfil = _Perfil.UsuarioPerfilGetById(item.IdUsuarioPerfil);
                    break;
                }
             // dadosPerfil = _Perfil.UsuarioPerfilGetById(Itens.IdUsuarioPerfil);
                _Perfil.UsuarioPerfilUpdate(dadosPerfil);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UsuarioPerfil").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }



        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirUsuarioPerfil()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirUsuarioPerfil(UsuarioPerfilViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _Perfil.UsuarioPerfilAdd(Itens.ToDomain());
                _Perfil.AddAcessoDireitoBranco(Itens.IdMaster, Itens.IdUsuarioInclusao);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UsuarioPerfil").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarUsuarioPerfil(int id)
        {
            try
            {
                var dados                 = _Perfil.UsuarioPerfilGetById(id);
                dados.Ativo               = false;
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                _Perfil.UsuarioPerfilUpdate(dados);
                return RedirectToAction("Index", "UsuarioPerfil").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UsuarioPerfil").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}

