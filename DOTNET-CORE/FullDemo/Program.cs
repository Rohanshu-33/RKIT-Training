using FullDemo;
using NLog.Web;

internal class Program
{
    static void Main(string[] args)
    {
        var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
        NLog.GlobalDiagnosticsContext.Set("LogDirectory", logPath);
        CreateHostBuilder(args).Build().Run();
    }
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