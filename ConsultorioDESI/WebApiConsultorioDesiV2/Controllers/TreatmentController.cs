using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Treatment.Application;
using Treatment.Domain;
using Treatment.Messages;
using Common.Domain;

namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentApp _app;
        public TreatmentController(ITreatmentApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllTreatments")]
        public TreatmentObjListResponse GetAllTreatments()
        {
            var response = new TreatmentObjListResponse();
            List<TreatmentObj> list = _app.GetAllTreatments(out OperationResult result);
            response.treatments = list;
            response.result = result;
            return response;
        }

        [HttpGet("GetTreatmentById")]
        public TreatmentObjResponse GetTreatmentById(long id)
        {
            var response = new TreatmentObjResponse();
            TreatmentObj obj = _app.GetTreatmentById(id, out OperationResult result);
            response.treatment = obj;
            response.result = result;
            return response;
        }
    }
}
