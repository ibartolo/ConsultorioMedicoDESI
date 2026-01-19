using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Common.Domain;
using User.Application;
using User.Domain;
using User.Messages;

namespace WebApiConsultorioDesiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApp _app;

        public UserController(IUserApp app)
        {
            _app = app;
        }

        [HttpGet("GetAllUsers")]
        public UserObjListResponse GetAllUsers()
        {
            var response = new UserObjListResponse();
            List<UserObj> users = _app.GetAllUsers(out OperationResult result);
            response.users = users;
            response.result = result;
            return response;
        }

        [HttpGet("GetUserById")]
        public UserObjResponse GetUserById(long id)
        {
            var response = new UserObjResponse();
            UserObj user = _app.GetUserById(id, out OperationResult result);
            response.user = user;
            response.result = result;
            return response;
        }
    }
}
