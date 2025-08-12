using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjPaquete : BaseObject
    {
        public String NombrePaquete { get; set; }
        public decimal Costo { get; set; }
        public String Descripcion { get; set; }

    }
}