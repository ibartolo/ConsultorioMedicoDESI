using MVCConsultorioMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        //realizar la conexion con el api para obtener los tratamientos
        public async Task<List<ObjTratamiento>> GetAllCatalogoTratamiento()
        {
            var response = await RequestAsync($"api/Tratamiento/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjTratamiento>>(response);
        }

        public async Task<ObjTratamiento> GetCatalogoTratamientoById(long id)
        {
            var response = await RequestAsync($"api/Tratamiento/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return JsonConvert.DeserializeObject<ObjTratamiento>(response);
        }

        public async Task<ObjTratamiento> SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj)
        {
            var response = await RequestAsync($"api/Tratamiento", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjTratamiento>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjTratamiento>(responseString);
                }));
            return response;
        }
    }
}