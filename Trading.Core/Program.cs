using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trading.Core.Services;

namespace Trading.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var tradeStream = File.Open("trades.txt", FileMode.Open);
            IServiceCollection services = Startup.ConfigureServices(args);
            var builder = services.BuildServiceProvider();
            var tradeProcessor = builder.GetService<TradeProcessor>();
            tradeProcessor.ProcessTrades();
            Console.ReadKey();
        }




        private static void EnsureDataBaseCreated(IConfiguration configuration)
        {
            try
            {
                string connectionString = configuration.GetSection("ConnectionString").Value;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string commandString = File.ReadAllText("../SQL/script.sql");
                    using (var command = new SqlCommand(commandString, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    commandString = File.ReadAllText("../SQL/ps.sql");
                    using (var command = new SqlCommand(commandString, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
