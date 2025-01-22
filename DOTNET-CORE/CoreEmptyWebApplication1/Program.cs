using CoreEmptyWebApplication1;
using Microsoft.Extensions.Hosting;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webHosts =>
        {
            webHosts.UseStartup<Startup>();
        });
    }
}