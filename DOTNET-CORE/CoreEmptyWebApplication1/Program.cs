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
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webHosts =>
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