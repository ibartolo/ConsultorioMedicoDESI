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
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjEmpresa obj = null;

            if (id != 0)
            {
                obj = await new HttpClientConnection().GetEmpresaById(id);
            }
            else
            {
                obj = new ObjEmpresa();
            }

            
            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdateEmpresa(ObjEmpresa obj)
        {
            obj.CreatedDt = DateTime.Now;
            obj.UpdatedDt = DateTime.Now;
            obj.CreatedBy = "Victor";
            obj.UpdatedBy = "Victor";

            await new HttpClientConnection().SaveOrUpdateEmpresa(obj);
            return Redirect("Index");
        }
    }
}