using System;
using System.Web.Mvc;
using System.Web.Routing;
using ItsLaw.Funcoes;


namespace ItsLaw.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Extensão Mensagem para ActionResult - 28.02.2018 - Mostra mensagens personalizadas
            ClientDataTypeModelValidatorProvider.ResourceClassKey = "Mensagens";
            DefaultModelBinder.ResourceClassKey = "Mensagens";


          //AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //EGS 30.03.2018 - Grava o usuario logado, para usar em todos os cadastros
            UsuarioValidacao usuarioValidacao = new UsuarioValidacao();
            usuarioValidacao.LimpaDadosUsuario();

            HtmlHelper.ClientValidationEnabled = true;

        }
        

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           //            
        }

    }
}
