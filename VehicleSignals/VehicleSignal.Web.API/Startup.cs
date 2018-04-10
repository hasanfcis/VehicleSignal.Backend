using IVehicleSignal.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
using VehicleSignal.Domain.Interfaces.IRepositories;
using VehicleSignal.Domain.Interfaces.IServices;
using VehicleSignal.Domain.Services;
using VehicleSignal.Infrastructure.Data;
namespace VehicleSignal.Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AutoMapperConfiguration.AutoMapperConfiguration.Configure();



        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();

            services.AddMvc();
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleRepository, VehicleRepository>();
            services.AddScoped<VehicleSignalInitializer>();
            var connectionString = @"Server=.;Database=VehicleSignal;Trusted_Connection=True;MultipleActiveResultSets=true";
            services.AddDbContext<VehicleSignalContext>(o => o.UseSqlServer(connectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "VehicleSignal APIs", Version = "v1" });
               // c.IncludeXmlComments(@"bin\Debug\netcoreapp2.0\VehicleSignal.Web.API.xml");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, VehicleSignalInitializer vehicleSignalSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            vehicleSignalSeeder.Seed().Wait();



            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehicleSignal APIs");
            });
        }
    }
}
