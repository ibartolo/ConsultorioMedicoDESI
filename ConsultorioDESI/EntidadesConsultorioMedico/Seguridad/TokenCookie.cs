using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesConsultorioMedico.Seguridad
{
	public class TokenCookie
	{
        public Token Token { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
    }
}