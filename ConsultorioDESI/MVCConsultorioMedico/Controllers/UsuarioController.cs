using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCConsultorioMedico.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public async Task<ActionResult> Index(long id = 0)
        {
            ObjUsuario obj = null;

            if (id != 0)
            {
                obj = await new HttpClientConnection().GetUsuarioById(id);
            }
            else
            {
                obj = new ObjUsuario();
            }

            return View(obj);
        }

        public async Task<ActionResult> SaveOrUpdateUsuario(ObjUsuario obj)
        {
            obj.CreatedDt = DateTime.Now;
            obj.UpdatedDt = DateTime.Now;
            obj.CreatedBy = "Victor";
            obj.UpdatedBy = "Victor";

            await new HttpClientConnection().SaveOrUpdateUsuario(obj);
            return Redirect("Index");
        }
    }
}
