using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiConsultorioDesi.DAL;
using WebApiConsultorioDesi.Models;

namespace WebApiConsultorioDesi.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Usuario")]

    public class UsuarioController : ApiController
    {
        //obtener la lista de todos los usuarios
        [HttpGet]
        [Route("List")]
        public List<ObjUsuario> GetAllUsuario()
        {
            var response = new DbWrapper().GetAllUsuario();
            return response;
        }

        //obtener usuario por id
        [HttpGet]
        [Route("{id:long}")]
        public ObjUsuario GetUsuarioById(long id)
        {
            var response = new DbWrapper().GetUsuarioById(id);
            return response;
        }

        //obtener usuario por username y password
        [HttpPost]
        [Route("Login")]
        public IHttpActionResult GetUsuarioByUserNameAndPass([FromBody] ObjUsuario usuario)
        {
            var response = new DbWrapper().GetUsuarioByUserNameAndPass(usuario.UserName, usuario.Pass);
            return Ok(response);
        }

        //Actualizar y guardar
        [HttpPost]
        [Route("saveorupdate")]
        public IHttpActionResult SaveOrUpdateUsuario(long id, string username, string pass, string email, string nombre, string apellido, string createdby, DateTime createddt, string updatedby, DateTime updateddt)
        {
            try
            {
                new DbWrapper().SaveOrUpdateUsuario(id, username, pass, email, nombre, apellido, createdby, createddt, updatedby, updateddt);
                return Ok("Se ha registrado los datos con exito");
            }catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //Borrar usuario
        [HttpPost]
        [Route("delete/{id:long}")]
        public IHttpActionResult DeleteUsuario(long id)
        {
            new DbWrapper().DeleteUsuario(id);
            return Ok("El registro se borro con exito");
        }
    }
}