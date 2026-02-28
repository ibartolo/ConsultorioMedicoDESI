using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EntidadesConsultorioMedico;

namespace AccesoDatosConsultorioMedico
{
    public partial class DbWrapper
    {
        //hacer llamado con los procedures almacenados
        public List<ObjTratamiento> GetAllCatalogoTratamiento()
        {
            var response = GetObjects<ObjTratamiento>("GetAllCatalogoTratamiento", System.Data.CommandType.StoredProcedure, null,
                new Func<System.Data.IDataReader, ObjTratamiento>((reader) => {
                    var r = FillEntity<ObjTratamiento>(reader);
                    return r;
                }));
            return response.ToList();
        }

        public ObjTratamiento GetCatalogoTratamientoById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var response = GetObject<ObjTratamiento>("GetCatalogoTratamientoById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjTratamiento>((reader) =>
                {
                    var r = FillEntity<ObjTratamiento>(reader);
                    return r;
                }));
            return response;
        }

        public ObjTratamiento SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj)
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
                    ParameterName = "@Nombre",
                    Value = obj.Nombre
                },
                new SqlParameter()
                {
                    ParameterName = "@Duracion",
                    Value = obj.Duracion
                },
                new SqlParameter()
                {
                    ParameterName = "@Descripcion",
                    Value = obj.Descripcion
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

            var response = ExecuteScalar("SaveOrUpdateCatalogoTratamiento", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }

        public void DeleteCatalogoTratamiento(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };
            ExecuteNonQuery("DeleteCatalogoTratamiento", System.Data.CommandType.StoredProcedure, parametros);
        }
    }
}