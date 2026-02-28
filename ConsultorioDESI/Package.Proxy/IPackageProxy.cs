using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Package.Proxy
{
    public interface IPackageProxy
    {
        DataTable GetAllPackages();
        DataTable GetPackageById(long id);
    }
}
