using System.Diagnostics;

namespace CoreEmptyWebApplication1
{
    public class CustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Debug.WriteLine("in middleware");  // working
            await context.Response.WriteAsync("in middleware\n");
            await next(context);
        }
    }
}
