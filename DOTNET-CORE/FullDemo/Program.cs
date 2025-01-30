using FullDemo;
using NLog.Web;

internal class Program
{
    static void Main(string[] args)
    {
        var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Helpers", "Logging");
        if (!Directory.Exists(logPath))
        {
            Directory.CreateDirectory(logPath);
        }
        NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webHost =>
            {
                webHost.UseStartup<Startup>();
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(LogLevel.Trace);
            }).UseNLog();
    }
}