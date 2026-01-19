using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProxy;
using Microsoft.Data.SqlClient;

namespace FiscalData.Proxy
{
    public class FiscalDataProxy : DbWrapper, IFiscalDataProxy
    {
        public DataTable GetAllFiscalData()
        {
            var r = GetObject("GetAllDatosFiscales", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetFiscalDataById(long id)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter(){
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var r = GetObject("GetDatosFiscalesById", CommandType.StoredProcedure, parameters);
            return r;
        }
    }
}
