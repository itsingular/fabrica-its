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
using System.Net;
using System.Net.Http;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers;



namespace ItsLaw.Web.Controllers
{
    public class UsuarioEmpresaController : Controller
    {
        private readonly IUsuario UsuarioDb;
        UsuarioValidacao usuarioValidacao = new UsuarioValidacao();
        protected ItsLawContext _contexto = new ItsLawContext();


        public UsuarioEmpresaController()
        {
            UsuarioDb = new UsuarioService();
        }


        //EGS --------------------------------------------- Selecionar todos os registro --------------------------
        [AutorizarUsuario(AccessLevel = "Index")]
        public ActionResult UsuarioEmpresa()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome         = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa      = UsuarioSession.Instance.SessionCompanyName;
                ViewBag.TabUsuarioEmpresa   = UsuarioDb.UsuarioEmpresaListagem(UsuarioSession.Instance.SessionMasterID);         ////EGS 30.09.2018 - Listagem de Empresas
                var dados                   = UsuarioDb.UsuarioGetById(UsuarioSession.Instance.SessionUserID);
                ViewBag.UsuarioLoginAtual   = dados.Nome;
                ViewBag.UsuarioEmpresaAtual = dados.FantasiaEmpresa;
                var saida = new UsuarioEmpresaViewModel(dados);
                return View(saida);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        

        //EGS --------------------------------------------- Salvar o registro -------------------------------------
        [HttpPost]
        public ActionResult SalvarUsuarioEmpresa(UsuarioEmpresaViewModel Item )
        {
            var dadosUsuEmpresa = new Usuario();
            try
            {
                dadosUsuEmpresa = UsuarioDb.UsuarioGetById(Item.IdUsuario);
                if (dadosUsuEmpresa.IdEmpresa == Item.IdEmpresa)
                {
                    return RedirectToAction("Index", "UsuarioEmpresa").Mensagem("Empresa já esta selcionado, não é necessário alterar", "Atenção");
                }
                else { 
                    dadosUsuEmpresa.IdEmpresa          = Item.IdEmpresa;
                    dadosUsuEmpresa.IdUsuarioAlteracao = UsuarioSession.Instance.SessionUserID;
                    dadosUsuEmpresa.DtUsuarioAlteracao = DateTime.Now;
                    UsuarioDb.UsuarioUpdate(dadosUsuEmpresa);

                    usuarioValidacao.DadosUsuarioGlobal(Item.IdUsuario);
                    ViewBag.Usuario        = UsuarioSession.Instance.SessionUserID;
                    ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserLogin;
                    ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;

                    return RedirectToAction("Index", "MenuPrincipal").Mensagem("Empresa alterada com sucesso !", "Informação");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "UsuarioEmpresa").Mensagem("Impossível salvar o registro selecionado !" + ex.Message, "Atenção");
            }
        }

    }
}

