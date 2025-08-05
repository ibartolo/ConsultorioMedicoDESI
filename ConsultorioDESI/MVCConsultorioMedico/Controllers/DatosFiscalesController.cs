using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.DAL;
using MVCConsultorioMedico.Models;

namespace MVCConsultorioMedico.Controllers
{
    public class DatosFiscalesController : BaseController
    {
        public HttpClientConnection _httpclientconnection = new HttpClientConnection();
        // GET: DatosFiscales
        public async Task<ActionResult> Index()
        {
            ObjDatosFiscales obj = new ObjDatosFiscales();
            
            obj = await _httpclientconnection.GetDatosFiscalesById(2);

            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdateDatosFiscales(ObjDatosFiscales datos)
        {
            await _httpclientconnection.SaveOrUpdateDatosFiscales(datos);
            return Redirect("Index");
        }

        public async Task<string> GetAllDatosFiscales()
        {
            var response = await _httpclientconnection.GetAllDatosFiscales();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}