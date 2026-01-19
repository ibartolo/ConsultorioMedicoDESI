using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlProxy;
using Microsoft.Data.SqlClient;

namespace Patient.Proxy
{
    public class PatientProxy : DbWrapper, IPatientProxy
    {
        public DataTable GetAllPatients()
        {
            var r = GetObject("GetAllPaciente", CommandType.StoredProcedure);
            return r;
        }

        public DataTable GetPatientById(long id)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var r = GetObject("GetPacienteById", CommandType.StoredProcedure, parameters);
            return r;
        }
    }
}
