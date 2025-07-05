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
        //Obtener paciente por ID
        public async Task<ObjPaciente> GetPacienteById(long id)
        {
            var response = await RequestAsync($"api/Paciente/{id}", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return JsonConvert.DeserializeObject<ObjPaciente>(response);
        }

        //Obtener todos los pacientes
        public async Task<List<ObjPaciente>> GetAllPaciente()
        {
            var response = await RequestAsync("api/Paciente/List", System.Net.Http.HttpMethod.Get, null,
                new Func<string, string>((responseString) =>
                {
                    return responseString;
                }));
            return JsonConvert.DeserializeObject<List<ObjPaciente>>(response);
        }
    
        //Guardar o actualizar paciente
        public async Task<ObjPaciente> SaveOrUpdatePaciente(ObjPaciente obj)
        {
            var response = await RequestAsync($"api/Paciente", System.Net.Http.HttpMethod.Post, obj,
                new Func<string, ObjPaciente>((responseString) =>
                {
                    return JsonConvert.DeserializeObject<ObjPaciente>(responseString);
                }));
            return response;
        }
    }
}