using System;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using EntidadesConsultorioMedico;

namespace AccesoDatosConsultorioMedico
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

        public ObjUsuario SaveOrUpdateUsuario(ObjUsuario obj)
        {
            //Asignando valores
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id", obj.Id),
                new SqlParameter("@UserName", obj.UserName),
                new SqlParameter("@Pass", obj.Pass),
                new SqlParameter("@Email", obj.Email),
                new SqlParameter("@Nombre", obj.Nombre), 
                new SqlParameter("@Apellido", obj.Apellido),
                new SqlParameter("@CreatedBy", obj.CreatedBy),
                new SqlParameter("@CreatedDt", obj.CreatedDt),
                new SqlParameter("@UpdatedBy", obj.UpdatedBy),
                new SqlParameter("@UpdatedDt", obj.UpdatedDt)
            };

            object resultado = ExecuteScalar("SaveOrUpdateUsuario", System.Data.CommandType.StoredProcedure, parametros);

            obj.Id = Convert.ToInt64(resultado);
            return obj;
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