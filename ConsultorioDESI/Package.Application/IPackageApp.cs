using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Package.Domain;
using Common.Domain;

namespace Package.Application
{
    public interface IPackageApp
    {
        List<PackageObj> GetAllPackages(out OperationResult result);
        PackageObj GetPackageById(long id, out OperationResult result);
    }
}
