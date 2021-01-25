using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace ButchTreat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            var host = BuldWebHost(args);
            host.Run();
        }


        private static void RunSeeding(IWebHost host)
        {
            var seeder = host.Services;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    
                });
        public static IWebHost BuldWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            
            .ConfigureAppConfiguration(SetupConfiguration)
            .UseStartup<Startup>()
                .Build();

        private static void SetupConfiguration(WebHostBuilderContext option, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile("appsettings.json", false, true); //can add config.json
        }
    }

    //    private static void SetupConfiguration(WebHostBuilderContext ctx, IConfiguration arg2)
    //    {
           
    //}
}
