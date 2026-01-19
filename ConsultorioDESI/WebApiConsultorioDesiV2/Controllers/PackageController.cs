using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Package.Messages;
using Package.Application;
using Package.Domain;
using Common.Domain;

namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private readonly IPackageApp _app;

        public PackageController(IPackageApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllPackages")]
        public PackageObjListResponse GetAllPackages()
        {
            var response = new PackageObjListResponse();
            List<PackageObj> list = _app.GetAllPackages(out OperationResult result);
            response.packages = list;
            response.result = result;
            return response;
        }

        [HttpGet("GetPackageById")]
        public PackageObjResponse GetPackageById(long id)
        {
            var response = new PackageObjResponse();
            PackageObj obj = _app.GetPackageById(id, out OperationResult result);
            response.package = obj;
            response.result = result;
            return response;
        }
    }
}
