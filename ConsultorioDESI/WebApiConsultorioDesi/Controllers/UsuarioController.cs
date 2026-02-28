using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AccesoDatosConsultorioMedico;
using EntidadesConsultorioMedico;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Usuario")]

    public class UsuarioController : ApiController
    {
        public DbWrapper dbwrapper { get; set; }

        public UsuarioController()
        {
            dbwrapper = new DbWrapper();
        }

        //obtener la lista de todos los usuarios
        [HttpGet]
        [Route("List")]
        public List<ObjUsuario> GetAllUsuario()
        {
            var response = dbwrapper.GetAllUsuario();
            return response;
        }

        //obtener usuario por id
        [HttpGet]
        [Route("{id:long}")]
        public ObjUsuario GetUsuarioById(long id)
        {
            var response = dbwrapper.GetUsuarioById(id);
            return response;
        }

        //obtener usuario por username y password
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult GetUsuarioByUserNameAndPass(ObjUsuario usuario)
        {
            var response = dbwrapper.GetUsuarioByUserNameAndPass(usuario.UserName, usuario.Pass);
            return Ok(response);
        }

        //Actualizar y guardar
        [HttpPost]
        [Route("")]
        public ObjUsuario SaveOrUpdateUsuario(ObjUsuario obj)
        {
            var response = dbwrapper.SaveOrUpdateUsuario(obj);
            return response;
        }

        //Borrar usuario
        [HttpPost]
        [Route("delete/{id:long}")]
        public IHttpActionResult DeleteUsuario(long id)
        {
            dbwrapper.DeleteUsuario(id);
            return Ok("El registro se borro con exito");
        }
    }
}