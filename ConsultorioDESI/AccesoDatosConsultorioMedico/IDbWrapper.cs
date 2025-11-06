using EntidadesConsultorioMedico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosConsultorioMedico
{
    public interface IDbWrapper
    {
        List<ObjEmpresa> GetAllEmpresa();
        ObjEmpresa GetEmpresaById(long id);
        ObjEmpresa SaveOrUpdateEmpresa(ObjEmpresa obj);

        List<ObjPaciente> GetAllPaciente();

        ObjPaciente GetPacienteById(long id);
        ObjPaciente SaveOrUpdatePaciente(ObjPaciente obj);
    }
}
