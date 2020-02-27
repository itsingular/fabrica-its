using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Web.ViewModels;
using System;
using ItsLaw.Funcoes;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ItsLaw.Web.Controllers
{
    public class UsuarioPathController : Controller
    {
        #region Atributos

        private readonly IUsuarioPath   _UsuarioPath;
        private readonly IUsuarioPerfil _perfil;
        private readonly IUsuario       _usuario;

        #endregion

        #region Construtor
        public UsuarioPathController()
        {
            _UsuarioPath = new UsuarioPathService();
            _perfil = new UsuarioPerfilService();
            _usuario = new UsuarioService();
        }
        #endregion

        [AutorizarUsuario]
        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                var saida = new List<UsuarioPathViewModel>();
                var listagem = _UsuarioPath.Listagem();
                foreach (var item in listagem)
                {
                    //EGS 30.02.2018 - Pega somente os registros ativos...
                    if (item.Ativo == true)
                    {
                        var registro = new UsuarioPathViewModel(item);
                        saida.Add(registro);
                    }
                }
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        //EGS --------------------------------------------- Abrir o registro --------------------------------------
        [AutorizarUsuario]
        public ActionResult AbrirAlterar(int id)
        {
            var dados = _UsuarioPath.GetById(id);
            var saida = new UsuarioPathViewModel(dados);
            return View(saida);
        }

        //EGS --------------------------------------------- Inativar o registro -----------------------------------
        [AutorizarUsuario]
        public ActionResult InativarUsuarioPath(int id)
        {
            try
            {
                var dados = _UsuarioPath.GetById(id);
                dados.Ativo = false;
                //-------------------------------------------- Devolve registro atualizado
                _UsuarioPath.Update(dados);
                //-------------------------------------------- Devolve registro atualizado
                return RedirectToAction("Index", "UsuarioPath").Mensagem("Registro Apagado com Sucesso !", "Atenção");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UsuarioPath").Mensagem("Impossível apagar o registro selecionado !" + ex.Message, "Atenção");
            }
        }


        //EGS --------------------------------------------- Incluir um registro -----------------------------------

        [AutorizarUsuario]
        public ActionResult IncluirUsuarioPath()
        {
            return View();
        }


        [HttpPost]
        public ActionResult IncluirUsuarioPath(UsuarioPathViewModel Itens)
        {
            Itens.Ativo = true;
            _UsuarioPath.Add(Itens.ToDomain());
            return RedirectToAction("Index");
        }

        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarUsuarioPath(UsuarioPathViewModel Itens)
        {
            if (Itens != null)
            {
                _UsuarioPath.Update(Itens.ToDomain());
            }
            return RedirectToAction("Index");
        }
    }
}