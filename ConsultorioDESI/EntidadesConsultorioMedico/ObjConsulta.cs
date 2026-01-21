using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico
{
    public class ObjConsulta : BaseObject
    {
        public long Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoConsulta { get; set; }
        public string Comentarios { get; set; }
    }
}