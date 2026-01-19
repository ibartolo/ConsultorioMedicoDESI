using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Package.Domain;
using SqlProxy;
using Microsoft.Data.SqlClient;

namespace Package.Proxy
{
    public class PackageProxy : DbWrapper, IPackageProxy
    {
        public DataTable GetAllPackages()
        {
            var r = GetObject("GetAllPaquete", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetPackageById(long id)
        {
            var parameter = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var r = GetObject("GetPaqueteById", CommandType.StoredProcedure, parameter);
            return r;
        }
    }
}
