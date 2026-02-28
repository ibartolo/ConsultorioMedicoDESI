using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain;
using FiscalData.Domain;
using FiscalData.Proxy;

namespace FiscalData.Application
{
    public class FiscalDataApp : IFiscalDataApp
    {
        private readonly IFiscalDataProxy _proxy;

        public FiscalDataApp(IFiscalDataProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }
        
        public List<FiscalDataObj> GetAllFiscalData(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<FiscalDataObj> response = new List<FiscalDataObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllFiscalData();
                response = FiscalDataMapp.MappFiscalData(responseDT) ?? new List<FiscalDataObj>();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener los datos fiscales." });
            }
            return response;
        }

        public FiscalDataObj GetFiscalDataById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            FiscalDataObj obj = null;
            try
            {
                DataTable responseDT = _proxy.GetFiscalDataById(id);
                obj = FiscalDataMapp.MappFiscalData(responseDT).First();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion de los datos fiscales." });
            }
            return obj;
        }
    }
}
