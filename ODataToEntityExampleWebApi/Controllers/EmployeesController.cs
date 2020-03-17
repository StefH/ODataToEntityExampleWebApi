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

            var ctx = parser.GetDbContext<NorthwindContext>();
            var list = Enumerable.Range(1, 10).Union(Enumerable.Range(10000, 30000));
            var employees1 = ctx.Employees.AsQueryable().Where(e => list.Contains(e.EmployeeID)).ToList();

            var employees2 = ctx.Employees.AsQueryable().Where(e => list.Contains(e.EmployeeID)).ToList();

            return parser.ExecuteReader<Employee>();
        }

        //// Force application/json : https://docs.microsoft.com/en-us/aspnet/core/web-api/advanced/formatting?view=aspnetcore-3.1#specify-a-format
        //[Produces("application/json")]
        //[HttpGet]
        //public async Task<ODataResult<Employee>> Get([FromQuery(Name = "ids")] int[] ids = null)
        //{
        //    var parser = new OeAspQueryParser(_httpContextAccessor.HttpContext);

        //    var ctx = parser.GetDbContext<NorthwindContext>();
        //    var employees = parser.ExecuteReader<Employee>(ctx.Employees.AsQueryable().Where(o => o.EmployeeID > 0);
        //    //var employees = parser.ExecuteReader<Employee>();
        //    var employeeList = await employees.Where(o => o.EmployeeID > 0 && (ids?.Contains(o.EmployeeID) ?? true)).OrderBy(o => o.EmployeeID).ToListAsync().ConfigureAwait(false);
        //    return parser.OData(employeeList);
        //}
    }
}