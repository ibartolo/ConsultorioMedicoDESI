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
        public List<ObjEmpresa> GetAllEmpresa()
        {
            var response = GetObjects("GetAllEmpresa", System.Data.CommandType.StoredProcedure,
                new Func<System.Data.IDataReader, ObjEmpresa>((reader) =>
                {
                    var r = FillEntity<ObjEmpresa>(reader);
                    return r;
                }));

            return response.ToList();
        }

        public ObjEmpresa GetEmpresaById(long id)
        {
            var parametros = new List<SqlParameter>()
            { 
                new SqlParameter()
                { 
                    Value = id,
                    ParameterName = "@Id"
                }
            };
            var response = GetObject<ObjEmpresa>("GetEmpresaById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjEmpresa>((reader) =>
                {
                    var r = FillEntity<ObjEmpresa>(reader);
                    return r;
                }));

            return response;
        }
    }
}