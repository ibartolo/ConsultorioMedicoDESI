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
        public List<ObjRelacionTP> GetTratamientoPaqueteByTratamiento(long idTratamiento)
        {
            var response = dbwrapper.GetTratamientoPaqueteByTratamiento(idTratamiento);
            return response;
        }

        [HttpGet]
        [Route("GetByPaquete/{idPaquete:long}")]
        public List<ObjRelacionTP> GetTratamientoPaqueteByPaquete(long idPaquete)
        {
            var response = dbwrapper.GetTratamientoPaqueteByPaquete(idPaquete);
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjPaqueteRequest SaveTratamientoPaquete([FromBody] ObjPaqueteRequest obj)
        {
            var paqueteGuardado = dbwrapper.SaveOrUpdatePaquete(obj.Paquete);

            // Guardar los tratamientos asociados
            var tratamientosGuardados = new List<ObjTratamientoPaquete>();
            foreach (var item in obj.Tratamientos)
            {
                item.PaqueteId = paqueteGuardado.Id;
                var t = dbwrapper.SaveTratamientoPaquete(item); //ya enviamos los objetos de tratamiento paquete
                tratamientosGuardados.Add(t);
            }

            // Regresar el paquete con sus tratamientos ya guardados
            return new ObjPaqueteRequest
            {
                Paquete = paqueteGuardado,
                Tratamientos = tratamientosGuardados
            };
        }
    }
}