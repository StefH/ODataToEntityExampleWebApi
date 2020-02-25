using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            //var modelBoundProvider = _httpContextAccessor.HttpContext.CreateModelBoundProvider();
            //var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext, modelBoundProvider);
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);
            IAsyncEnumerable<Category> categories = parser.ExecuteReader<Category>();
            
            return parser.OData(categories);
        }

        [HttpGet("{categoryID}")]
        public ODataResult<Category> Get(int categoryID)
        {
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);
            var categories = parser.ExecuteReader<Category>();
            return parser.OData(categories);
        }

        //[HttpGet("{categoryID}")]
        //public ODataResult<Category> Get(int categoryID)
        //{
        //    var modelBoundProvider = _httpContextAccessor.HttpContext.CreateModelBoundProvider();
        //    var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext, modelBoundProvider);

        //    //var ctx = parser.GetDbContext<NorthwindContext>();
        //    //var q = ctx.Categories.AsQueryable().Where(c => c.CategoryID == id);

        //    IAsyncEnumerable<Category> categories = parser.ExecuteReader<Category>();

        //    return parser.OData(categories);
        //}
    }
}