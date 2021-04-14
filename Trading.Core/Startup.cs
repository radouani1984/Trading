using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trading.Core;
using Trading.Core.Services;

namespace Trading
{

    public static class Startup
    {
        public static IServiceCollection ConfigureServices(string[] args)
        {
            var services = new ServiceCollection();

            services.AddSingleton(Configuration(args));
            services.AddTransient<TradeProcessor>();
            return services;
        }
        private static IConfiguration Configuration(string[] args)
        {
            IConfiguration _configuration;

            _configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables()
                            .AddCommandLine(args)
                            .Build();


            return _configuration;
        }
    }
}