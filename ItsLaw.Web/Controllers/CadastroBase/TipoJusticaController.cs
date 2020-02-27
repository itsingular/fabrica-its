using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Web.ViewModels;
using ItsLaw.Funcoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ItsLaw.Web.Controllers
{
    public class TipoJusticaController : Controller
    {
        #region Atributos

        private readonly ITipoJustica _TipoJustica;

        #endregion

        #region Construtor
        public TipoJusticaController()
        {
            _TipoJustica = new TipoJusticaService();
        }
        #endregion

        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida = new List<TipoJusticaViewModel>();
                var listagem = _TipoJustica.TipoJusticaListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new TipoJusticaViewModel(item);
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
        public ActionResult AbrirAlterarTipoJustica(int id)
        {
            var dados = _TipoJustica.TipoJusticaGetById(id);
            var saida = new TipoJusticaViewModel(dados);
            return View(saida);
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirTipoJustica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTipoJustica(TipoJusticaViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _TipoJustica.TipoJusticaAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoJustica").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        
        
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarTipoJustica(TipoJusticaViewModel Itens)
        {
            try
            {
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _TipoJustica.TipoJusticaUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoJustica").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarTipoJustica(int id)
        {
            try
            {
                var dados                 = _TipoJustica.TipoJusticaGetById(id);
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                dados.Ativo               = false;
                _TipoJustica.TipoJusticaUpdate(dados);
                return RedirectToAction("Index", "TipoJustica").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoJustica").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}