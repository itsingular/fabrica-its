using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ItsLaw.Entidades;
using ItsLaw.Business;
using ItsLaw.Business.Interfaces;
using ItsLaw.Infra;
using ItsLaw.WebAPI.Mobile;


namespace ItsLaw.WebAPI.Mobile.Controllers
{
    public class UsuarioLoginAPIController : ApiController
    {
        private readonly IUsuario _Usuario;
        GravaLogAPI _GravaLogAPI = new GravaLogAPI();

        public UsuarioLoginAPIController()
        {
            _Usuario = new UsuarioService();
        }


        //------------------------------------------------------------- Listar Todos
        // GET api/Alcada
        public Usuario Get(string pEmail)
        {
            Usuario tabela = null;
            {
                try
                {
                    tabela = _Usuario.UsuarioPesquisar(x => x.Email == pEmail).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    _GravaLogAPI._GravaLogAsync("/api/UsuarioLoginAPI - GET - Erro: " + ex.Message + " " + ex.InnerException);
                }
            }
            return tabela;
        }

    }
}
