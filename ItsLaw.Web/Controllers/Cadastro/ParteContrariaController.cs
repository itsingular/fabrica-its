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
    public class ParteContrariaController : Controller
    {
        private readonly IParteContraria _ParteContraria;
        private readonly ITabAuxiliar    _TabAuxiliar;
        private readonly IUsuarioPerfil  _Perfil;
        private readonly IUsuario        _UsuarioID;
        protected ItsLawContext _contexto = new ItsLawContext();


        public ParteContrariaController()
        {
            _ParteContraria = new ParteContrariaService();
            _TabAuxiliar    = new TabAuxiliarService();
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

                var saida              = new List<ParteContrariaViewModel>();
                var listagem           = _ParteContraria.ParteContrariaListagem(UsuarioSession.Instance.SessionMasterID);    //Somente ativo=1
                foreach (var item in listagem)
                {
                    var registro = new ParteContrariaViewModel(item);
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
        public ActionResult AbrirAlterarParteContraria(int id)
        {
            var dados              = _ParteContraria.ParteContrariaGetById(id);
            ViewBag.TabAuxSexo     = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("SEXO"       ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstado   = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADO"     ) && s.Ativo.Equals(true));
            ViewBag.TabAuxEstCivil = _contexto.TabAuxiliar.Where(s => s.Filtro.Equals("ESTADOCIVIL") && s.Ativo.Equals(true));
            var saida = new ParteContrariaViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirParteContraria()
        {
            ViewBag.SexoDescricao     = _TabAuxiliar.SexoListagem();             ////EGS 30.08.2018 - Listagem de Sexo e Ees tado Civil
            ViewBag.EstadoDescricao   = _TabAuxiliar.EstadoListagem();           ////EGS 30.08.2018 - Listagem de Estado Civil
            ViewBag.EstCivilDescricao = _TabAuxiliar.EstCivilListagem();         ////EGS 30.08.2018 - Listagem de Estado UF
            return View();
        }

        [HttpPost]
        public ActionResult IncluirParteContraria(ParteContrariaViewModel Itens)
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
                _ParteContraria.ParteContrariaAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ParteContraria").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarParteContraria(ParteContrariaViewModel Itens)
        {
            try
            {
                if (Itens.IDSexo        == 0) { Itens.IDSexo        = 1001; }   //(nao informado)
                if (Itens.IDEstadoCivil == 0) { Itens.IDEstadoCivil = 2001; }   //(nao informado)
                if (Itens.IDEstado      == 0) { Itens.IDEstado      = 3001; }   //São Paulo

                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _ParteContraria.ParteContrariaUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ParteContraria").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarParteContraria(int id)
        {
            try
            {
                var dados                 = _ParteContraria.ParteContrariaGetById(id);
                dados.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao = DateTime.Now;
                dados.Ativo               = false;
                _ParteContraria.ParteContrariaUpdate(dados);
                return RedirectToAction("Index", "ParteContraria").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "ParteContraria").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
    }
}