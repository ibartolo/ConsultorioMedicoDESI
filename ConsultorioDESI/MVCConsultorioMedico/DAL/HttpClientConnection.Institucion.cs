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
        public async Task<ObjInstitucion> GetInstitucionById(long id)
        {
            var response = await RequestAsync($"api/Institucion/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjInstitucion>(response);
        }

        public async Task<ObjInstitucion> SaveOrUpdateInstitucion(ObjInstitucion obj)
        {
            MappingColumnSecurity(obj);
            var response = await RequestAsync($"api/Institucion", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjInstitucion>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjInstitucion>(responseString);
                }));
            return response;
        }

        public async Task<List<ObjInstitucion>> GetAllInstituciones()
        {
            var response = await RequestAsync($"api/Institucion/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, List<ObjInstitucion>>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjInstitucion>>(responseString);
                }));
            return response;
        }
    }
}