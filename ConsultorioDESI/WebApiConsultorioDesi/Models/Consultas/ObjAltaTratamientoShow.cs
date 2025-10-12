using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models.Consultas
{
    public class ObjAltaTratamientoShow : BaseObject
    {
        public string Paciente { get; set; } 
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Tratamiento { get; set; }
    }
}