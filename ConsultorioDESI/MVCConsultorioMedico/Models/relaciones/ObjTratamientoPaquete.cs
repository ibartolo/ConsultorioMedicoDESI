using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models
{
    public class ObjTratamientoPaquete : BaseObject
    {
        public long PaqueteId { get; set; }
        public long TratamientoId { get; set; }
    }
}