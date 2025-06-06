using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiConsultorioDesi.Models
{
    public class ObjUsuario : BaseObject
    {
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}