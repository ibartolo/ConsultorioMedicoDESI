using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCConsultorioMedico.DAL;

namespace MVCConsultorioMedico.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public async Task<ActionResult> Index()
        {
            //especificar el metodo que voy a utilizar para obtener usuario por id

            ObjUsuario obj = new ObjUsuario();
            obj = await new HttpClientConnection().GetUsuarioById(2);
            return View(obj);
        }
    }
}
