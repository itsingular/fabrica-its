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
    public class TipoAcaoController : Controller
    {
        #region Atributos

        private readonly ITipoAcao _TipoAcao;

        #endregion

        #region Construtor
        public TipoAcaoController()
        {
            _TipoAcao = new TipoAcaoService();
        }
        #endregion

        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome     = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida = new List<TipoAcaoViewModel>();
                var listagem = _TipoAcao.TipoAcaoListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new TipoAcaoViewModel(item);
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
        public ActionResult AbrirAlterarTipoAcao(int id)
        {
            var dados = _TipoAcao.TipoAcaoGetById(id);
            var saida = new TipoAcaoViewModel(dados);
            return View(saida);
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirTipoAcao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTipoAcao(TipoAcaoViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _TipoAcao.TipoAcaoAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAcao").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        
        
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarTipoAcao(TipoAcaoViewModel Itens)
        {
            try
            {
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _TipoAcao.TipoAcaoUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAcao").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarTipoAcao(int id)
        {
            try
            {
                var dados                 = _TipoAcao.TipoAcaoGetById(id);
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                dados.Ativo               = false;
                _TipoAcao.TipoAcaoUpdate(dados);
                return RedirectToAction("Index", "TipoAcao").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAcao").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}