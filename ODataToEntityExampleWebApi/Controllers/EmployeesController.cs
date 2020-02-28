using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdataToEntity.AspNetCore;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.Controllers
{
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmployeesController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IAsyncEnumerable<Employee> Get()
        {
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);
            return parser.ExecuteReader<Employee>();
        }
    }
}