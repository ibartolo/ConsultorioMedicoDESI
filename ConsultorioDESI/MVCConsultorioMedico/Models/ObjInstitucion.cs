using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjInstitucion : BaseObject
    {
        public string Nombre { get; set; }
        public string NumeroTrabajadores { get; set; }
        public string TelefonoL1 { get; set; }
        public string TelefonoL2 { get; set; }
        public string Email { get; set; }
        public string Calle { get; set; }
        public string NumeroInterior { get; set; }
        public string NumeroExterior { get; set; }
        public string Colonia { get; set; }
        public string Delegacion { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string CodigoPostal { get; set; }
        public string Pais { get; set; }
    }
}