using Catalogs.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Institutions.Application;
using Institute.Message;
using Institute.Domain;
using Common.Domain;

namespace WebApiConsultorioDesiV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstitutionsController : ControllerBase
    {
        private readonly IInstituteApp _instituteApp;

        public InstitutionsController(IInstituteApp catalogsApp) //Injection ICatalogApp via constructor
        {
            _instituteApp = catalogsApp;
        }

        [HttpGet("GetAllInstitutions")]
        public InstituteObjListResponse GeAllInstitutions()
        {
            var response = new InstituteObjListResponse();
            List<InstituteObj> list = _instituteApp.GetAllInstitutions(out OperationResult result).ToList();
            response.institutions = list;
            response.Result = result;
            return response;
        }

        [HttpGet("GetInstitutionsById")]
        public InstituteObjResponse GetInstitutionsById(long id)
        {
            var response = new InstituteObjResponse();
            InstituteObj obj = _instituteApp.GetInstitutionById(id, out OperationResult result);
            response.institute = obj;
            response.Result = result;
            return response;
        }

        //[HttpPost("")]
        //public IActionResult SaveOrUpdateInstitution()
        //{
        //    return Ok(new { message = "SaveOrUpdateInstitution is working!!" });
        //}
    }
}
