using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultation.Proxy;
using Consultation.Domain;
using System.Data;
using Common.Domain;

namespace Consultation.Application
{
    public class ConsultationApp : IConsultationApp
    {
        private readonly IConsultationProxy _proxy;
        public ConsultationApp(IConsultationProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public IEnumerable<ConsultationObj> GetAllConsultations(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<ConsultationObj> response = new List<ConsultationObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllConsultations();
                response = ConsultationMapp.MappConsultation(responseDT) ?? new List<ConsultationObj>();
            }catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener las consultas" });
            }
            return response;
        }

        public ConsultationObj GetConsultationById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            ConsultationObj response = null;
            try
            {
                if (id <= 0) { throw new ArgumentException("El argumento debe ser mayor a cero.", nameof(id)); }
                DataTable responseDT = _proxy.GetConsultationById(id);
                response = ConsultationMapp.MappConsultation(responseDT).First();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion de la consulta." } );
            }
            return response;
        }
    }
}
