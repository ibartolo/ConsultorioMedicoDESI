using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using EntidadesConsultorioMedico;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico.Consultas;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Consulta")]
    public class ConsultaController : ApiController
    {
        public DbWrapper _db = new DbWrapper();

        [HttpGet]
        [Route("{id:long}")]
        public ObjConsultaShow GetConsultaById(long id)
        {
            var response = _db.GetConsultaById(id);
            return response;
        }

        [HttpGet]
        [Route("List")]
        public List<ObjConsultaShow> GetAllConsultas()
        {
            var response = _db.GetAllConsulta();
            return response;
        }

        [HttpPost]
        [Route("")]
        public ObjConsulta SaveOrUpdateConsulta(ObjConsulta obj)
        {
            var response = _db.SaveOrUpdateConsulta(obj);
            return response;
        }

        [HttpGet]
        [Route("IndicadoresData")]
        public long GetConsultasCountByDateRange(DateTime FechaInicial, DateTime FechaFinal)
        {
            var response = _db.GetAppointmentCountByDateRange(FechaInicial, FechaFinal);
            return response;
        }
    }
}