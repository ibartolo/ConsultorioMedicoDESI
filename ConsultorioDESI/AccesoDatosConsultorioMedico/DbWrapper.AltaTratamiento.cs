using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Consultas;
using EntidadesConsultorioMedico.Relaciones;

namespace AccesoDatosConsultorioMedico
{
    public partial class DbWrapper
    {
        public List<ObjAltaTratamientoShow> GetAllAltaTratamiento()
        {
            var response = GetObjects<ObjAltaTratamientoShow>("GetAllAltaTratamiento", System.Data.CommandType.StoredProcedure, null,
                new Func<System.Data.IDataReader, ObjAltaTratamientoShow>((reader) => 
                {
                    var r = FillEntity<ObjAltaTratamientoShow>(reader);
                    return r;
                }));
            return response.ToList();
        }

        public List<ObjAltaTratamientoShow> GetAltaTratamientoById(long id)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    Value = id,
                    ParameterName = "@Id"
                }
            };

            var response = GetObjects<ObjAltaTratamientoShow>("GetAltaTratamientoById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjAltaTratamientoShow>((reader) =>
                {
                    var r = FillEntity<ObjAltaTratamientoShow>(reader);
                    return r;
                }));
            return response.ToList();
        }

        public ObjAltaTratamiento SaveOrUpdateAltaTratamiento(ObjAltaTratamiento obj)
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
                    Value = obj.Paciente,
                    ParameterName = "@Paciente"
                },
                new SqlParameter()
                {
                    Value = obj.Fecha,
                    ParameterName = "@Fecha"
                },
                new SqlParameter()
                {
                    Value = obj.Hora,
                    ParameterName = "@Hora"
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

            var response = ExecuteScalar("SaveOrUpdateAltaTratamiento", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }

        public ObjAltaTratamientoCatalogo SaveAltaTratamientoCatalogo(ObjAltaTratamientoCatalogo obj)
        {
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@AltaTratamientoId",
                    Value = obj.AltaTratamientoId
                },
                new SqlParameter()
                {
                    ParameterName = "@TratamientoId",
                    Value = obj.TratamientoId
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

            var response = ExecuteScalar("SaveAltaTratamientoCatalogo", System.Data.CommandType.StoredProcedure, parametros);
            obj.Id = Convert.ToInt64(response);
            return obj;
        }
    }
}