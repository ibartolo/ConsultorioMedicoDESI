using MVCConsultorioMedico.DAL;
using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class TratamientoController : BaseController
    {
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjTratamiento obj = null;

            if(id != 0)
            {
                obj = await httpClientConnection.GetCatalogoTratamientoById(id);
            }
            else
            {
                obj = new ObjTratamiento();
            }
            
            return View(obj);
        }

        public async Task<string> GetAllCatalogoTratamiento()
        {
            var response = await httpClientConnection.GetAllCatalogoTratamiento();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj)
        {
            await httpClientConnection.SaveOrUpdateCatalogoTratamiento(obj);
            return Redirect("Index");
        }
    }
}