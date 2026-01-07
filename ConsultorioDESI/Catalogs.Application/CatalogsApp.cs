using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogs.Domain;
using Common.Domain;
using Catalogs.Proxy;

namespace Catalogs.Application
{
    //Aque vamos a hacer el manejo de error con try catch
    public class CatalogsApp : ICatalogsApp
    {
        private readonly ICatalogsProxy _proxy;

        //Constructor para inyeccion de dependencias
        public CatalogsApp(ICatalogsProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy)); //Estamos validando que no sea nulo
        }

        public IEnumerable<CatalogsObj> GetAllCompanies(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<CatalogsObj> response = new List<CatalogsObj>();
            try
            {
                //tengo que crear el mapeo en proxy
                DataTable responseDT = _proxy.GetAllCompanies();
                response = CatalogsMapp.MappCatalogs(responseDT) ?? new List<CatalogsObj>();
            }
            catch (Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener las soruces y fondos del participante." });
            }
            return response;
        }

        public CatalogsObj GetCompanyById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            CatalogsObj response = null;
            try
            {
                if (id <= 0){ throw new ArgumentException("El argumento debe ser mayor a cero.", nameof(id)); }
                DataTable responseDT = _proxy.GetCompanyById(id);
                response = CatalogsMapp.MappCatalogs(responseDT).First();
            }catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener la informacion del participante." });
            }
            return response;
        }

        //falta modificar el guardado y actualizacion
        //public CatalogsObj SaveOrUpdateCompany(CatalogsObj obj) 
        //{
           
        //}
    }
}
