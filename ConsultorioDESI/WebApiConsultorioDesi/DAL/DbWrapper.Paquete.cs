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
        //mapeo de los procedimientos almacenados 
        public List<ObjPaquete> GetAllPaquete()
        {
            var response = GetObjects("GetAllPaquete", System.Data.CommandType.StoredProcedure,
                new Func<System.Data.IDataReader, ObjPaquete>((responseString) =>
                {
                    var r = FillEntity<ObjPaquete>(responseString);
                    return r;
                }));
            return response.ToList();
        }

        public ObjPaquete GetPaqueteById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = id,
                    ParameterName = "@Id"
                }
            };

            var response = GetObject("GetPaqueteById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjPaquete>((responseString) =>
                {
                    var r = FillEntity<ObjPaquete>(responseString);
                    return r;
                }));
            return response;
        }

        public ObjPaquete SaveOrUpdatePaquete(ObjPaquete obj)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = obj.NombrePaquete,
                    ParameterName = "@NombrePaquete"
                },
                new SqlParameter()
                {
                    Value = obj.Costo,
                    ParameterName = "@Costo"
                },
                new SqlParameter()
                {
                    Value = obj.Descripcion,
                    ParameterName = "@Descripcion"
                },
                new SqlParameter()
                {
                    Value = obj.CreatedBy,
                    ParameterName = "@CreatedBy"
                },
                new SqlParameter()
                {
                    Value = obj.CreatedDt,
                    ParameterName = "@CreatedDt"
                },
                new SqlParameter()
                {
                    Value = obj.UpdatedBy,
                    ParameterName = "@UpdatedBy"
                },
                new SqlParameter()
                {
                    Value = obj.UpdatedDt,
                    ParameterName = "@UpdatedDt"
                }
            };

            var response = GetObject("SaveOrUpdatePaquete", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjPaquete>((responseString) =>
                {
                    var r = FillEntity<ObjPaquete>(responseString);
                    return r;
                }));
            return response;
        }
    }
}