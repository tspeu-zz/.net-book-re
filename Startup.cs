using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using webapi_FreeCodeCamp.Domain.Models.Repositories;
using webapi_FreeCodeCamp.Domain.Repositories;
using webapi_FreeCodeCamp.Persistence.Context;
using webapi_FreeCodeCamp.Services;
//using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using NSwag.AspNetCore;
//using Swashbuckle.;

namespace webapi_FreeCodeCamp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //add
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("hiperdino-api-in-memory");
            });

            services.AddScoped<ICategoryRespository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddSwaggerDocument();

            // Register the Swagger generator, defining 1 or more Swagger documents
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My jm API V1", Version = "v1" });
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
#pragma warning disable CS0618 // El tipo o el miembro están obsoletos
            app.UseSwagger(config => config.PostProcess = (document, request) => {
                  if (request.Headers.ContainsKey("X-External-Host")) {
                    document.Host = request.Headers["X-External-Host"].First();
                    document.BasePath = request.Headers["X-External-Host"].First();
                }

            });
#pragma warning restore CS0618 // El tipo o el miembro están obsoletos

            app.UseSwaggerUi3(conf => conf.TransformToExternalPath = (internalUiRoute, request) => {
                var extertnalPath = request.Headers.ContainsKey("X-External-Path") ?
                        request.Headers["X-External-Host"].First() : "";
                return extertnalPath + internalUiRoute;
                    }
                
                );

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My jm API V1");
            //    //c.RoutePrefix = string.Empty;
            //});


            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseMvc();
            // Enable middleware to serve generated Swagger as a JSON endpoint.


        }

        //private class OpenApiInfo : Info
        //{
        //    public string Title { get; set; }
        //    public string Version { get; set; }
        //}
    }
}
