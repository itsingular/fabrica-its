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
    public class TipoAreaDireitoController : Controller
    {
        #region Atributos

        private readonly ITipoAreaDireito _TipoAreaDireito;

        #endregion

        #region Construtor
        public TipoAreaDireitoController()
        {
            _TipoAreaDireito = new TipoAreaDireitoService();
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

                var saida = new List<TipoAreaDireitoViewModel>();
                var listagem = _TipoAreaDireito.TipoAreaDireitoListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new TipoAreaDireitoViewModel(item);
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
        public ActionResult AbrirAlterarTipoAreaDireito(int id)
        {
            var dados = _TipoAreaDireito.TipoAreaDireitoGetById(id);
            var saida = new TipoAreaDireitoViewModel(dados);
            return View(saida);
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirTipoAreaDireito()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirTipoAreaDireito(TipoAreaDireitoViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _TipoAreaDireito.TipoAreaDireitoAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAreaDireito").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        
        
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarTipoAreaDireito(TipoAreaDireitoViewModel Itens)
        {
            try
            {
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _TipoAreaDireito.TipoAreaDireitoUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAreaDireito").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarTipoAreaDireito(int id)
        {
            try
            {
                var dados                 = _TipoAreaDireito.TipoAreaDireitoGetById(id);
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                dados.Ativo               = false;
                _TipoAreaDireito.TipoAreaDireitoUpdate(dados);
                return RedirectToAction("Index", "TipoAreaDireito").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "TipoAreaDireito").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}