using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WeatherChat
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                configHost.AddCommandLine(args);
            })
            .ConfigureAppConfiguration( (hostContent, confugApp) =>
            {
                hostContent.HostingEnvironment.EnvironmentName = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Development";
                confugApp.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                confugApp.AddJsonFile($"appsettings.{hostContent.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
            })
            .ConfigureServices((hostContent, services) =>
            {
                services.AddHostedService<InputProcessor>();
            })
            .UseWindowsService()
            ;
    }
}
