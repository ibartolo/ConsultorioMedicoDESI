using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class PaqueteController : BaseController
    {
        // GET: Paquete
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjPaquete obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetPaqueteById(id);
            }
            else
            {
                obj = new ObjPaquete();
            }
                return View(obj);
        }

        public async Task<string> GetAllPaquete()
        {
            var response = await httpClientConnection.GetAllPaquetes();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdatePaquete(ObjPaquete obj)
        {
            await httpClientConnection.SaveOrUpdatePaquete(obj);
            return Redirect("Index");
        }
    }
}