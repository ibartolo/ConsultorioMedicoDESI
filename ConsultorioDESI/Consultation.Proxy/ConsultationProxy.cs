using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SqlProxy;

namespace Consultation.Proxy
{
    public class ConsultationProxy : DbWrapper, IConsultationProxy
    {
        public DataTable GetAllConsultations()
        {
            DataTable dt = GetObject("GetAllConsulta", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetConsultationById(long id)
        {
            var parametro = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            DataTable dt = GetObject("GetConsultaById", CommandType.StoredProcedure, parametro);
            return dt;
        }
    }
}
