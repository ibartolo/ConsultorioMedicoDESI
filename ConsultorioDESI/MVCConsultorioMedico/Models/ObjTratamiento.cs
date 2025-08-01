using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjTratamiento : BaseObject
    {
        public String Nombre { get; set; }
        public int Duracion { get; set; }
        public String Descripcion { get; set; }
    }
}