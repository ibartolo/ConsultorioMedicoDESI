using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProxy;
using Microsoft.Data.SqlClient;

namespace Catalogs.Proxy
{
    public class CatalogsProxy : DbWrapper, ICatalogsProxy
    {
        public DataTable GetAllCompanies()
        {
            DataTable dt = GetObject("GetAllEmpresa", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetCompanyById(long id)
        {
            var parametro = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            DataTable result = GetObject("GetEmpresaById", CommandType.StoredProcedure, parametro);
            return result;
        }
    }
}
