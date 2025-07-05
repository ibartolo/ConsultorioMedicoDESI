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
            var parametros = GenerateSQLParameters(obj);

            var response = ExecuteScalar("SaveOrUpdatePaciente", System.Data.CommandType.StoredProcedure, parametros);

            obj.Id = Convert.ToInt64(response);

            return obj;
        }
    }
}