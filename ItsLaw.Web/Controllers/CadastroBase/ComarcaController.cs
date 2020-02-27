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
    public class ComarcaController : Controller
    {
        #region Atributos

        private readonly IComarca _Comarca;

        #endregion

        #region Construtor
        public ComarcaController()
        {
            _Comarca = new ComarcaService();
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

                var saida = new List<ComarcaViewModel>();
                var listagem = _Comarca.ComarcaListagem(UsuarioSession.Instance.SessionMasterID);
                foreach (var item in listagem)
                {
                    var registro = new ComarcaViewModel(item);
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
        public ActionResult AbrirAlterarComarca(int id)
        {
            var dados = _Comarca.ComarcaGetById(id);
            var saida = new ComarcaViewModel(dados);
            return View(saida);
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Incluir")]
        public ActionResult IncluirComarca()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirComarca(ComarcaViewModel Itens)
        {
            try
            {
                Itens.IdMaster          = UsuarioSession.Instance.SessionMasterID;          //EGS 30.09.2019 - Empresa Master
                Itens.IdUsuarioInclusao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioInclusao = DateTime.Now;
                Itens.Ativo             = true;
                _Comarca.ComarcaAdd(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Comarca").Mensagem("Impossível alterar o registro selecionado !" + ex.Message, "Atenção");
            }
        }
        
        
        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarComarca(ComarcaViewModel Itens)
        {
            try
            {
                Itens.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                Itens.DtUsuarioAlteracao = DateTime.Now;
                _Comarca.ComarcaUpdate(Itens.ToDomain());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Comarca").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario(AccessLevel = "Excluir")]
        public ActionResult InativarComarca(int id)
        {
            try
            {
                var dados                 = _Comarca.ComarcaGetById(id);
                dados.IdUsuarioAlteracao  = UsuarioSession.Instance.SessionUserID;
                dados.DtUsuarioAlteracao  = DateTime.Now;
                dados.Ativo               = false;
                _Comarca.ComarcaUpdate(dados);
                return RedirectToAction("Index", "Comarca").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Comarca").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}