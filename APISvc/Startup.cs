using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using APISvc.DTOs;
using APISvc.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Community.AspNetCore.ExceptionHandling;
using Community.AspNetCore.ExceptionHandling.Mvc;

namespace APISvc
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
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddMvc(config => {
                config.AllowEmptyInputInBodyModelBinding = true;
            });
            // Register the Swagger services
            // Register the Swagger generator, defining 1 or more Swagger documents
            String env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.1.1", new Info { Title = "Kootoro API services" + env, Version = "v1.1.1" });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.1",
                    Title = "Kootoro API services - " + env,
                    Description = "Kootoro API services",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Author: Sơn Trường",
                        Email = "son.truong@kootoro.com",
                        Url = "https://www.kootoro.com"
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware(typeof(ExceptionCatchExtensions));
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwagger();
            if(env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/rabbitmq/swagger/v1/swagger.json", "Kootoro API services V1.1.1");
                });
                app.UseDeveloperExceptionPage();
            }
           
            if(env.IsProduction())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/rabbitmq/swagger/v1/swagger.json", "Kootoro API services V1.1.1");
                });
            }

            if(env.IsStaging())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kootoro API services V1.1.1");
                });
            }
            app.UseMvc();
        }
    }
}
