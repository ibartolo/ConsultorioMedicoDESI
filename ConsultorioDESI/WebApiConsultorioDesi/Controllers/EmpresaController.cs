using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Empresa")]
    public class EmpresaController : ApiController
    {
        public DbWrapper wrapper { get; set; }
        public EmpresaController()
        {
            wrapper = new DbWrapper();
        }

        [HttpGet]
        [Route("List")]
        public List<ObjEmpresa> GetAllEmpresa()
        {
            var response = wrapper.GetAllEmpresa();

            return response;
        }

        [HttpGet]
        [Route("{id:long}")]
        public ObjEmpresa GetEmpresaById(long id)
        {
            var response = wrapper.GetEmpresaById(id);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjEmpresa SaveOrUpdateEmpresa(ObjEmpresa obj)
        {
            var response = wrapper.SaveOrUpdateEmpresa(obj);
            return response;
        }
    }
}
