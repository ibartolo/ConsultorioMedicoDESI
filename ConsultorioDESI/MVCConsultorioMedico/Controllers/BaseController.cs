using MVCConsultorioMedico.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCConsultorioMedico.Controllers
{
    public class BaseController : Controller
    {
        public HttpClientConnection httpClientConnection { get; set; }
        public BaseController()
        {
            httpClientConnection = new HttpClientConnection();
        }
    }
}