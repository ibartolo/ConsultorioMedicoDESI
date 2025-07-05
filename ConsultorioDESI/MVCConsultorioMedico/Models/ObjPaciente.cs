using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjPaciente : BaseObject
    {
        public String Nombre { get; set; }
        public String ApellidoP { get; set; }
        public String ApellidoM { get; set; }
        public int Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public String Comentario { get; set; }
    }
}