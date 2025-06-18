using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MVCConsultorioMedico.Models;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        public async Task<ObjEmpresa> GetEmpresaById(long id)
        {
            var response = await RequestAsync($"api/Empresa/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));

            return JsonConvert.DeserializeObject<ObjEmpresa>(response);
        }
    }
}