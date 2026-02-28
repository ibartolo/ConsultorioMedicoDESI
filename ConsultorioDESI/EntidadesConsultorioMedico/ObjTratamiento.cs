using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico
{
    public class ObjTratamiento : BaseObject
    {
        public string Nombre { get; set; }
        public int Duracion { get; set; }
        public string Descripcion { get; set; }
    }
}