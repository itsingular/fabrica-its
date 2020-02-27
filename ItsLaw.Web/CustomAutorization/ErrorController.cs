using System.Web.Mvc;
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


namespace ItsLaw.Web.CustomAutorization
{
    public class ErrorController : Controller
    {
        //
        // GET: /Admin/Error/ Mostrar empresa 30.03.2018, mas com erro
        public ActionResult AccessDenied()
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
