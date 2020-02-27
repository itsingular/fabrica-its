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
    public class EscritorioController : Controller
    {
        private readonly IEscritorio     _Escritorio;
        private readonly ITabAuxiliar    _TabAuxiliar;
        private readonly IUsuarioPerfil  _Perfil;
        private readonly IUsuario       _UsuarioID;
        protected ItsLawContext _contexto = new ItsLawContext();

        public EscritorioController()
        {
            _Escritorio    = new EscritorioService();
            _TabAuxiliar   = new TabAuxiliarService();
            _Perfil        = new UsuarioPerfilService();
            _UsuarioID     = new UsuarioService();
        }

        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida    = new List<EscritorioViewModel>();
                var listagem = _Escritorio.EscritorioListagem(UsuarioSession.Instance.SessionMasterID);    //Somente ativo=1
                foreach (var item in listagem)
                {
                    var registro = new EscritorioViewModel(item);
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
        public ActionResult AbrirAlterarEscritorio(int id)
        {
            var dados            = _Escritorio.EscritorioGetById(id);
            ViewBag.TabAuxEstado = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADO") && s.Ativo.Equals(true));
            var saida = new EscritorioViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirEscritorio()
        {
            ViewBag.EstadoDescricao = _TabAuxiliar.EstadoListagem();           ////EGS 30.08.2018 - Listagem de Estado Civil
            return View();
        }

        [HttpPost]
        public ActionResult IncluirEscritorio(EscritorioViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                if (Itens.IDEstado      == 0) { Itens.IDEstado      = 3001; }   //São Paulo
                Itens.Ativo             = true;
                _Escritorio.EscritorioAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Escritorio").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarEscritorio(EscritorioViewModel Itens)
        {
            try
            {
                if (Itens.IDEstado      == 0) { Itens.IDEstado      = 3001; }   //São Paulo
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _Escritorio.EscritorioUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Escritorio").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarEscritorio(int id)
        {
            try
            {
                var dados                 = _Escritorio.EscritorioGetById(id);
                dados.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao = DateTime.Now;
                dados.Ativo               = false;
                _Escritorio.EscritorioUpdate(dados);
                return RedirectToAction("Index", "Escritorio").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Escritorio").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        

        public ActionResult EscritorioImagem(int iIDEscritorio)
        {
            byte[] bytes = _Escritorio.EscritorioRetornaFigura(iIDEscritorio);
            return File(bytes, "image/png");
        }


    }
}