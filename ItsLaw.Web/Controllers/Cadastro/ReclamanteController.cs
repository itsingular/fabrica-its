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
    public class ReclamanteController : Controller
    {
        private readonly IReclamante     _Reclamante;
        private readonly ITabAuxiliar    _TabAuxiliar;
        protected ItsLawContext _contexto = new ItsLawContext();


        public ReclamanteController()
        {
            _Reclamante = new ReclamanteService();
            _TabAuxiliar    = new TabAuxiliarService();
        }


        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida              = new List<ReclamanteViewModel>();
                var listagem           = _Reclamante.ReclamanteListagem(UsuarioSession.Instance.SessionMasterID);    //Somente ativo=1
                foreach (var item in listagem)
                {
                    var registro = new ReclamanteViewModel(item);
                    saida.Add(registro);
                }
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        


        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarReclamante(ReclamanteViewModel Itens)
        {
            try
            {
                if (Itens.IDSexo        == 0) { Itens.IDSexo        = 1001; }   //(nao informado)
                if (Itens.IDEstadoCivil == 0) { Itens.IDEstadoCivil = 2001; }   //(nao informado)
                if (Itens.IDEstado      == 0) { Itens.IDEstado      = 3001; }   //São Paulo

                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _Reclamante.ReclamanteUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Reclamante").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Abrir o registro --------------------------------------
        [AutorizarUsuario(AccessLevel = "Abrir")]
        public ActionResult AbrirAlterarReclamante(int id)
        {
            var dados              = _Reclamante.ReclamanteGetById(id);
            ViewBag.TabAuxSexo     = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("SEXO"       ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstado   = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADO"     ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstCivil = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADOCIVIL") && s.Ativo.Equals(true));
            var saida = new ReclamanteViewModel(dados);
            return View(saida);
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirReclamante()
        {
            ViewBag.SexoDescricao     = _TabAuxiliar.SexoListagem();             ////EGS 30.08.2018 - Listagem de Sexo e Ees tado Civil
            ViewBag.EstadoDescricao   = _TabAuxiliar.EstadoListagem();           ////EGS 30.08.2018 - Listagem de Estado Civil
            ViewBag.EstCivilDescricao = _TabAuxiliar.EstCivilListagem();         ////EGS 30.08.2018 - Listagem de Estado UF
            return View();
        }

        [HttpPost]
        public ActionResult IncluirReclamante(ReclamanteViewModel Itens)
        {
            try
            {
                if (Itens.IDSexo        == 0) { Itens.IDSexo        = 1001; }   //(nao informado)
                if (Itens.IDEstadoCivil == 0) { Itens.IDEstadoCivil = 2001; }   //(nao informado)
                if (Itens.IDEstado      == 0) { Itens.IDEstado      = 3001; }   //São Paulo
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _Reclamante.ReclamanteAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Reclamante").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    

        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarReclamante(int id)
        {
            try
            {
                var dados                 = _Reclamante.ReclamanteGetById(id);
                dados.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao = DateTime.Now;
                dados.Ativo               = false;
                _Reclamante.ReclamanteUpdate(dados);
                return RedirectToAction("Index", "Reclamante").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Reclamante").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    }
}