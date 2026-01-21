using EntidadesConsultorioMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Configuration;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class ConsultaController : BaseController
    {
        // GET: Consulta
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjConsulta obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetConsultaById(id);
            }
            else
            {
                obj = new ObjConsulta();
            }

            var ListaPacientes = await httpClientConnection.GetAllPaciente();
            ViewBag.ListaPacientes = new SelectList(ListaPacientes, "Id", "Nombre");

            string TiposConsulta = ConfigurationManager.AppSettings["TipoConsulta"];
            var TiposConsultaList = TiposConsulta.Split('|').Select(tc =>
            {
                var parts = tc.Split('_');
                return new SelectListItem
                {
                    Value = parts[1],
                    Text = parts[1]
                };
            }).ToList();

            ViewBag.TipoConsulta = TiposConsultaList;
            return View(obj);
        }

        public async Task<string> GetAllConsulta()
        {
            var response = await httpClientConnection.GetAllConsulta();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdateConsulta(ObjConsulta obj)
        {
            await httpClientConnection.SaveOrUpdateConsulta(obj);
            return Redirect("Index");
        }
    }
}