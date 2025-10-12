using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models
{
    public class ObjAltaTratamiento : BaseObject
    {
        public long Paciente { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
    }
}