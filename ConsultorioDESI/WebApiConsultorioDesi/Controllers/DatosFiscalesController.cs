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
    [RoutePrefix("api/DatosFiscales")]

    public class DatosFiscalesController : ApiController
    {
        public DbWrapper dbwrapper { get; set; }

        public DatosFiscalesController()
        {
            dbwrapper = new DbWrapper();
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
        [Route("saveorupdate")]
        public IHttpActionResult SaveOrUpdateDatosFiscales([FromBody] ObjDatosFiscales datos)
        {
            try
            {
                dbwrapper.SaveOrUpdateDatosFiscales(datos.Id, datos.RFC, datos.RazonSocial, datos.DireccionSocial, datos.Email, datos.Regimen, datos.EmpresaId, datos.CreatedBy, datos.CreatedDt, datos.UpdatedBy, datos.UpdatedDt.GetValueOrDefault());
                return Ok("La consulta se realizo con exito");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}