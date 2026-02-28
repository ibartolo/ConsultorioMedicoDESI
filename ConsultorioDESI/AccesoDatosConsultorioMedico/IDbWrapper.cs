using EntidadesConsultorioMedico;
using EntidadesConsultorioMedico.Consultas;
using EntidadesConsultorioMedico.Relaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatosConsultorioMedico
{
    public interface IDbWrapper
    {
        //Empresa
        List<ObjEmpresa> GetAllEmpresa();
        ObjEmpresa GetEmpresaById(long id);
        ObjEmpresa SaveOrUpdateEmpresa(ObjEmpresa obj);

        //Paciente
        List<ObjPaciente> GetAllPaciente();
        ObjPaciente GetPacienteById(long id);
        ObjPaciente SaveOrUpdatePaciente(ObjPaciente obj);
        long CountPacientes(DateTime FechaInicial, DateTime FechaFinal);
        
        //Usuario
        List<ObjUsuario> GetAllUsuario();
        ObjUsuario GetUsuarioById(long id);
        ObjUsuario GetUsuarioByUserNameAndPass(string user, string pass);
        ObjUsuario SaveOrUpdateUsuario(ObjUsuario obj);

        //Relacion Tratamiento-Paquete
        List<ObjRelacionTP> GetTratamientoPaqueteByTratamiento(long idTratamiento);
        List<ObjRelacionTP> GetTratamientoPaqueteByPaquete(long idPaquete);
        ObjTratamientoPaquete SaveTratamientoPaquete(ObjTratamientoPaquete obj);

        //Tratamiento
        List<ObjTratamiento> GetAllCatalogoTratamiento();
        ObjTratamiento GetCatalogoTratamientoById(long id);
        ObjTratamiento SaveOrUpdateCatalogoTratamiento(ObjTratamiento obj);
        void DeleteCatalogoTratamiento(long id);

        //Paquete
        List<ObjPaquete> GetAllPaquete();
        ObjPaquete GetPaqueteById(long id);
        ObjPaquete SaveOrUpdatePaquete(ObjPaquete obj);

        //Institucion
        List<ObjInstitucion> GetAllInstituciones();
        ObjInstitucion GetInstitucionById(long id);
        ObjInstitucion SaveOrUpdateInstitucion(ObjInstitucion obj);

        //Datos Fiscales
        ObjDatosFiscales GetDatosFiscalesById(long id);
        List<ObjDatosFiscales> GetAllDatosFiscales();
        ObjDatosFiscales SaveOrUpdateDatosFiscales(ObjDatosFiscales datos);
        void DeleteDatosFiscales(long id);

        //Consulta
        List<ObjConsultaShow> GetAllConsulta();
        ObjConsultaShow GetConsultaById(long id);
        ObjConsulta SaveOrUpdateConsulta(ObjConsulta obj);
        long GetAppointmentCountByDateRange(DateTime FechaInicial, DateTime FechaFinal);

        //AltaTratamiento
        List<ObjAltaTratamientoShow> GetAllAltaTratamiento();
        List<ObjAltaTratamientoShow> GetAltaTratamientoById(long id);
        ObjAltaTratamiento SaveOrUpdateAltaTratamiento(ObjAltaTratamiento obj);
        ObjAltaTratamientoCatalogo SaveAltaTratamientoCatalogo(ObjAltaTratamientoCatalogo obj);
    }
}
