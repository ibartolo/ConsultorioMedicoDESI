using Catalogs.Proxy;
using Common.Domain;
using Institute.Domain;
using Institute.Proxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institutions.Application
{
    //debemos realizar un mapeo de DataTable a InstituteObj
    public class InstituteApp : IInstituteApp
    {
        private readonly IInstituteProxy _proxy;

        public InstituteApp(IInstituteProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public IEnumerable<InstituteObj> GetAllInstitutions(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<InstituteObj> response = new List<InstituteObj>();
            try
            {
                DataTable responseDT = _proxy.GetAllInstitutions();
                response = InstituteMapp.MappInstitute(responseDT) ?? new List<InstituteObj>();
            }catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener las instituciones." });
            }
            return response;
        }

        public InstituteObj GetInstitutionById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            InstituteObj response = null;
            try
            {
                if (id <= 0) { throw new ArgumentException("El argumento debe ser mayor a cero.", nameof(id)); }
                DataTable responseDT = _proxy.GetInstitutionById(id);
                response = InstituteMapp.MappInstitute(responseDT).First();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if(result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion de la institucion." });
            }
            return response;
        }
    }
}
