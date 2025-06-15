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
    public class DatosFiscalesController : Controller
    {
        // GET: DatosFiscales
        public async Task<ActionResult> Index()
        {
            ObjDatosFiscales obj = new ObjDatosFiscales();
            obj = await new HttpClientConnection().GetDatosFiscalesById(2);

            return View(obj);
        }
    }
}