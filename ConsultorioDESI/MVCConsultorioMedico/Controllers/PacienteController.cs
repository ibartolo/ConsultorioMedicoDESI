using EntidadesConsultorioMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.DAL;
using System.Configuration;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class PacienteController : BaseController
    {
        // GET: Paciente (funcion asincrona)
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjPaciente obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetPacienteById(id);
            }
            else
            {
                obj = new ObjPaciente();
            }

            string generos = ConfigurationManager.AppSettings["Generos"];
            var generosList = generos.Split('|').Select(g =>
            {
                var parts = g.Split('_');
                return new SelectListItem
                {
                    Value = parts[0],
                    Text = parts[1]
                };
            }).ToList();


            ViewBag.Genero = generosList;
            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdatePaciente(ObjPaciente obj)
        {
            await httpClientConnection.SaveOrUpdatePaciente(obj);
            return Redirect("Index");
        }

        public async Task<string> GetAllPacientes()
        {
            var response = await httpClientConnection.GetAllPaciente();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<string> GetPacienteById(long id)
        {
            var response = await httpClientConnection.GetPacienteById(id);
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}