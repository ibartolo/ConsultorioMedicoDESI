using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Institute.Domain;
using SqlProxy;
using Microsoft.Data.SqlClient;
namespace Institute.Proxy
{
    public class InstituteProxy : DbWrapper, IInstituteProxy
    {
        public DataTable GetAllInstitutions()
        {
            DataTable result = GetObject("GetAllInstituciones", CommandType.StoredProcedure);
            return result;
        }

        public DataTable GetInstitutionById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            DataTable result = GetObject($"GetInstitucionById", CommandType.StoredProcedure, parametros);
            return result;
        }
    }
}
