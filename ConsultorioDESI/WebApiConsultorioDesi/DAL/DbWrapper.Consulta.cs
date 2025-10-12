using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiConsultorioDesi.Models;
using WebApiConsultorioDesi.Models.Consultas;

namespace WebApiConsultorioDesi.DAL
{
    public partial class DbWrapper
    {
        public List<ObjConsultaShow> GetAllConsulta()
        {
            var response = GetObjects<ObjConsultaShow>("GetAllConsulta", System.Data.CommandType.StoredProcedure, null,
                new Func<System.Data.IDataReader, ObjConsultaShow>((reader) =>
                {
                    var r = FillEntity<ObjConsultaShow>(reader);
                    return r;
                }));
            return response.ToList();
        }

        public ObjConsultaShow GetConsultaById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var response = GetObject<ObjConsultaShow>("GetConsultaById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjConsultaShow>((reader) =>
                {
                    var r = FillEntity<ObjConsultaShow>(reader);
                    return r;
                }));
            return response;
        }

        public ObjConsulta SaveOrUpdateConsulta(ObjConsulta obj)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = obj.Id
                },
                new SqlParameter()
                {
                    ParameterName = "@Paciente",
                    Value = obj.Paciente
                },
                new SqlParameter()
                {
                    ParameterName = "@Fecha",
                    Value = obj.Fecha
                },
                new SqlParameter()
                {
                    ParameterName = "@Hora",
                    Value = obj.Hora
                },
                new SqlParameter()
                {
                    ParameterName = "@TipoConsulta",
                    Value = obj.TipoConsulta
                },
                new SqlParameter()
                {
                    ParameterName = "@Comentarios",
                    Value = obj.Comentarios
                },
                new SqlParameter()
                {
                    ParameterName = "@CreatedBy",
                    Value = obj.CreatedBy
                },
                new SqlParameter()
                {
                    ParameterName = "@CreatedDt",
                    Value = obj.CreatedDt
                },
                new SqlParameter()
                {
                    ParameterName = "@UpdatedBy",
                    Value = obj.UpdatedBy
                },
                new SqlParameter()
                {
                    ParameterName = "@UpdatedDt",
                    Value = obj.UpdatedDt
                }
            };

            var response = ExecuteScalar("SaveOrUpdateConsulta", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }
    }
}