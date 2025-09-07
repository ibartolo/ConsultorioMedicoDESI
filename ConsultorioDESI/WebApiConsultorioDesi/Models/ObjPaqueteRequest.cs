using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models
{
    public class ObjPaqueteRequest
    {
        public ObjPaquete Paquete { get; set; }
        public List<ObjTratamientoPaquete> Tratamientos { get; set; }
    }
}