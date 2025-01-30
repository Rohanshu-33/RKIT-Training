using FullDemo;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.OpenApi.Models;
using FullDemo.Filters;
using FullDemo.Extensions;
using FullDemo.Middlewares;
using NLog.Extensions.Logging;

namespace FullDemo
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddServices();

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
            services.AddEndpointsApiExplorer();

            // Registering filter globally
            services.AddControllers(options =>
            {
                options.Filters.Add<CustomExceptionFilter>();
            });

            services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
                });

                //app.UseDeveloperExceptionPage(
                //    new DeveloperExceptionPageOptions
                //    {
                //        SourceCodeLineCount = 10
                //    });
            }

            //app.UseMiddleware<JWTAuthenticationMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}