//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace ODataToEntityExampleWebApi.OData
//{
//    internal static class NorthwindContextOptions
//    {
//        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
//        {
//            builder
//                .AddFilter("Default", LogLevel.Debug)
//                .AddFilter("Microsoft", LogLevel.Information)
//                //.AddFilter("System", LogLevel.Information)
//                .AddDebug()
//                .AddConsole();
//        });

//        public static DbContextOptions Create<T>(string connectionString, bool useRelationalNulls) where T : DbContext
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<T>();

//            optionsBuilder.UseLoggerFactory(MyLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time
//            optionsBuilder.UseSqlServer(connectionString, opt => opt.UseRelationalNulls(useRelationalNulls));
//            optionsBuilder.EnableSensitiveDataLogging();

//            return optionsBuilder.Options;
//        }
//    }
//}