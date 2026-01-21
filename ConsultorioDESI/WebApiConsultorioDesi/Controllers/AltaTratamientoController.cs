using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Consultas;
using EntidadesConsultorioMedico.Relaciones;
using EntidadesConsultorioMedico.Requests;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/AltaTratamiento")]
    public class AltaTratamientoController : ApiController
    {
        public DbWrapper _db = new DbWrapper();

        [HttpGet]
        [Route("{id:long}")]
        public List<ObjAltaTratamientoShow> GetAltaTratamientoById(long id)
        {
            var response = _db.GetAltaTratamientoById(id);
            return response;
        }

        [HttpGet]
        [Route("List")]
        public List<ObjAltaTratamientoShow> GetAllAltaTratamiento()
        {
            var response = _db.GetAllAltaTratamiento();
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjAltaTratamientoRequest SaveOrUpdateAltaTratamiento(ObjAltaTratamientoRequest obj)
        {
            //esto devolvera el id del alta tratamiento
            var response = _db.SaveOrUpdateAltaTratamiento(obj.altaTratamiento);
            var tratamientosGuardados = new List<ObjAltaTratamientoCatalogo>();
            foreach (var item in obj.relaciones)
            {
                item.AltaTratamientoId = response.Id;
                var t = _db.SaveAltaTratamientoCatalogo(item);
                tratamientosGuardados.Add(t);
            }

            return new ObjAltaTratamientoRequest
            {
                altaTratamiento = response,
                relaciones = tratamientosGuardados
            };
        }
    }
}