using Jaeger;
using Jaeger.Samplers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTracing;
using OpenTracing.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScanTool
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            var portScan = serviceProvider.GetRequiredService<PortScan>();
            Application.Run(portScan);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<PortScan>();
            services.AddLogging(configure => configure.AddConsole());
            services.AddOpenTracing();

            services.AddSingleton<ITracer>(cli =>
            {
                Environment.SetEnvironmentVariable("JAEGER_SERVICE_NAME", "my-service-name");


                Environment.SetEnvironmentVariable("JAEGER_AGENT_HOST", "localhost");
                Environment.SetEnvironmentVariable("JAEGER_AGENT_PORT", "6831");
                Environment.SetEnvironmentVariable("JAEGER_SAMPLER_TYPE", "const");


                var loggerFactory = new LoggerFactory();

                var config = Jaeger.Configuration.FromEnv(loggerFactory);
                var tracer = config.GetTracer();

                if (!GlobalTracer.IsRegistered())
                {
                    // Allows code that can't use DI to also access the tracer.
                    GlobalTracer.Register(tracer);
                }

                return tracer;
            });

            services.AddOpenTracing();
        }
    }
}
