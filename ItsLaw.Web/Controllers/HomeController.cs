using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ItsLaw.Infra;
using ItsLaw.Web.CustomAutorization;
using ItsLaw.Funcoes;
using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.ViewModels;


namespace ItsLaw.Web.Controllers
{
    public class HomeController : Controller
    {
            
        private readonly IUsuario _usuario = new UsuarioService();
        private readonly IEmpresa _Empresa = new EmpresaService();
        private readonly ServicoEnvioEmail _ServicoEnvioEmail = new ServicoEnvioEmail();
        private readonly CriptoDescripto md5 = new CriptoDescripto();

        public HomeController()
        {
            //
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string pEmail, string pSenha)
        {
            CriptoDescripto md5 = new CriptoDescripto();
            string senhaBanco = _usuario.UsuarioPesquisarSenha(pEmail);
            if ((senhaBanco == "") || (senhaBanco == null))
            {
                ViewBag.Msg = "Usuário näo encontrado";
            }
            else
            { 
                string senhaMD5   = md5.RetornarMD5(pSenha);
                Boolean ComparaSenha = md5.ComparaMD5(senhaBanco, senhaMD5);
                if (ComparaSenha == false)
                {
                    ViewBag.Msg = "Senha invalida";
                }
                else 
                { 
                    var dados = _usuario.UsuarioPesquisar(x => x.Email == pEmail).FirstOrDefault();
                    FormsAuthentication.SetAuthCookie(pEmail, false);
                    Session.Add(".PermissionCookie", dados);

                    //EGS 30.03.2018 - Grava o usuario logado, para usar em todos os cadastros
                    UsuarioSession.Instance.SessionMasterID = md5.RetornaIDMaster();   //EGS 30.09.2018 - EMPRESA MASTER
                    if ((UsuarioSession.Instance.SessionMasterID <= 0) || (UsuarioSession.Instance.SessionMasterID >= 1800000))
                    {
                        ViewBag.Msg = "Empresa Master näo informada";
                    }
                    else
                    {
                        if ((Convert.ToBoolean(dados.AtivoEmail) == false) || (dados.CodigoAtivacao.ToString() == ""))
                        {
                            ViewBag.Msg = "Usuário ainda não validado por email";
                        }
                        else
                        {
                            UsuarioValidacao usuarioValidacao = new UsuarioValidacao();
                            usuarioValidacao.DadosUsuarioGlobal(dados.IdUsuario);
                            ViewBag.Usuario        = UsuarioSession.Instance.SessionUserID;
                            ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserLogin;
                            ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;
                            return RedirectToAction("Index", "MenuPrincipal");
                            }
                    }
                }        
            }
            return View();
        }


        //EGS --------------------------------------------- Opção de Recuperaçao de Senha -------------------------
        //EGS --------------------------------------------- Opção de Recuperaçao de Senha -------------------------
        public ActionResult RecuperarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarSenha(string txtRecuperaEmail)
        {
            var dados = _usuario.UsuarioPesquisar(x => x.Email == txtRecuperaEmail).FirstOrDefault();
            if (dados == null)
            {
                return RedirectToAction("Index", "Home").Mensagem("Usuário näo encontrado", "Informação");
            };
            bool bEmailEnviado = _ServicoEnvioEmail.EnvioEmail_UsuarioRecuperarSenha(dados);
            return RedirectToAction("Index", "Home").Mensagem("Email de 'Recuperação de Senha' enviado ao usuario !", "Informação");
        }
            //EGS ----------------------------------------------------------------------------------------------------
            //EGS --------------------------------------------- Opção de Recuperaçao de Senha -------------------------
    }
}