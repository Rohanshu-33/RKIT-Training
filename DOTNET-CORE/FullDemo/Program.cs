using FullDemo;
using NLog;
using NLog.Web;

namespace FullDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();

            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "Logging");
            GlobalDiagnosticsContext.Set("LogDirectory", logPath);

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            Startup startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);
            WebApplication app = builder.Build();
            startup.Configure(app, builder.Environment);
        }
    }
}