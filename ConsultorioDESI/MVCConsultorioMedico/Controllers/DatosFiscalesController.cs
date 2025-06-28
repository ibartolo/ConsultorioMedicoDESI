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
        // GET: DatosFiscales
        public async Task<ActionResult> Index()
        {
            ObjDatosFiscales obj = new ObjDatosFiscales();
            
            obj = await httpClientConnection.GetDatosFiscalesById(2);

            return View(obj);
        }
    }
}