using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Catalogs.Domain;
using Catalogs.Application;
using Catalogs.Messages;
using Common.Domain;
using System.Collections.Generic;   

namespace WebApiConsultorioDesiV2.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogsApp _catalogsApp;
        
        public CatalogsController(ICatalogsApp catalogsApp) //Injection ICatalogApp via constructor
        {
            _catalogsApp = catalogsApp;
        }

        /// <summary>
        /// Método que regresa un listado de todas las empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCompanies")]
        public CatalogsObjListResponse GetAllCompanies()
        {
            var response = new CatalogsObjListResponse();
            List<CatalogsObj> list = _catalogsApp.GetAllCompanies(out OperationResult result).ToList();
            response.Companies = list;
            response.Result = result;

            return response;
        }

        /// <summary>
        /// Método que regresa una compañia por Id
        /// </summary>
        /// <param name="id">Identificador de la compañia</param>
        /// <returns></returns>
        [HttpGet("GetCompanyById")]
        public CatalogsObjResponse GetCompanyById(long id)
        {
            var response = new CatalogsObjResponse();
            CatalogsObj company = _catalogsApp.GetCompanyById(id, out OperationResult result);
            response.Company = company;
            response.Result = result;
            return response;
        }
    }
}
