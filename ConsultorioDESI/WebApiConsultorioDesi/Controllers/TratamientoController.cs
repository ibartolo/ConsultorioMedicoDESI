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
    [RoutePrefix("api/Tratamiento")]

    public class TratamientoController : ApiController
    {
        public DbWrapper dbwrapper { get; set; }
        public TratamientoController()
        {
            dbwrapper = new DbWrapper();
        }

        [HttpGet]
        [Route("List")]
        public List<ObjTratamiento> GetAllCatalogoTratamiento()
        {
            var response = dbwrapper.GetAllCatalogoTratamiento();
            return response;
        }

        [HttpGet]
        [Route("{id:long}")]
        public ObjTratamiento GetCatalogoTratamientoById(long id)
        {
            var response = dbwrapper.GetCatalogoTratamientoById(id);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjTratamiento SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj)
        {
            var response = dbwrapper.SaveOrUpdateCatalogoTratamiento(obj);
            return response;
        }
    }
}