using EntidadesConsultorioMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection
    {
        public async Task<ObjConsulta> GetConsultaById(long id)
        {
            var response = await RequestAsync($"api/Consulta/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjConsulta>(response);
        }

        public async Task<List<ObjConsulta>> GetAllConsulta()
        {
            var response = await RequestAsync($"api/Consulta/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, List<ObjConsulta>>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ObjConsulta>>(responseString);
                }));
            return response;
        }

        public async Task<ObjConsulta> SaveOrUpdateConsulta(ObjConsulta obj)
        {
            MappingColumnSecurity(obj);
            var response = await RequestAsync($"api/Consulta", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjConsulta>((responseString) =>
                {
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjConsulta>(responseString);
                }));
            return response;
        }

        public async Task<long> GetAppointmentCountByDateRange(DateTime FechaInicial, DateTime FechaFinal)
        {
            var response = await RequestAsync($"api/Consulta/IndicadoresData?FechaInicial={FechaInicial.ToString("o")}&FechaFinal={FechaFinal.ToString("o")}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return long.Parse(response);
        }
    }
}