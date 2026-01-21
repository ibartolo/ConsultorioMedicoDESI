using MVCConsultorioMedico.Helpers;
using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection : HttpClienBase
    {
        public BaseObject MappingColumnSecurity(BaseObject bo)
        {
            if (bo.Id == 0)
            {
                bo.CreatedBy = SessionHelper.GetSessionUser().UserName;
                bo.CreatedDt = DateTime.Now;
            }
            else
            {
                //error de guardado
                bo.UpdatedBy = SessionHelper.GetSessionUser().UserName;
                bo.UpdatedDt = DateTime.Now;
            }

            return bo;
        }

        public async Task<Token> GetToken(string userName, string pass)
        {
            var tokenResponse = await TokenAsync<Token>("token",
                new[]
                {
                    new KeyValuePair<string, string>("grant_type","password"),
                    new KeyValuePair<string, string>("username",userName),
                    new KeyValuePair<string, string>("password",pass)
                }, "application/x-www-form-urlencoded");

            return tokenResponse;
        }
    }
}