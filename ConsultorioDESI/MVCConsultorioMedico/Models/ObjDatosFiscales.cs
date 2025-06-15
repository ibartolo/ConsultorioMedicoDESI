using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;

namespace MVCConsultorioMedico.Models
{
    public class ObjDatosFiscales
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