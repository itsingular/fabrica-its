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


namespace ItsLaw.API.Web.Controllers
{
    public class LogController : ApiController
    {
        GravaLogAPI _GravaLogAPI = new GravaLogAPI();

        // GET: Log
        public async System.Threading.Tasks.Task GetAsync() => await _GravaLogAPI._GravaLogAsync("Log GET Home ===============================================================================================================");

      //public async Task GetAsync()
      //{
      //    await _GravaLogAPI._GravaLogAsync("GET Home ==================================================================================================================");
      //}

    }
}