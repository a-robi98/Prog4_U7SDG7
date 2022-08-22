using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyGuitarShop.Data;
using MyGuitarShop.Logic;
using MyGuitarShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGuitarShop.Endpoint
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

            services.AddTransient<DbContext,GuitarContext>();

            services.AddTransient<IGuitarRepository,GuitarRepository>();
            services.AddTransient<IGuitarAmpRepository, GuitarAmpRepository>();
            services.AddTransient<IGuitarAccessoryRepository, GuitarAccessoryRepository>();
            services.AddTransient<IAmpRepository, AmpRepository>();
            services.AddTransient<IAccessoryRepository, AccessoryRepository>();
            

            services.AddTransient<IManagementLogic, ManagementLogic>();
            services.AddTransient<ISellerLogic, SellerLogic>();
            services.AddTransient<IProcurementLogic, ProcurementLogic>();

            services.AddHttpClient();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyGuitarShop.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyGuitarShop.Endpoint v1"));
            }

            app.UseCors(x => x
                .AllowCredentials()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:49890"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
