using Common.Domain;
using Package.Domain;
using Package.Proxy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Application
{
    public class PackageApp : IPackageApp
    {
        private IPackageProxy _proxy;

        public PackageApp(IPackageProxy proxy)
        {
            _proxy = proxy ?? throw new ArgumentNullException(nameof(proxy));
        }

        public List<PackageObj> GetAllPackages(out OperationResult result)
        {
            result = new() { Successful = true, SystemMessages = new List<SystemMessage>() };
            List<PackageObj> response = null;
            try
            {
                DataTable responseDT = _proxy.GetAllPackages();
                response = PackageMapp.MappPackage(responseDT) ?? new List<PackageObj>();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage() { Message = "Ocurrio un error al obtener todos los paquetes." });
            }
            return response;
        }

        public PackageObj GetPackageById(long id, out OperationResult result)
        {
            result = new() { Successful = true };
            PackageObj response = null;
            try
            {
                DataTable responseDT = _proxy.GetPackageById(id);
                response = PackageMapp.MappPackage(responseDT).First();
            }
            catch(Exception ex)
            {
                result.Successful = false;
                if (result.SystemMessages == null)
                    result.SystemMessages = new List<SystemMessage>();
                result.SystemMessages.Add(new SystemMessage { Message = "Ocurrio un error al obtener el paquete." });
            }
            return response;
        }
    }
}
