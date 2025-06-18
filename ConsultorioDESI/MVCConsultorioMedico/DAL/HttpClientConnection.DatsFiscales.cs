using MVCConsultorioMedico.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCConsultorioMedico.DAL
{
	public partial class HttpClientConnection
    {
        public async Task<ObjDatosFiscales> GetDatosFiscalesById(long id)
        {
            var response = await RequestAsync($"api/DatosFiscales/{id}", System.Net.Http.HttpMethod.Get, null, 
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));

            return JsonConvert.DeserializeObject<ObjDatosFiscales>(response);
        }
    }
}