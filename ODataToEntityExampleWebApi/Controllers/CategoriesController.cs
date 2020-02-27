using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdataToEntity.AspNetCore;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.Controllers
{
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoriesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ODataResult<Category> Get()
        {
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);
            IAsyncEnumerable<Category> categories = parser.ExecuteReader<Category>();

            return parser.OData(categories);
        }
    }
}