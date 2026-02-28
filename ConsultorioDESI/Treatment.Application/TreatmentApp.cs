using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using Treatment.Domain;
using Treatment.Proxy;

namespace Treatment.Application
{
    public class TreatmentApp : ITreatmentApp
    {
        private readonly ITreatmentProxy _proxy;
        public TreatmentApp(ITreatmentProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public List<TreatmentObj> GetAllTreatments(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<TreatmentObj> response = new List<TreatmentObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllTreatments();
                response = TreatmentMapp.MappTreatment(responseDT) ?? new List<TreatmentObj>();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener los tratamientos." });
            }
            return response;
        }

        public TreatmentObj GetTreatmentById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            TreatmentObj obj = null;
            try
            {
                DataTable responseDT = _proxy.GetTreatmentById(id);
                obj = TreatmentMapp.MappTreatment(responseDT).First(); 
            }catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion del tratamiento." });
            }
            return obj;
        }
    }
}
