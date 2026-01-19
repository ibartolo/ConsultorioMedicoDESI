using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Consultation.Domain;
using Consultation.Application;
using Consultation.Messages;
using Common.Domain;
using System.Collections.Generic;


namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationApp _app;

        public ConsultationController(IConsultationApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllConsultations")]
        public ConsultationObjListResponse GetAllConsultation()
        {
            var response = new ConsultationObjListResponse();
            List<ConsultationObj> list = _app.GetAllConsultations(out OperationResult result).ToList();
            response.Consultations = list;
            response.Result = result;
            return response;
        }

        [HttpGet("GetConsultationById")]
        public ConsultationObjResponse GetConsultationById(long id) 
        {
            var response = new ConsultationObjResponse();
            ConsultationObj obj = _app.GetConsultationById(id, out OperationResult result);
            response.Consultation = obj;
            response.Result = result;
            return response;
        }
    }
}
