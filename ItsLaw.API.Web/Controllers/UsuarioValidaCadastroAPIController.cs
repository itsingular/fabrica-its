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
using ItsLaw.Funcoes;
using ItsLaw.WebAPI.Mobile;


namespace ItsLaw.WebAPI.Mobile.Controllers
{
    public class UsuarioValidaCadastroAPIController : ApiController
    {
        private readonly IUsuario _Usuario;
        private string glbWebAPI_Servidor = ItsLawFuncoes._ServidorWebAPI_Caminho();

        GravaLogAPI _GravaLogAPI = new GravaLogAPI();

        public UsuarioValidaCadastroAPIController()
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
                               "Seja bem vindo(a) ao sistema<br><strong>Its´Law Gestão de Contencioso</strong>.<br/><br/>" +
                               "Seu cadastro foi <strong>confirmado</strong><br/><br/>" +
                               "                                     " +
                               "Clique para acessar o sistema:   <br>" +
                               "" + glbWebAPI_Servidor       + " <br>" +
                               "                                 <br>" +
                               "                                 <br>" +
                               "Atenciosamente,<br>" +
                               "<br>" +
                               "---------------------------------------<br>" +
                               "Equipe It's Law - Gestão de Contencioso";
                }
            }
            catch (Exception ex)
            {
                bRetorno = "/api/UsuarioValidaCadastroAPI - GET - Erro: " + ex.Message + " " + ex.InnerException;
                _GravaLogAPI._GravaLogAsync(bRetorno);
            }
            
            return bRetorno;
        }

    }
}
