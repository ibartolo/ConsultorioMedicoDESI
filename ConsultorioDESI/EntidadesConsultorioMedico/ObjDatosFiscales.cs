using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico
{
    public class ObjDatosFiscales : BaseObject
    {
        public string RFC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Regimen { get; set; }
        public long EmpresaId { get; set; }
    }
}