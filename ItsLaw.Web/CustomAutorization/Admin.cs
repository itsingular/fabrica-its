using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ItsLaw.Entidades;
using ItsLaw.Infra;
using ItsLaw.Web;
using ItsLaw.Funcoes;
using ItsLaw.Business.Interfaces;
using ItsLaw.Business;
using System;
using System.Web.Profile;



namespace ItsLaw.Web.CustomAutorization
{

    public class AutorizarUsuario : AuthorizeAttribute
    {


        // Custom property
        public string AccessLevel { get; set; } //opcional ja que pegara tudo automatico, estou colocando so pra dar mais flexibilidade para desenvolvimento futuro


        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            if (UsuarioSession.Instance.SessionUserID == 0)
            {
                UsuarioValidacao usuarioValidacao = new UsuarioValidacao();
                usuarioValidacao.LimpaDadosUsuario();
                return false;            
            }
            else
            {
                var service = new UsuarioPerfilService();
                var caminho = httpContext.Request.Path;
                var saida   = service.PerfilDireitoAutoriza(caminho, AccessLevel, UsuarioSession.Instance.SessionPerfilID);
                return saida;
            }
        }






        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
            }

        }
    }
}
