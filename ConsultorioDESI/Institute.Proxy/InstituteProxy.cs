using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institute.Domain;
using SqlProxy;
namespace Institute.Proxy
{
    public class InstituteProxy : DbWrapper, IInstituteProxy
    {
        public DataTable GetAllInstitutions()
        {
            DataTable result = GetObject("GetAllInstituciones", System.Data.CommandType.StoredProcedure);
            return result;
        }

        public DataTable GetInstitutionById(long id)
        {
            DataTable result = GetObject($"GetInstitucionById{id}", System.Data.CommandType.StoredProcedure);
            return result;
        }
    }
}
