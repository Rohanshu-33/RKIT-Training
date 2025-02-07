using CoreEmptyWebApplication1;
using Microsoft.Extensions.Hosting;
using NLog.Web;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
        CreateHostBuilder(args).Build().Run();
    }

    //responsible for configuring and creating a host.host manages application lifecycle, DI, logging, configuration and hosting of services.
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, config) =>
        {
            // Add environment-specific appsettings.json
            var environment = context.HostingEnvironment.EnvironmentName;

            config.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();  // Load environment variables (useful for sensitive data)
        }).ConfigureWebHostDefaults(webHosts =>
        {
            webHosts.UseStartup<Startup>();
        }).ConfigureLogging(options =>
        {
            options.ClearProviders();
            options.SetMinimumLevel(LogLevel.Trace);
        }).UseNLog();
    }
}


/*
 LOG LEVELS: Trace < Debug < Info < Warning < Errors < Fatal
 */