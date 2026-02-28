using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico.Consultas
{
    public class ObjConsultaShow : BaseObject
    {
        public string Paciente { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string TipoConsulta { get; set; }
        public string Comentarios { get; set; }
    }
}