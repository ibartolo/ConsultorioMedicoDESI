using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.DAL;
using MVCConsultorioMedico.Models;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class DatosFiscalesController : BaseController
    {
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjDatosFiscales obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetDatosFiscalesById(id);
            }
            else
            {
                obj = new ObjDatosFiscales();
            }
                return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdateDatosFiscales(ObjDatosFiscales datos)
        {
            await httpClientConnection.SaveOrUpdateDatosFiscales(datos);
            return Redirect("Index");
        }

        public async Task<string> GetAllDatosFiscales()
        {
            var response = await httpClientConnection.GetAllDatosFiscales();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}