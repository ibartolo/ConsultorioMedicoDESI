using EntidadesConsultorioMedico.Relaciones;
using EntidadesConsultorioMedico.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        //Parte de TratamientoPaquete
        public async Task<ObjTratamientoPaquete> GetTratamientoPaqueteByTratamiento(long tratamientoId)
        {
            var response = await RequestAsync($"api/TratamientoPaquete/GetByTratamiento/{tratamientoId}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjTratamientoPaquete>(response);
        }

        public async Task<ObjTratamientoPaquete> GetTratamientoPaqueteByPaquete(long paqueteId)
        {
            var response = await RequestAsync($"api/TratamientoPaquete/GetByPaquete/{paqueteId}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjTratamientoPaquete>(response);
        }

        //public async Task<ObjTratamientoPaquete> SaveTratamientoPaquete(ObjTratamientoPaquete obj)
        //{
        //    MappingColumnSecurity(obj);
        //    var response = await RequestAsync($"api/TratamientoPaquete", System.Net.Http.HttpMethod.Post, obj,
        //        new Func<string, ObjTratamientoPaquete>((responseString) =>
        //        {
        //            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjTratamientoPaquete>(responseString);
        //        }));
        //    return response;
        //}

        public async Task<ObjPaqueteRequest> SaveTratamientoPaquete(ObjPaqueteRequest obj)
        {
            MappingColumnSecurity(obj.Paquete);

            foreach (var t in obj.Tratamientos)
            {
                MappingColumnSecurity(t);
            }

            var response = await RequestAsync($"api/TratamientoPaquete", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjPaqueteRequest>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjPaqueteRequest>(responseString);
                }));
            return response;
        }

    }
}