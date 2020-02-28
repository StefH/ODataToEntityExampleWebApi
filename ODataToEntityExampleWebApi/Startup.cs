using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OdataToEntity.AspNetCore;
using OdataToEntity.EfCore;
using ODataToEntityExampleWebApi.EntityFramework;
using ODataToEntityExampleWebApi.OData;

namespace ODataToEntityExampleWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbLoggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Default", LogLevel.Debug)
                    .AddFilter("Microsoft", LogLevel.Information)
                    //.AddFilter("System", LogLevel.Information)
                    .AddDebug()
                    .AddConsole();
            });

            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseLoggerFactory(dbLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("NorthwindContext"), opt => opt.UseRelationalNulls());
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();

            var dataAdapter = new NorthwindDataAdapter(optionsBuilder.Options, true);
            services.AddOdataToEntityMvc(dataAdapter.BuildEdmModelFromEfCoreModel());

            services.AddLogging();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}