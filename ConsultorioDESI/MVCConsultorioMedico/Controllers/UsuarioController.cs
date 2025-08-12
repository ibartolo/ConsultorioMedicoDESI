using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static MVCConsultorioMedico.Helpers.FilterHerlper;
namespace MVCConsultorioMedico.Controllers
{
    [Autenticated]
    public class UsuarioController : BaseController
    {
        // GET: Usuario
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjUsuario obj = null;

            if (id != 0)
            {
                obj = await httpClientConnection.GetUsuarioById(id);
            }
            else
            {
                obj = new ObjUsuario();
            }

            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdateUsuario(ObjUsuario obj)
        {
            await httpClientConnection.SaveOrUpdateUsuario(obj);
            return Redirect("Index");
        }

        public async Task<string> GetAllUsuario()
        {
            var response = await httpClientConnection.GetAllUsuario();

            return Newtonsoft.Json.JsonConvert.SerializeObject(response);
        }
    }
}
