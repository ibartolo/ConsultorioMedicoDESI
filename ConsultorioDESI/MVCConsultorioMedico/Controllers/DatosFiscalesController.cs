using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.Models;

namespace MVCConsultorioMedico.Controllers
{
    public class DatosFiscalesController : Controller
    {
        // GET: DatosFiscales
        public ActionResult Index()
        {
            ObjDatosFiscales obj = new ObjDatosFiscales();
            obj.Id = 1;
            obj.RFC = "134254";
            obj.RazonSocial = "Hola";
            obj.DireccionSocial = "alamo";
            obj.Email = "example@example.com";
            obj.Regimen = "TechWhise";
            obj.EmpresaId = 1;
            return View(obj);
        }
    }
}