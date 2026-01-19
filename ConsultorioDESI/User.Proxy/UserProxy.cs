using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SqlProxy;
namespace User.Proxy
{
    public class UserProxy : DbWrapper, IUserProxy
    {
        public DataTable GetAllUsers()
        {
            var dt = GetObject("GetAllUsuario", CommandType.StoredProcedure);
            return dt;
        }

        public DataTable GetUserById(long id)
        {
            var parametro = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var dt = GetObject("GetUsuarioById", CommandType.StoredProcedure, parametro);
            return dt;
        }
    }
}
