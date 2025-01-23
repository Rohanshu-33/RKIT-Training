using CoreEmptyWebApplication1.Repositories;
using CoreEmptyWebApplication1.Interfaces;

namespace CoreEmptyWebApplication1.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<ITaskInterface, TaskRepository>();
        }
    }
}
