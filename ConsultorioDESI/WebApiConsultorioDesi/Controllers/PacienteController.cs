using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;
using System.Web;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Paciente")]

    public class PacienteController : ApiController
    {
        DbWrapper dbwrapper { get; set; }

        public PacienteController()
        {
            dbwrapper = new DbWrapper();
        }


        [HttpGet]
        [Route("List")]
        public List<ObjPaciente> GetAllPaciente()
        {
            var response = dbwrapper.GetAllPaciente();
            return response.ToList();
        }

        [HttpGet]
        [Route("{id:long}")]
        public ObjPaciente GetPacienteById(long id)
        {
            var response = dbwrapper.GetPacienteById(id);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjPaciente SaveOrUpdatePaciente(ObjPaciente obj)
        {
            var response = dbwrapper.SaveOrUpdatePaciente(obj);
            return response;
        }
    }
}
