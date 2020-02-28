using Microsoft.EntityFrameworkCore;
using OdataToEntity.Cache;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.OData
{
    public sealed class NorthwindDataAdapter : OeEfCoreSqlServerDataAdapter<NorthwindContext>
    {
        public NorthwindDataAdapter(DbContextOptions<NorthwindContext> options, bool allowOeQueryCache) :
            base(options, new OeQueryCache(allowOeQueryCache))
        {
        }
    }
}