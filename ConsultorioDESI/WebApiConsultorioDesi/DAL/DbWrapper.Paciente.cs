using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.DAL
{
    public partial class DbWrapper : BaseDbWrapper
    {
        //Realizar el mapeo de los procedures stored para el objeto Paciente
        public ObjPaciente GetPacienteById(long id)
        {
            //enviar los parametros al procedure stored
            var parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@Id",
                    Value = id
                }
            };

            var response = GetObject<ObjPaciente>("GetPacienteById", System.Data.CommandType.StoredProcedure, parametros,
                new Func<System.Data.IDataReader, ObjPaciente>((reader) =>
                {
                    var r = FillEntity<ObjPaciente>(reader);
                    return r;
                }));

            return response;
        }

        //retornas todos los pacientes
        public List<ObjPaciente> GetAllPaciente()
        {
            var response = GetObjects<ObjPaciente>("GetAllPaciente", System.Data.CommandType.StoredProcedure, null,
                new Func<System.Data.IDataReader, ObjPaciente>((reader) =>
                {
                    var r = FillEntity<ObjPaciente>(reader);
                    return r;
                }));
            return response.ToList();
        }

        //Guardar o actualizar paciente
        public ObjPaciente SaveOrUpdatePaciente(ObjPaciente obj)
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
                    ParameterName = "@ApellidoP",
                    Value = obj.ApellidoP
                },
                new SqlParameter()
                {
                    ParameterName = "@ApellidoM",
                    Value = obj.ApellidoM
                },
                new SqlParameter()
                {
                    ParameterName = "@Genero",
                    Value = obj.Genero
                },
                new SqlParameter()
                {
                    ParameterName = "@FechaNacimiento",
                    Value = obj.FechaNacimiento
                },
                new SqlParameter()
                {
                    ParameterName = "@Edad",
                    Value = obj.Edad
                },
                new SqlParameter()
                {
                    ParameterName = "@Telefono",
                    Value = obj.Telefono
                },
                new SqlParameter()
                {
                    ParameterName = "@Email",
                    Value = obj.Email
                },
                new SqlParameter()
                {
                    ParameterName = "@FechaRecepcion",
                    Value = obj.FechaRecepcion
                },
                new SqlParameter()
                {
                    ParameterName = "@Comentario",
                    Value = obj.Comentario
                },
                new SqlParameter()
                {
                    ParameterName = "@CreatedBy",
                    Value = obj.CreatedBy
                },
                new SqlParameter()
                {
                    ParameterName = "@UpdatedBy",
                    Value = obj.UpdatedBy
                },
                new SqlParameter()
                {
                    ParameterName = "@CreatedDt",
                    Value = obj.CreatedDt
                }, 
                new SqlParameter()
                {
                    ParameterName = "@UpdatedDt",
                    Value = obj.UpdatedDt
                }
            };

            var response = ExecuteScalar("SaveOrUpdatePaciente", System.Data.CommandType.StoredProcedure, parametros);

            obj.Id = Convert.ToInt64(response);

            return obj;
        }
    }
}