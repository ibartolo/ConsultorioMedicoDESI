using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.DAL;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class InstitucionController : BaseController
    {
        // GET: Institucion
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjInstitucion obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetInstitucionById(id);
            }
            else
            {
                obj = new ObjInstitucion();
            }
            return View(obj);
        }

        public async Task<string> GetAllInstituciones()
        {
            var response = await httpClientConnection.GetAllInstituciones();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdateInstitucion(ObjInstitucion obj)
        {
            await httpClientConnection.SaveOrUpdateInstitucion(obj);
            return Redirect("Index");
        }
    }
}