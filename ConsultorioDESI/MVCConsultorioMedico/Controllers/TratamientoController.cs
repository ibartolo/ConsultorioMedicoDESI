using MVCConsultorioMedico.DAL;
using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCConsultorioMedico.Controllers
{
    public class TratamientoController : BaseController
    {
        HttpClientConnection _httpclientconnection = new HttpClientConnection();
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjTratamiento obj = null;

            if(id != 0)
            {
                obj = await _httpclientconnection.GetCatalogoTratamientoById(id);
            }
            else
            {
                obj = new ObjTratamiento();
            }
            
            return View(obj);
        }

        public async Task<string> GetAllCatalogoTratamiento()
        {
            var response = await _httpclientconnection.GetAllCatalogoTratamiento();
            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }

        public async Task<ActionResult> SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj)
        {
            obj.CreatedDt = DateTime.Now;
            obj.UpdatedDt = DateTime.Now;
            obj.CreatedBy = "Victor";
            obj.UpdatedBy = "Victor";
            await _httpclientconnection.SaveOrUpdateCatalogoTratamiento(obj);
            return Redirect("Index");
        }
    }
}