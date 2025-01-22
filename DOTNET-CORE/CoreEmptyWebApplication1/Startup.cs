using CoreEmptyWebApplication1.Controllers;

namespace CoreEmptyWebApplication1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<CustomMiddleware>();
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
