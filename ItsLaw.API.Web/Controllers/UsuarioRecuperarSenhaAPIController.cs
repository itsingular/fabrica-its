using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ItsLaw.Entidades;
using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Infra;
using ItsLaw.WebAPI.Mobile;


namespace ItsLaw.WebAPI.Mobile.Controllers
{
    public class UsuarioRecuperarSenhaAPIController : ApiController
    {
        private readonly IUsuario _Usuario;
        GravaLogAPI _GravaLogAPI = new GravaLogAPI();

        public UsuarioRecuperarSenhaAPIController()
        {
            _Usuario = new UsuarioService();
        }


        //------------------------------------------------------------- Listar Todos
        // GET api/Alcada
        public string Get(string pGuid)
        {
            string bRetorno = "";            
            try
            {
                Usuario tabela = null;
                tabela = _Usuario.UsuarioPesquisar(x => x.CodigoAtivacao.ToString() == pGuid).FirstOrDefault();
                if (tabela != null)
                {
                    tabela.AtivoEmail = true;
                    _Usuario.UsuarioUpdate(tabela);

                    bRetorno = "It´s Law - Email Automatico:<br/><br/>" +
                               "Prezado(a) " + tabela.Apelido + ", <br><br>" +
                               "A sua nova senha para acessar o sistema<br><strong>Its´Law Gestão de Contencioso</strong> será: <br><br>" +
                               "                                             <br>" +
                               "Email:: " + tabela.Email.ToLower().Trim() + "<br>" +
                               "Senha:: " + "123456" + "                     <br>" +
                               "                                             <br>" +
                               "Atenciosamente,<br>" +
                               "<br>" +
                               "---------------------------------------<br>" +
                               "Equipe It's Law - Gestão de Contencioso";
                }
            }
            catch (Exception ex)
            {
                bRetorno = "/api/UsuarioRecuperarSenhaAPI - GET - Erro: " + ex.Message + " " + ex.InnerException;
            }
            
            return bRetorno;
        }

    }
}
