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
    public class AdvogadoController : Controller
    {
        private readonly IAdvogado      _Advogado;
        private readonly ITabAuxiliar   _TabAuxiliar;
        private readonly ITipoOAB       _TipoOAB;
        private readonly IUsuarioPerfil _Perfil;
        private readonly IUsuario       _UsuarioID;
        protected ItsLawContext _contexto = new ItsLawContext();

        public AdvogadoController()
        {
            _Advogado    = new AdvogadoService();
            _TabAuxiliar = new TabAuxiliarService();
            _TipoOAB     = new TipoOABService();
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

                var saida    = new List<AdvogadoViewModel>();
                var listagem = _Advogado.AdvogadoListagem(UsuarioSession.Instance.SessionMasterID);    //Somente ativo=1 e IDMaster
                foreach (var item in listagem)
                {
                    var registro = new AdvogadoViewModel(item);
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
        public ActionResult AbrirAlterarAdvogado(int id)
        {
            var dados              = _Advogado.AdvogadoGetById(id);
            ViewBag.TabAuxSexo     = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("SEXO"       ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstado   = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADO"     ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstCivil = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADOCIVIL") && s.Ativo.Equals(true));
            ViewBag.OABInscricao   = _contexto.TipoOAB.Where    (s => s.Ativo.Equals(true));

            var saida = new AdvogadoViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirAdvogado()
        {
            ViewBag.SexoDescricao     = _TabAuxiliar.SexoListagem();             ////EGS 30.08.2018 - Listagem de Sexo e Ees tado Civil
            ViewBag.EstadoDescricao   = _TabAuxiliar.EstadoListagem();           ////EGS 30.08.2018 - Listagem de Estado
            ViewBag.EstCivilDescricao = _TabAuxiliar.EstCivilListagem();         ////EGS 30.08.2018 - Listagem de Estado UF
            ViewBag.OABInscricao      = _TipoOAB.TipoOABListagem(UsuarioSession.Instance.SessionMasterID);              ////EGS 30.08.2018 - Tipo Inscricao OAB
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAdvogado(AdvogadoViewModel Itens)
        {
            try
            {
                if (Itens.IDSexo              == 0) { Itens.IDSexo              = 1001; }   //(nao informado)
                if (Itens.IDEstadoCivil       == 0) { Itens.IDEstadoCivil       = 2001; }   //(nao informado)
                if (Itens.IDEstado            == 0) { Itens.IDEstado            = 3001; }   //São Paulo
                if (Itens.OAB_IDTipoInscricao == 0) { Itens.OAB_IDTipoInscricao = 1;    }   //Primeiro item da tabela (nao informado)
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _Advogado.AdvogadoAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Advogado").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarAdvogado(AdvogadoViewModel Itens)
        {
            try
            {
                if (Itens.IDSexo              == 0) { Itens.IDSexo              = 1001; }   //(nao informado)
                if (Itens.IDEstadoCivil       == 0) { Itens.IDEstadoCivil       = 2001; }   //(nao informado)
                if (Itens.IDEstado            == 0) { Itens.IDEstado            = 3001; }   //São Paulo
                if (Itens.OAB_IDTipoInscricao == 0) { Itens.OAB_IDTipoInscricao = 1;    }   //Primeiro item da tabela (nao informado)
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _Advogado.AdvogadoUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Advogado").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarAdvogado(int id)
        {
            try
            {
                var dados                 = _Advogado.AdvogadoGetById(id);
                dados.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao = DateTime.Now;
                dados.Ativo               = false;
                _Advogado.AdvogadoUpdate(dados);
                return RedirectToAction("Index", "Advogado").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Advogado").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }       
    }
}