using MVCConsultorioMedico.DAL;
using MVCConsultorioMedico.Models;
using MVCConsultorioMedico.Models.Seguridad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static MVCConsultorioMedico.Helpers.FilterHerlper;

namespace MVCConsultorioMedico.Controllers
{
    public class HomeController : Controller
    {
        #region Ventanas
        [Autenticated]
        public ActionResult Index()
        {
            return View();
        }
        [NoAutenticated]
        public ActionResult LogIn()
        {
            return View();
        }
        #endregion

        #region Acceso a datos

        public async Task<string> Autenticacion(string userName, string pass)
        {
            var tokenResponse = await new HttpClientConnection().GetToken(userName, pass);
            tokenResponse.ExpirationDate = DateTime.Now.AddSeconds(tokenResponse.expires_in);
            TokenCookie tokenCookie = new TokenCookie()
            { 
                Token = tokenResponse,
                UserID = 1,
                UserName = userName
            };
            Helpers.SessionHelper.CreateSession(JsonConvert.SerializeObject(tokenCookie));

            return JsonConvert.SerializeObject(tokenResponse);
        }

        #endregion
    }
}