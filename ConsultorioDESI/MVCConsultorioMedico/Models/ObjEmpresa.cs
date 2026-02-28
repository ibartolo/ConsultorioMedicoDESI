using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjEmpresa : BaseObject
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Representante { get; set; }
        public string TelContacto { get; set; }
        public string EmailContacto { get; set; }
    }
}