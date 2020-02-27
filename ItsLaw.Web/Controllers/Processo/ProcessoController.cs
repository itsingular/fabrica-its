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
    public class ProcessoController : Controller
    {

        private readonly IProcesso _Processo;
        protected ItsLawContext _contexto = new ItsLawContext();


        public ProcessoController()
        {
            _Processo = new ProcessoService();
        }


        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                //--------------------------------------------------------------------------------------------
                var ItemListagem = new ProcessoFiltro();
                ItemListagem.FiltroIdMaster = (UsuarioSession.Instance.SessionMasterID);
                //--------------------------------------------------------------------------------------------
                ViewBag.UsuarioNome        = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa     = UsuarioSession.Instance.SessionCompanyName;
                ViewBag.TabTipoAcao        = _contexto.TipoAcao.Where       (s => s.Ativo.Equals(true));
                ViewBag.TabTipoJustica     = _contexto.TipoJustica.Where    (s => s.Ativo.Equals(true));
                ViewBag.TabTipoAreaDireito = _contexto.TipoAreaDireito.Where(s => s.Ativo.Equals(true));
                ViewBag.TabComarca         = _contexto.Comarca.Where        (s => s.Ativo.Equals(true));
                ViewBag.TabEmpresa         = _contexto.Empresa.Where        (s => s.Ativo.Equals(true));
                ViewBag.TabEscritorio      = _contexto.Escritorio.Where     (s => s.Ativo.Equals(true));
                ViewBag.TabStatusProcesso  = _contexto.StatusProcesso.Where (s => s.Ativo.Equals(true));
                ViewBag.TabAuxEstado       = _contexto.TabAuxiliar.Where    (s => s.Filtro.Equals("ESTADO") && s.Ativo.Equals(true));
                ViewBag.ProcessoDtInicio   = DateTime.Now;
                ViewBag.ProcessoDtFinal    = DateTime.Now;
                //--------------------------------------------------------------------------------------------
                var saida        = new ProcessoFiltroViewModel();
                //---------------------------------------------------------- Itens do Processo ---------------
                var saidaItens = new List<Processo>();
                var listagem   = _Processo.ProcessoListagem(ItemListagem);
                foreach (var item in listagem)
                {
                    var registro = new Processo();
                    registro     = item;
                    saidaItens.Add(registro);
                }
                saida.ListaProcessos = saidaItens;
                //---------------------------------------------------------- Itens do Processo ---------------
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }



        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        [HttpPost]
        public ActionResult Index(ProcessoFiltroViewModel Itens)
        {
            try
            {
                //--------------------------------------------------------------------------------------------
                ViewBag.UsuarioNome        = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa     = UsuarioSession.Instance.SessionCompanyName;
                ViewBag.TabTipoAcao        = _contexto.TipoAcao.Where       (s => s.Ativo.Equals(true));
                ViewBag.TabTipoJustica     = _contexto.TipoJustica.Where    (s => s.Ativo.Equals(true));
                ViewBag.TabTipoAreaDireito = _contexto.TipoAreaDireito.Where(s => s.Ativo.Equals(true));
                ViewBag.TabComarca         = _contexto.Comarca.Where        (s => s.Ativo.Equals(true));
                ViewBag.TabEmpresa         = _contexto.Empresa.Where        (s => s.Ativo.Equals(true));
                ViewBag.TabEscritorio      = _contexto.Escritorio.Where     (s => s.Ativo.Equals(true));
                ViewBag.TabStatusProcesso  = _contexto.StatusProcesso.Where (s => s.Ativo.Equals(true));
                ViewBag.TabAuxEstado       = _contexto.TabAuxiliar.Where    (s => s.Filtro.Equals("ESTADO") && s.Ativo.Equals(true));
                ViewBag.ProcessoDtInicio   = DateTime.Now;
                ViewBag.ProcessoDtFinal    = DateTime.Now;
                //--------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------
                var saida        = new ProcessoFiltroViewModel();
                //---------------------------------------------------------- Itens do Processo ---------------
                var saidaItens = new List<Processo>();
                var listagem   = _Processo.ProcessoListagem(Itens.ToDomain());
                foreach (var item in listagem)
                {
                    var registro = new Processo();
                    registro     = item;
                    saidaItens.Add(registro);
                }
                saida.ListaProcessos = saidaItens;
                //---------------------------------------------------------- Itens do Processo ---------------
                return View(saida);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Processo").Mensagem("Impossível filtrar os processos !" + ex.Message, "Atenção");
            }
        }

    }
}