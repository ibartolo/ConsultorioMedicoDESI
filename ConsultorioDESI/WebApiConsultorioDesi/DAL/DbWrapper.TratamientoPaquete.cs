using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.DAL
{
    public partial class DbWrapper
    {
        public List<ObjTratamientoPaquete> GetTratamientoPaqueteByTratamiento(long idTratamiento)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = idTratamiento,
                    ParameterName = "@TratamientoId"
                }
            };

            var response = GetObjects<ObjTratamientoPaquete>("GetTratamientoPaqueteByTratamiento", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjTratamientoPaquete>((responseString) =>
                {
                    var r = FillEntity<ObjTratamientoPaquete>(responseString);
                    return r;
                }));
            return response.ToList();
        }

        public List<ObjTratamientoPaquete> GetTratamientoPaqueteByPaquete(long idPaquete)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = idPaquete,
                    ParameterName = "@PaqueteId"
                }
            };

            var response = GetObjects<ObjTratamientoPaquete>("GetTratamientoPaqueteByPaquete", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjTratamientoPaquete>((responseString) =>
                {
                    var r = FillEntity<ObjTratamientoPaquete>(responseString);
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
                }
            };

            var response = ExecuteScalar("SaveTratamientoPaquete", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }

    }
}