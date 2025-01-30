using FullDemo.BL.Interfaces;
using FullDemo.BL.Services;
using FullDemo.Models.DTO;

namespace FullDemo.Extensions
{
    public static class ServicesExtension
    {
        /// <summary>
        /// Adds the item services (like database connection and business services) to the dependency injection container.
        /// </summary>
        /// <param name="services">The IServiceCollection instance to register the services.</param>
        public static void AddServices(this IServiceCollection services)
        {

            // Registers the DBConnectionServices for dependency injection.
            services.AddScoped<IAppDBConnection, AppDBConnectionService>();

            // Registers the UserServices for dependency injection.
            services.AddScoped<IUserServices<DTOITH01>, UserServices>();

            // Registers the ItemServices for dependency injection.
            services.AddScoped<IItemServices<DTOITH03>, ItemServices>();
        }

    }
}
