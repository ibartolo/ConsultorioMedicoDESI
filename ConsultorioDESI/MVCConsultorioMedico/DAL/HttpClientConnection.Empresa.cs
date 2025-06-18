using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        public async Task<ObjEmpresa> SaveOrUpdateEmpresa(ObjEmpresa obj)
        {
            var response = await RequestAsync($"api/Empresa", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjEmpresa>((responseString) =>
                {
                    return JsonConvert.DeserializeObject<ObjEmpresa>(responseString);
                }));

            return response;
        }
    }
}