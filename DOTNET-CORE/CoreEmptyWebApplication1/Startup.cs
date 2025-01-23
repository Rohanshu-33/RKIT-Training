using CoreEmptyWebApplication1.Controllers;
using CoreEmptyWebApplication1.Interfaces;
using CoreEmptyWebApplication1.Extensions;
using CoreEmptyWebApplication1.Repositories;

namespace CoreEmptyWebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();

            // there will be only one instance of singleton service throughout the application
            //services.AddSingleton<IProductInterface, ProductRepository>();

            // there will be only one instance of scoped service for a single http request. if requested again, then new instance is created.
            services.AddScoped<IProductInterface, ProductRepository>();

            // there will be different instances for every time the interface is being accessed or is used from different instances.
            services.AddTransient<IProductInterface, ProductRepository>();

            // service extension AddServices method to insert dependency injection.
            services.AddServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Use 1 - 1\n");
            //    await next();
            //    await context.Response.WriteAsync("Use 1 - 2\n");
            //});

            //app.UseMiddleware<CustomMiddleware>();



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
