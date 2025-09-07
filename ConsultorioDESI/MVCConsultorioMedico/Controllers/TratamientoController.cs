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

            if (id != 0)
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




        //parte de TratamientoPaquete
        public async Task<ActionResult> IndexTP()
        {
            var listTratamiento = await httpClientConnection.GetAllCatalogoTratamiento(); //variable de elementos
            ViewBag.ListaTratamientos = new SelectList(listTratamiento, "Id", "Nombre");
            ViewBag.TratamientoPaquete = new ObjTratamientoPaquete();
            return View();
        }

        public async Task<string> GetTratamientoPaqueteByTratamiento(long tratamientoId = 0)
        {
            ObjTratamientoPaquete obj = null;

            if (tratamientoId != 0)
            {
                obj = await httpClientConnection.GetTratamientoPaqueteByTratamiento(tratamientoId);
            }
            else
            {
                obj = new ObjTratamientoPaquete();
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public async Task<string> GetTratamientoPaqueteByPaquete(long paqueteId = 0)
        {
            ObjTratamientoPaquete obj = null;

            if (paqueteId != 0)
            {
                obj = await httpClientConnection.GetTratamientoPaqueteByPaquete(paqueteId);
            }
            else
            {
                obj = new ObjTratamientoPaquete();
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        //Como enviamos un JSON es lo que recibimos en el controladores
        public async Task<ActionResult> SaveTratamientoPaquete(ObjPaqueteRequest obj){ //recibiendo un json paquete request

            await httpClientConnection.SaveTratamientoPaquete(obj);
            return Redirect("IndexTP");
        }
    }
}