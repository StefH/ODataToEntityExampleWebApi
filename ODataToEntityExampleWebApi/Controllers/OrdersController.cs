using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OdataToEntity.AspNetCore;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.Controllers
{
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IHttpContextAccessor httpContextAccessor, ILogger<OrdersController> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [HttpGet]
        public ODataResult<Order> Get()
        {
            _logger.LogInformation("Getting orders...");

            var modelBoundProvider = _httpContextAccessor.HttpContext.CreateModelBoundProvider();
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext, modelBoundProvider);

            IAsyncEnumerable<Order> orders = parser.ExecuteReader<Order>();

            return parser.OData(orders);
        }
    }
}