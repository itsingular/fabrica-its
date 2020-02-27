using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ItsLaw.WebAPI.Mobile;



namespace ItsLaw.WebAPI.Mobile
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private GravaLogAPI _logHlp = new GravaLogAPI();

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //_logHlp._GravaLog("HttpContext.Current.Request.HttpMethod = " + HttpContext.Current.Request.HttpMethod);
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST,GET,PUT,DELETE,OPTIONS");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Access-Control-Allow-Headers, Access-Control-Allow-Methods, Authorization, X-Requested-With, Access-Control-Allow-Origin, Access-Control-Expose-Headers, Skip-Authorization, X-SessionId");
                HttpContext.Current.Response.AddHeader("Access-Control-Expose-Headers", "Content-Type, Authorization");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
