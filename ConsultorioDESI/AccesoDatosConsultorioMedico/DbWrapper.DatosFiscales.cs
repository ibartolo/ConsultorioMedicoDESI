using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using EntidadesConsultorioMedico;

namespace AccesoDatosConsultorioMedico
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

        public List<ObjDatosFiscales> GetAllDatosFiscales()
        {
            var response = GetObjects<ObjDatosFiscales>("GetAllDatosFiscales", System.Data.CommandType.StoredProcedure,
                new Func<System.Data.IDataReader, ObjDatosFiscales>((reader) =>
                {
                    var r = FillEntity<ObjDatosFiscales>(reader);
                    return r;
                }));
            return response.ToList();
        }


        public ObjDatosFiscales SaveOrUpdateDatosFiscales(ObjDatosFiscales datos)
        {
            //Asignando valores
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@Id", 
                    Value=datos.Id
                },
                new SqlParameter()
                {
                    ParameterName="@RFC", 
                    Value=datos.RFC
                },
                new SqlParameter()
                {
                    ParameterName="@RazonSocial", 
                    Value=datos.RazonSocial
                },
                new SqlParameter()
                {
                    ParameterName="@Direccion", 
                    Value=datos.Direccion
                },
                new SqlParameter()
                {
                    ParameterName="@Email", 
                    Value=datos.Email
                },
                new SqlParameter()
                {
                    ParameterName="@Regimen", 
                    Value=datos.Regimen
                },
                new SqlParameter()
                {
                    ParameterName="@EmpresaId", 
                    Value=datos.EmpresaId
                },
                new SqlParameter()
                {
                    ParameterName="@CreatedBy", 
                    Value=datos.CreatedBy
                },
                new SqlParameter()
                {
                    ParameterName="@CreatedDt", 
                    Value=datos.CreatedDt
                },
                new SqlParameter()
                {
                    ParameterName="@UpdatedBy", 
                    Value=datos.UpdatedBy
                },
                new SqlParameter()
                {
                    ParameterName="@UpdatedDt", 
                    Value=datos.UpdatedDt
                }
            };

            var response = ExecuteScalar("SaveOrUpdateDatosFiscales", System.Data.CommandType.StoredProcedure, parametros);

            datos.Id = Convert.ToInt64(response);

            return datos;
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