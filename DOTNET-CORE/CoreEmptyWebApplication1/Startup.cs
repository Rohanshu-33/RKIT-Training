using CoreEmptyWebApplication1.Controllers;
using CoreEmptyWebApplication1.Interfaces;
using CoreEmptyWebApplication1.Extensions;
using CoreEmptyWebApplication1.Repositories;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using NLog;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Builder;

namespace CoreEmptyWebApplication1
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddTransient<CustomMiddleware>();

            services.AddSwaggerGen(c =>
            {
                // Add API key definition to Swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Provide the API key in the header"
                });

                // Add security requirement to require the API key
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                 });
            });
            // automatic API documentation generation for minimal APIs. It is required for Swagger/OpenAPI to work properly with minimal APIs
            services.AddEndpointsApiExplorer();

            // there will be only one instance of singleton service throughout the application
            //services.AddSingleton<IProductInterface, ProductRepository>();

            // there will be only one instance of scoped service for a single http request. if requested again, then new instance is created.
            services.TryAddScoped<IProductInterface, ProductRepository>();

            // there will be different instances for every time the interface is being accessed or is used from different instances.
            services.AddTransient<IProductInterface, ProductRepository>();

            // service extension AddServices method to insert dependency injection.
            services.AddServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // context is similar to nodejs (req, res). it has details of both req and response upto the current pipeline execution
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use 1 - 1\n");
            //    await next();
            //    await context.Response.WriteAsync("Use 1 - 2\n");
            //});

            //app.UseMiddleware<CustomMiddleware>();


            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                });
                app.UseDeveloperExceptionPage(
                    new DeveloperExceptionPageOptions
                    {
                        SourceCodeLineCount = 10
                    });
            }
            else
            {
                app.UseExceptionHandler(
                    options =>
                    {
                        options.Run(
                            async context =>
                            {
                                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                var ex = context.Features.Get<IExceptionHandlerFeature>();
                                if (ex != null)
                                {
                                    await context.Response.WriteAsync(ex.Error.Message);
                                }
                            }
                     );
                    });
            }

            //app.Run(context =>
            //{
            //    throw new Exception("My exception.");
            //});

            // It determines which endpoint (controller/action) should handle the request but does not yet execute it.
            app.UseRouting();

            //  executes the matched endpoint after middleware processing.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();  // ensures that controller actions are executed.
            });

            app.Run(async context =>
            {
                Console.WriteLine("Inside app.Run()");
                await context.Response.WriteAsync("Hello from app.Run()!");
            });
        }
    }
}
