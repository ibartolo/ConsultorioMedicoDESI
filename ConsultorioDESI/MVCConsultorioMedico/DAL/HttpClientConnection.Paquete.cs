using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        public async Task<List<ObjPaquete>> GetAllPaquetes()
        {
            var response = await RequestAsync($"api/Paquete/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, List<ObjPaquete>>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjPaquete>>(responseString);
                }));
            return response;
        }

        public async Task<ObjPaquete> GetPaqueteById(long id)
        {
            var response = await RequestAsync($"api/Paquete/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjPaquete>(response);
        }

        public async Task<ObjPaquete> SaveOrUpdatePaquete(ObjPaquete obj)
        {
            MappingColumnSecurity(obj);
            var response = await RequestAsync($"api/Paquete", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjPaquete>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjPaquete>(responseString);
                }));
            return response;
        }
    }
}