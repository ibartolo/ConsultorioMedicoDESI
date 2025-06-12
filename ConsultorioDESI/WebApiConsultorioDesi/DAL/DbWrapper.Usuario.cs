using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.DAL
{
    public partial class DbWrapper
    {
        public List<ObjUsuario> GetAllUsuario()
        {
            //debemos hacer la consulta con la base de datos usando un procedure stored
            var response = GetObjects("GetAllUsuario", System.Data.CommandType.StoredProcedure,
                new Func<System.Data.IDataReader, ObjUsuario>((reader) =>
                    {
                        //Crear un entidad de tipo ObjUsuario y asignarle los resultados del reader
                        var r = FillEntity<ObjUsuario>(reader);
                        return r;
                    }));
            return response.ToList();
        }

        public ObjUsuario GetUsuarioById(long id)
        {
            //debemos enviar los parametros al procedure stored
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = id,
                    ParameterName = "@Id"
                }
            };
            //Una vez asignado los parametros procedemos a ejecutar el procedure stored
            var response = GetObject<ObjUsuario>("GetUsuarioById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjUsuario>((reader) =>
                {
                    var r = FillEntity<ObjUsuario>(reader);
                    return r;
                }));
            return response;
        }

        //falta retornar un valor
        public ObjUsuario GetUsuarioByUserNameAndPass(string username, string password)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = username,
                    ParameterName = "@UserName"
                },

                new SqlParameter()
                {
                    Value = password,
                    ParameterName = "@Pass"
                }
            };

            var response = GetObject("GetUsuarioByUserNameAndPass", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjUsuario>((reader) =>
                {
                    var r = FillEntity<ObjUsuario>(reader);
                    return r;
                }));
            return response;
        }

        public long SaveOrUpdateUsuario(long id, string username, string pass, string email, string nombre, string apellido, string createdby, DateTime createddt, string updatedby, DateTime updateddt)
        {
            //Asignando valores
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@UserName", username),
                new SqlParameter("@Pass", pass),
                new SqlParameter("@Email", email),
                new SqlParameter("@Nombre", nombre), 
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@CreatedBy", createdby),
                new SqlParameter("@CreatedDt", createddt),
                new SqlParameter("@UpdatedBy", updatedby),
                new SqlParameter("@UpdatedDt", updateddt)
            };

            object resultado = ExecuteScalar("SaveOrUpdateUsuario", System.Data.CommandType.StoredProcedure, parametros);

            return Convert.ToInt64(resultado);
        }

        public void DeleteUsuario(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            ExecuteNonQuery("DeleteUsuario", System.Data.CommandType.StoredProcedure, parametros);
        }
    }
}