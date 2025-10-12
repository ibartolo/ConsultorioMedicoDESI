using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsultorioMedico.Models.relaciones
{
    public class ObjAltaTratamientoCatalogo : BaseObject
    {
        public long AltaTratamientoId { get; set; }
        public long TratamientoId { get; set; }
    }
}