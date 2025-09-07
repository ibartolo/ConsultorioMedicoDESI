using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjPaqueteRequest : BaseObject
    {
        public ObjPaquete Paquete { get; set; }
        public List<ObjTratamientoPaquete> Tratamientos { get; set; }
    }
}