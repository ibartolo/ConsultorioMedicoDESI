using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.DAL;

namespace MVCConsultorioMedico.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public async Task<ActionResult> Index()
        {
            ObjEmpresa obj = new ObjEmpresa();
            obj = await new HttpClientConnection().GetEmpresaById(1);
            return View(obj);
        }
    }
}