using Microsoft.AspNetCore;

namespace Fiinancial.Api.Interface
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseIISIntegration()
                   .UseStartup<Startup>()
                   .CaptureStartupErrors(true);
    }
}