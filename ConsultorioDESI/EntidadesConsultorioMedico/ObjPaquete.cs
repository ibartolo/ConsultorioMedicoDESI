using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico
{
    public class ObjPaquete : BaseObject
    {
        public string NombrePaquete { get; set; }
        public decimal Costo { get; set; }
        public string Descripcion { get; set; }
    }
}