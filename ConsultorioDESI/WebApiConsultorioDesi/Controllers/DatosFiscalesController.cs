using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/DatosFiscales")]

    public class DatosFiscalesController : ApiController
    {
        public DbWrapper dbwrapper { get; set; }

        public DatosFiscalesController()
        {
            dbwrapper = new DbWrapper();
        }

        //Obtener todos los datos fiscales
        [HttpGet]
        [Route("List")]
        public List<ObjDatosFiscales> GetAllDatosFiscales()
        {
            var response = dbwrapper.GetAllDatosFiscales();
            return response;
        }

        //obtener datos fiscales por id
        [HttpGet]
        [Route("{id:long}")]
        public ObjDatosFiscales GetDatosFiscalesById(long id)
        {
            var response = dbwrapper.GetDatosFiscalesById(id);
            return response;
        }

        //borrar datos fiscales
        [HttpPost]
        [Route("delete/{id:long}")]
        public IHttpActionResult DeleteDatosFiscales(long id)
        {
            dbwrapper.DeleteDatosFiscales(id);
            return Ok("El registro se ha borrado correctamente");
        }

        //Actualizar y guardar
        [HttpPost]
        [Route("")]
        public ObjDatosFiscales SaveOrUpdateDatosFiscales(ObjDatosFiscales datos)
        {
            var response = dbwrapper.SaveOrUpdateDatosFiscales(datos);
            return response;
        }
    }
}