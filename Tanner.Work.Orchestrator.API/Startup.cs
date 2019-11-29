using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tanner.Swagger;
using Tanner.Telemetry.AppInsights;
using Tanner.Work.Orchestrator.API.Business;
using Tanner.Work.Orchestrator.API.Contracts;
using Tanner.Work.Orchestrator.DA.DataAccess;

namespace Tanner.Work.Orchestrator.API
{
    public class Startup
    {


        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="environment"></param>
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(environment.ContentRootPath)
                 .AddConfiguration(configuration)
                 .AddJsonFile("Settings/appsettings.json", optional: true, reloadOnChange: true)
                 .AddJsonFile($"Settings/appsettings.{environment.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build(); ;

            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTannerSwagger(Configuration, Environment.ContentRootPath);
            services.AddDataAccess(Configuration);
            services.AddTannerTelemetry(Configuration);
            services.AddScoped<IWorkBusiness, WorkBusiness>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseTannerSwagger(Configuration);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
