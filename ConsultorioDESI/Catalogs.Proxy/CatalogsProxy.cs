using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProxy;

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
            DataTable result = GetObject($"GetEmpresaById/{id}", CommandType.StoredProcedure);
            return result;
        }
    }
}
