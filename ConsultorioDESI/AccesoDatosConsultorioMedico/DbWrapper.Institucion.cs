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
        public List<ObjInstitucion> GetAllInstituciones()
        {
            var response = GetObjects<ObjInstitucion>("GetAllInstituciones", System.Data.CommandType.StoredProcedure, null,
                new Func<System.Data.IDataReader, ObjInstitucion>((reader) =>
                {
                    var r = FillEntity<ObjInstitucion>(reader);
                    return r;
                }));
            return response.ToList();
        } 

        public ObjInstitucion GetInstitucionById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var response = GetObject<ObjInstitucion>("GetInstitucionById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjInstitucion>((reader) =>
                {
                    var r = FillEntity<ObjInstitucion>(reader);
                    return r;
                }));
            return response;
        }

        public ObjInstitucion SaveOrUpdateInstitucion(ObjInstitucion obj)
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
                    ParameterName = "@NumeroTrabajadores",
                    Value = obj.NumeroTrabajadores
                },
                new SqlParameter()
                {
                    ParameterName = "@TelefonoL1",
                    Value = obj.TelefonoL1
                },
                new SqlParameter()
                {
                    ParameterName = "@TelefonoL2",
                    Value = obj.TelefonoL2
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = obj.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@Calle",
                    Value = obj.Calle
                }
                ,
                new SqlParameter()
                {
                    ParameterName = "@NumeroInterior",
                    Value = obj.NumeroInterior
                }
                ,
                new SqlParameter()
                {
                    ParameterName = "@NumeroExterior",
                    Value = obj.NumeroExterior
                }
                ,
                new SqlParameter()
                {
                    ParameterName = "@Colonia",
                    Value = obj.Colonia
                }
                ,
                new SqlParameter()
                {
                    ParameterName = "@Delegacion",
                    Value = obj.Delegacion
                },
                new SqlParameter()
                {
                    ParameterName = "@Municipio",
                    Value = obj.Municipio
                },
                new SqlParameter()
                {
                    ParameterName = "@Estado",
                    Value = obj.Estado
                },
                new SqlParameter()
                {
                    ParameterName = "@CodigoPostal",
                    Value = obj.CodigoPostal
                },
                new SqlParameter()
                {
                    ParameterName = "@Pais",
                    Value = obj.Pais
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

            var response = ExecuteScalar("SaveOrUpdateInstitucion", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }
    }
}