using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.Models.Requests;
using MVCConsultorioMedico.Models.relaciones;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class AltaTratamientoController : BaseController
    {
        // GET: AltaTratamiento
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjAltaTratamiento obj = null;
            if(id != 0)
            {
                obj = await httpClientConnection.GetAltaTratamientoById(id);
            }
            else
            {
                obj = new ObjAltaTratamiento();
            }

            var ListaTratamientos = await httpClientConnection.GetAllCatalogoTratamiento();
            ViewBag.ListaTratamientos = new SelectList(ListaTratamientos, "Id", "Nombre");

            var ListaPacientes = await httpClientConnection.GetAllPaciente();
            ViewBag.ListaPacientes = new SelectList(ListaPacientes, "Id", "Nombre");
            return View(obj);
        }

        public async Task<string> GetAllAltaTratamiento()
        {
            var response = await httpClientConnection.GetALlAltaTratamiento();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdateAltaTratamiento(ObjAltaTratamientoRequest obj)
        { 
            await httpClientConnection.SaveOrUpdateAltaTratamiento(obj);
            return Redirect("Index");
        }
    }
}