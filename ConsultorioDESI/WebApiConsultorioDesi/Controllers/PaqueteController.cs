using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Paquete")]
    public class PaqueteController : ApiController
    {
        public DbWrapper dbwrapper = new DbWrapper();

        [HttpGet]
        [Route("List")]
        public List<ObjPaquete> GetAllPaquete()
        {
            var response = dbwrapper.GetAllPaquete();
            return response;
        }

        [HttpGet]
        [Route("{id:long}")]
        public ObjPaquete GetPaqueteById(long id)
        {
            var response = dbwrapper.GetPaqueteById(id);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjPaquete SaveOrUpdatePaquete(ObjPaquete obj)
        {
            var response = dbwrapper.SaveOrUpdatePaquete(obj);
            return response;
        }
    }
}