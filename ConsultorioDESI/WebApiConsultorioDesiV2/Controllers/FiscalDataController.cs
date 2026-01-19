using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FiscalData.Messages;
using FiscalData.Domain;
using FiscalData.Application;
using Common.Domain;

namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalDataController : ControllerBase
    {
        private readonly IFiscalDataApp _app;

        public FiscalDataController(IFiscalDataApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllFiscalData")]
        public FiscalDataObjListResponse GetAllFiscalData()
        {
            var response = new FiscalDataObjListResponse();
            List<FiscalDataObj> list = _app.GetAllFiscalData(out OperationResult result);
            response.FiscalDatas = list;
            response.Result = result;
            return response;
        }

        [HttpGet("GetFiscalDataById")]
        public FiscalDataObjResponse GetDataFiscalById(long id)
        {
            var response = new FiscalDataObjResponse();
            FiscalDataObj obj = _app.GetFiscalDataById(id, out OperationResult result);
            response.FiscalData = obj;
            response.Result = result;
            return response;
        }
    }
}
