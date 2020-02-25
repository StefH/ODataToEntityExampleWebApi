using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.OData.Edm;
using OdataToEntity;
using OdataToEntity.Db;
using OdataToEntity.EfCore;
using ODataToEntityExampleWebApi.EntityFramework;

namespace ODataToEntityExampleWebApi.OData
{
    internal static class NorthwindContextOptions
    {
        //public static EdmModel BuildDbEdmModel(bool useRelationalNulls)
        //{
        //    var orderDataAdapter = new OeEfCoreDataAdapter<NorthwindContext>(Create(useRelationalNulls));
        //    IEdmModel orderEdmModel = orderDataAdapter.BuildEdmModel();

        //    var order2DataAdapter = new OeEfCoreDataAdapter<NorthwindContext>(Create<NorthwindContext>(useRelationalNulls));
        //    return order2DataAdapter.BuildEdmModel(orderEdmModel);
        //}

        //public static DbContextOptions Create(bool useRelationalNulls)
        //{
        //    return Create<NorthwindContext>(useRelationalNulls);
        //}

        public static DbContextOptions Create<T>(string connectionString, bool useRelationalNulls) where T : DbContext
        {
            var optionsBuilder = new DbContextOptionsBuilder<T>();
            optionsBuilder = optionsBuilder.UseSqlServer(connectionString, opt => opt.UseRelationalNulls(useRelationalNulls));
            
            return optionsBuilder.Options;
        }

        //public static EdmModel BuildDbEdmModel(IEdmModel oeEdmModel, bool useRelationalNulls)
        //{
        //    OeDataAdapter dataAdapter = oeEdmModel.GetDataAdapter(oeEdmModel.EntityContainer);
        //    if (dataAdapter.CreateDataContext() is DbContext dbContext)
        //    {
        //        try
        //        {
        //            var order2DataAdapter = new OeEfCoreDataAdapter<NorthwindContext>
        //            {
        //                IsDatabaseNullHighestValue = dataAdapter.IsDatabaseNullHighestValue
        //            };

        //            return order2DataAdapter.BuildEdmModelFromEfCoreModel(oeEdmModel);
        //        }
        //        finally
        //        {
        //            dataAdapter.CloseDataContext(dbContext);
        //        }
        //    }

        //    throw new NotSupportedException("stef - todo");
        //}

        //public static DbContextOptions<T> Create<T>(bool useRelationalNulls) where T : DbContext
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<T>();
        //    optionsBuilder = optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;Initial Catalog=OdataToEntity;Trusted_Connection=Yes;", opt => opt.UseRelationalNulls(useRelationalNulls));
        //    return optionsBuilder.Options;
        //}

        //public static DbContextOptions CreateOptions<T>(DbContext dbContext) where T : DbContext
        //{
        //    return TestHelper.CreateOptions<T>(dbContext);
        //}
    }
}