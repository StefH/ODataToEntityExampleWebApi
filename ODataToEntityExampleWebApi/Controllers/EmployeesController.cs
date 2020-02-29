using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // Force application/json : https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-3.1#specify-a-format
        [Produces("application/json")]
        [HttpGet]
        public IAsyncEnumerable<Employee> Get()
        {
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);
            return parser.ExecuteReader<Employee>();
        }

        [Produces("application/json")]
        [HttpGet("<ids>")]
        public async Task<ODataResult<Employee>> Get(string ids)
        {
            var employeeIds = ids.Split(',').Select(int.Parse);
            var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);

            var ctx = parser.GetDbContext<NorthwindContext>();
            //var employees = parser.ExecuteReader<Employee>(ctx.Employees.AsQueryable().Where(o => o.EmployeeID > 0 && o.EmployeeID == id));
            var employees = parser.ExecuteReader<Employee>();
            var orderList = await employees.Where(o => o.EmployeeID > 0 && employeeIds.Contains(o.EmployeeID)).OrderBy(o => o.EmployeeID).ToListAsync().ConfigureAwait(false);
            return parser.OData(orderList);
        }
    }
}