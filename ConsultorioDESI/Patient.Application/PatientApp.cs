using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Patient.Proxy;
using Patient.Domain;
using System.Data;
namespace Patient.Application
{
    public class PatientApp : IPatientApp
    {
        private readonly IPatientProxy _proxy;
        
        public PatientApp(IPatientProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public IEnumerable<PatientObj> GetAllPatients(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<PatientObj> response = new List<PatientObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllPatients();
                response = PatientMapp.MappPatient(responseDT) ?? new List<PatientObj>();
            }catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener los pacientes." });
            }
            return response;
        }

        public PatientObj GetPatientById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            PatientObj obj = null;

            try
            {
                if (id <= 0) { throw new ArgumentException("El argumento debe ser mayor a cero.", nameof(id)); }
                DataTable responseDT = _proxy.GetPatientById(id);
                var response = PatientMapp.MappPatient(responseDT).First();
            }catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion del paciente." });
            }
            return obj;
        }
    }
}
