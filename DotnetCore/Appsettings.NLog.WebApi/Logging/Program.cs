using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            ///
            ///First way of configuring
            ///

            //var config = new ConfigurationBuilder()
            //.SetBasePath(System.IO.Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
            //LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            //var logger = NLog.Web.NLogBuilder.ConfigureNLog(LogManager.Configuration).GetCurrentClassLogger();
            //try
            //{
            //    logger.Debug("Init main");
            //    CreateWebHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    logger.Error(ex, "Stopped program because of exception");
            //}
            //finally
            //{
            //    LogManager.Shutdown();
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging((hostBuilderContext, loggingBuilder)=>{
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    ///
                    ///Second way of configuring
                    ///
                    var section=hostBuilderContext.Configuration.GetSection("NLog");
                    LogManager.Configuration = new NLogLoggingConfiguration(section);
                    NLogBuilder.ConfigureNLog(LogManager.Configuration);
                })
                .UseNLog();
    }
}
