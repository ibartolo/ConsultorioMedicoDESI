using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models
{
    public class ObjTratamientoPaquete : BaseObject
    {
        public long PaqueteId { get; set; }
        public long TratamientoId { get; set; }

        public String Paquete { get; set; }
        public decimal Costo { get; set; }
        public String Tratamiento { get; set; }
        public int Duracion { get; set; }
    }
}