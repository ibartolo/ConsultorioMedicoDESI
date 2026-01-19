using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SqlProxy;

namespace Treatment.Proxy
{
    public class TreatmentProxy : DbWrapper, ITreatmentProxy
    {
        public DataTable GetAllTreatments()
        {
            var r = GetObject("GetAllCatalogoTratamiento", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetTreatmentById(long id)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };
        
            var r = GetObject("GetCatalogoTratamientoById", CommandType.StoredProcedure, parameters);
            return r;
        } 
    }
}
