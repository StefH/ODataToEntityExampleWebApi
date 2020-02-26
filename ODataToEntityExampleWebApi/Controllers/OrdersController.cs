using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdataToEntity.AspNetCore;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrdersController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ODataResult<Order> Get()
        {
            var modelBoundProvider = _httpContextAccessor.HttpContext.CreateModelBoundProvider();
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext, modelBoundProvider);

            IAsyncEnumerable<Order> orders = parser.ExecuteReader<Order>();

            return parser.OData(orders);
        }

        [HttpGet("{OrderID}")]
        public ODataResult<Order> Get(int OrderID)
        {
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);

            var ctx = parser.GetDbContext<NorthwindContext>();
            var q = ctx.Orders.AsQueryable().Where(o => o.OrderID == OrderID);

            IAsyncEnumerable<Order> orders = parser.ExecuteReader<Order>(q);
            return parser.OData(orders);
        }
    }
}