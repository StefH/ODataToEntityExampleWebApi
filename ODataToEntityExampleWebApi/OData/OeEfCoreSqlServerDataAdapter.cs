using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using OdataToEntity.Cache;
using OdataToEntity.EfCore;

namespace ODataToEntityExampleWebApi.OData
{
    public class OeEfCoreSqlServerDataAdapter<T> : OeEfCoreDataAdapter<T> where T : DbContext
    {
        private sealed class OeEfCoreSqlServerOperationAdapter : OeEfCoreOperationAdapter
        {
            public OeEfCoreSqlServerOperationAdapter(Type dataContextType)
                : base(dataContextType)
            {
            }

            protected override object GetParameterCore(KeyValuePair<string, object> parameter, string parameterName, int parameterIndex)
            {
                if (!(parameter.Value is string) && parameter.Value is IEnumerable list)
                {
                    DataTable table = OdataToEntity.Infrastructure.OeDataTableHelper.GetDataTable(list);
                    if (parameterName == null)
                    {
                        parameterName = "@p" + parameterIndex.ToString(CultureInfo.InvariantCulture);
                    }
                    
                    return new Microsoft.Data.SqlClient.SqlParameter(parameterName, table) { TypeName = parameter.Key };
                }

                return parameter.Value;
            }
        }

        //public OeEfCoreSqlServerDataAdapter() : this(null, null)
        //{
        //}

        //public OeEfCoreSqlServerDataAdapter(OeQueryCache queryCache) : this(null, queryCache)
        //{
        //}

        public OeEfCoreSqlServerDataAdapter(DbContextOptions options, OeQueryCache queryCache)
            : base(options, queryCache, new OeEfCoreSqlServerOperationAdapter(typeof(T)))
        {
        }
    }
}