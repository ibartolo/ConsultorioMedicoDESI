using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MVCConsultorioMedico.Models;
using Newtonsoft.Json;

namespace MVCConsultorioMedico.DAL
{
    public partial class HttpClientConnection 
    {
        public async Task<ObjUsuario> GetUsuarioById(long id)
        {
            var response = await RequestAsync($"api/Usuario/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) => {
                return responseString;
            }));
            return JsonConvert.DeserializeObject<ObjUsuario>(response);
        }

        public async Task<ObjUsuario> SaveOrUpdateUsuario(ObjUsuario obj)
        {
            var response = await RequestAsync($"api/Usuario", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjUsuario>((responseString) => {
                    return JsonConvert.DeserializeObject<ObjUsuario>(responseString);
                }));
            return response;
        }
    }

    
}