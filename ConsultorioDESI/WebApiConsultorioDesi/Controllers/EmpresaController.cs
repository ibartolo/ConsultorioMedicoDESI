using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        [Route("List")]
        public IHttpActionResult GetAllEmpresa()
        {
            new DbWrapper().GetAllEmpresa();

            return Ok();
        }
    }
}
