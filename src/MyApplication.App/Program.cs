using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Moryx.Asp.Integration;
using Moryx.Model;
using Moryx.Runtime.Kernel;
using Moryx.Tools;
using System.IO;

namespace StartProject.Asp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppDomainBuilder.LoadAssemblies();

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddMoryxKernel();
                    serviceCollection.AddMoryxModels();
                    serviceCollection.AddMoryxModules();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseIISIntegration();
                })
                .Build();

            host.Services.UseMoryxConfigurations("Config");
            host.Services.StartMoryxModules();

            host.Run();

            host.Services.StopMoryxModules();
        }
    }
}
