using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;

namespace WebApiConsultorioDesi.Models
{
    public class ObjDatosFiscales : BaseObject
    {
        public long Id { get; set; }
        public String RFC { get; set; }
        public String RazonSocial { get; set; }
        public String DireccionSocial { get; set; }
        public String Email { get; set; }
        public String Regimen { get; set; }
        public long EmpresaId { get; set; }

    }
}