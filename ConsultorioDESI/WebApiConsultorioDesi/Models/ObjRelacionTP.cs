using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models
{
    public class ObjRelacionTP : BaseObject
    {
        public String Paquete { get; set; }
        public decimal Costo { get; set; }
        public String Tratamiento { get; set; }
        public int Duracion { get; set; }   
    }
}