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
using ItsLaw.Funcoes;


namespace ItsLaw.WebAPI.Mobile.Controllers
{
    public class DashBoardAPIController : ApiController
    {
        private readonly IProcesso _Processo;
        GravaLogAPI _GravaLogAPI = new GravaLogAPI();

        public DashBoardAPIController()
        {
            _Processo = new ProcessoService();
        }


        //------------------------------------------------------------- Listar Todos
        // GET api/Alcada
        public DashBoard Get(int pIDUsuario)
        {
            DashBoard tabela = null;
            if (pIDUsuario != 0)
            {
                try
                {
                    tabela  = _Processo.ProcessoDashBoard(pIDUsuario);                    
                }
                catch (Exception ex)
                {
                    _GravaLogAPI._GravaLog("/api/DashBoard - GET - Erro: " + ex.Message + " " + ex.InnerException);
                }
            }            
            return tabela;
        }
    }
}
