using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Relaciones;

namespace AccesoDatosConsultorioMedico
{
    public partial class DbWrapper
    {
        public List<ObjRelacionTP> GetTratamientoPaqueteByTratamiento(long idTratamiento)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = idTratamiento,
                    ParameterName = "@TratamientoId"
                }
            };

            var response = GetObjects<ObjRelacionTP>("GetTratamientoPaqueteByTratamiento", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjRelacionTP>((responseString) =>
                {
                    var r = FillEntity<ObjRelacionTP>(responseString);
                    return r;
                }));
            return response.ToList();
        }

        public List<ObjRelacionTP> GetTratamientoPaqueteByPaquete(long idPaquete)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = idPaquete,
                    ParameterName = "@PaqueteId"
                }
            };

            var response = GetObjects<ObjRelacionTP>("GetTratamientoPaqueteByPaquete", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjRelacionTP>((responseString) =>
                {
                    var r = FillEntity<ObjRelacionTP>(responseString);
                    return r;
                }));
            return response.ToList();
        }

        public ObjTratamientoPaquete SaveTratamientoPaquete(ObjTratamientoPaquete obj)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = obj.TratamientoId,
                    ParameterName = "@TratamientoId"
                },
                new SqlParameter()
                {
                    Value = obj.PaqueteId,
                    ParameterName = "@PaqueteId"
                },
                new SqlParameter(){
                    Value = obj.CreatedBy,
                    ParameterName = "@CreatedBy"    
                },
                new SqlParameter(){
                    Value = obj.CreatedDt,
                    ParameterName = "@CreatedDt"
                },
                new SqlParameter(){
                    Value = obj.UpdatedBy,
                    ParameterName = "@UpdatedBy"
                },
                new SqlParameter(){
                    Value = obj.UpdatedDt,
                    ParameterName = "@UpdatedDt"
                }
            };

            var response = ExecuteScalar("SaveTratamientoPaquete", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }

    }
}