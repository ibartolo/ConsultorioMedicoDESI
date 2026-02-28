using MVCConsultorioMedico.DAL;
using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Seguridad;
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
    public class HomeController : BaseController
    {
        #region Ventanas
        [Autenticated]
        public async Task<ActionResult> Index()
        {
            //Obtener el primer dia del mes actual
            DateTime fechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //Obtener el ultimo día del mes actual = Obtenemos el mes, año actual y el primer dia, le sumamos un mes y le restamos un día
            DateTime fechaFinal = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            var TotalPacientes = await httpClientConnection.GetPatientsCountByDateRange(fechaInicial, fechaFinal);
            ViewBag.TotalPacientes = TotalPacientes;

            var TotalCitas = await httpClientConnection.GetAppointmentCountByDateRange(fechaInicial, fechaFinal);
            ViewBag.TotalCitas = TotalCitas;

            //Obtener los pacientes y citas del mes anterior para sacar el porcentaje de crecimiento del mes actual
            DateTime fechaInicialAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            DateTime fechaFinalAnterior = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            var TotalPacientesAnterior = await httpClientConnection.GetPatientsCountByDateRange(fechaInicialAnterior, fechaFinalAnterior);
            var TotalCitasAnterior = await httpClientConnection.GetAppointmentCountByDateRange(fechaInicialAnterior, fechaFinalAnterior);

            //var resultadoPaciente = ((TotalPacientes - TotalPacientesAnterior) * 100) / TotalPacientes;
            //ViewBag.PorcentajePacientes = resultadoPaciente;

            //var resultadoCitas = ((TotalCitas - TotalCitasAnterior) * 100) / TotalCitas;
            //ViewBag.PorcentajeCitas = resultadoCitas;
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