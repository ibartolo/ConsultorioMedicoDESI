using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.DAL;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class EmpresaController : BaseController
    {
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjEmpresa obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetEmpresaById(id);
            }
            else
            {
                obj = new ObjEmpresa();
            }
            return View(obj);
        }
        public async Task<ActionResult> SaveOrUpdateEmpresa(ObjEmpresa obj)
        {
            await httpClientConnection.SaveOrUpdateEmpresa(obj);
            return Redirect("Index");
        }
        public async Task<string> GetAllEmpresas()
        {
            var response = await httpClientConnection.GetAllEmpresa();

            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}