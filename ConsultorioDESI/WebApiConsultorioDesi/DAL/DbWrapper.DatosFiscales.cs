using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.DAL
{
    public partial class DbWrapper
    {
        public ObjDatosFiscales GetDatosFiscalesById(long id)
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
            var response = GetObject<ObjDatosFiscales>("GetDatosFiscalesById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjDatosFiscales>((reader) =>
                {
                    var r = FillEntity<ObjDatosFiscales>(reader);
                    return r;
                }));
            return response;
        }


        public long SaveOrUpdateDatosFiscales(long id, string rfc, string razonSocial, string direccion, string email, string regimen, 
            long empresaId, string createdby, DateTime createddt, string updatedby, DateTime updateddt)
        {
            //Asignando valores
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id),
                new SqlParameter("@RFC", rfc),
                new SqlParameter("@RazonSocial", razonSocial),
                new SqlParameter("@Direccion", direccion),
                new SqlParameter("@Email", email),
                new SqlParameter("@Regimen", regimen),
                new SqlParameter("@EmpresaId", empresaId),
                new SqlParameter("@CreatedBy", createdby),
                new SqlParameter("@CreatedDt", createddt),
                new SqlParameter("@UpdatedBy", updatedby),
                new SqlParameter("@UpdatedDt", updateddt)
            };

            object resultado = ExecuteScalar("SaveOrUpdateDatosFiscales", System.Data.CommandType.StoredProcedure, parametros);

            return Convert.ToInt64(resultado);
        }
        
        public void DeleteDatosFiscales(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Id", id)
            };

            ExecuteNonQuery("DeleteDatosFiscales", System.Data.CommandType.StoredProcedure, parametros);
        }
    }
}