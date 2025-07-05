using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.DAL;

namespace MVCConsultorioMedico.Controllers
{
    public class PacienteController : BaseController
    {
        HttpClientConnection _httpclientconnection = new HttpClientConnection();
        // GET: Paciente (funcion asincrona)
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjPaciente obj = null;

            if(id != 0)
            { 
                obj = await _httpclientconnection.GetPacienteById(id);
            }
            else
            {
                obj = new ObjPaciente();
            }

            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdatePaciente(ObjPaciente obj)
        {
            obj.FechaNacimiento = DateTime.Now;
            obj.FechaRecepcion = DateTime.Now;
            obj.CreatedDt = DateTime.Now;
            obj.UpdatedDt = DateTime.Now;
            obj.CreatedBy = "Victor";
            obj.UpdatedBy = "Victor";
            await _httpclientconnection.SaveOrUpdatePaciente(obj);
            return Redirect("Index");
        }
    }
}