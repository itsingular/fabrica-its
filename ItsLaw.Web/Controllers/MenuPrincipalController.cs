using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Entidades;
using ItsLaw.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItsLaw.Funcoes;



namespace ItsLaw.Web.Controllers
{
    public class MenuPrincipalController : Controller
    {

        public ActionResult Index()
        {
            if (UsuarioSession.Instance.SessionUserID != 0)
            {
                ViewBag.UsuarioNome    = UsuarioSession.Instance.SessionUserName;
                ViewBag.UsuarioEmpresa = UsuarioSession.Instance.SessionCompanyName;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}