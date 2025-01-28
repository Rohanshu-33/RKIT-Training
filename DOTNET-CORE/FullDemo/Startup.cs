using FullDemo;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using Microsoft.OpenApi.Models;
using FullDemo.BL.Interfaces;
using FullDemo.BL.Services;
using FullDemo.Models.POCO;
using FullDemo.Models.DTO;

namespace FullDemo
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddTransient<CustomMiddleware>();

            services.AddScoped<IUserServices<DTOITH01>, UserServices>();

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

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}