using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/TratamientoPaquete")]
    public class TratamientoPaqueteController : ApiController
    {
        DbWrapper dbwrapper = new DbWrapper();

        [HttpGet]
        [Route("GetByTratamiento/{idTratamiento:long}")]
        public List<ObjTratamientoPaquete> GetTratamientoPaqueteByTratamiento(long idTratamiento)
        {
            var response = dbwrapper.GetTratamientoPaqueteByTratamiento(idTratamiento);
            return response;
        }

        [HttpGet]
        [Route("GetByPaquete/{idPaquete:long}")]
        public List<ObjTratamientoPaquete> GetTratamientoPaqueteByPaquete(long idPaquete)
        {
            var response = dbwrapper.GetTratamientoPaqueteByPaquete(idPaquete);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjTratamientoPaquete SaveTratamientoPaquete(ObjTratamientoPaquete obj)
        {
            var response = dbwrapper.SaveTratamientoPaquete(obj);
            return response;
        }
    }
}