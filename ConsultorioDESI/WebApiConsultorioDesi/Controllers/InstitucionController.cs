using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Institucion")]
    public class InstitucionController : ApiController
    {
        public DbWrapper _dbwrapper = new DbWrapper();

        [Route("List")]
        [HttpGet]
        public List<ObjInstitucion> GetAllInstituciones()
        {
            var response = _dbwrapper.GetAllInstituciones();
            return response;
        }

        [Route("{id:long}")]
        [HttpGet]
        public ObjInstitucion GetInstitucionById(long id)
        {
            var response = _dbwrapper.GetInstitucionById(id);
            return response;
        }

        [Route("")]
        [HttpPost]
        public ObjInstitucion SaveOrUpdateInstitucion(ObjInstitucion obj)
        {
            var response = _dbwrapper.SaveOrUpdateInstitucion(obj);
            return response;
        }
    }
}