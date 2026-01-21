using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        public async Task<List<ObjAltaTratamiento>> GetALlAltaTratamiento()
        {
            var response = await RequestAsync($"api/AltaTratamiento/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, List<ObjAltaTratamiento>>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjAltaTratamiento>>(responseString);
                }));
            return response;
        }

        public async Task<ObjAltaTratamiento> GetAltaTratamientoById(long id)
        {
            var response = await RequestAsync($"api/AltaTratamiento/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjAltaTratamiento>(response);
        }

        public async Task<ObjAltaTratamientoRequest> SaveOrUpdateAltaTratamiento(ObjAltaTratamientoRequest obj)
        {
            MappingColumnSecurity(obj.altaTratamiento);

            foreach (var item in obj.relaciones)
            {
                MappingColumnSecurity(item);
            }

            var response = await RequestAsync($"api/AltaTratamiento", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjAltaTratamientoRequest>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjAltaTratamientoRequest>(responseString);
                }));
            return response;
        }
    }
}