using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patient.Messages;
using Patient.Application;
using Common.Domain;
using Patient.Domain;
using System.Collections.Generic;

namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientApp _app;

        public PatientController(IPatientApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllPatients")]
        public PatientObjListResponse GetAllPatients()
        {
            var response = new PatientObjListResponse();
            List<PatientObj> list = _app.GetAllPatients(out OperationResult result).ToList();
            response.Patients = list;
            response.Result = result;
            return response;
        }

        [HttpGet("GetPatientById")]
        public PatientObjResponse GetPatientById(long id)
        {
            var response = new PatientObjResponse();
            var obj = _app.GetPatientById(id, out OperationResult result);
            response.patient = obj;
            response.Result = result;
            return response;
        }
    }
}
