using OdataToEntity.Cache;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.OData
{
    public sealed class NorthwindDataAdapter : OeEfCoreSqlServerDataAdapter<NorthwindContext>
    {
        public NorthwindDataAdapter(string connectionString) :
            base(NorthwindContextOptions.Create<NorthwindContext>(connectionString, true), new OeQueryCache(false))
        {
        }
    }
}