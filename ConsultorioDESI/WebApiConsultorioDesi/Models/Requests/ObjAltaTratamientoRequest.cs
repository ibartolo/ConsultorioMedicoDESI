using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiConsultorioDesi.Models.Relaciones;

namespace WebApiConsultorioDesi.Models.Requests
{
    public class ObjAltaTratamientoRequest : BaseObject
    {
        public ObjAltaTratamiento altaTratamiento { get; set; }
        public List<ObjAltaTratamientoCatalogo> relaciones { get; set; }
    }
}