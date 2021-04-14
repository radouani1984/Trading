using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Trading.Core.Models;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{

    public class AdoNetTradeStorage : ITradeStorage
    {
        private IConfiguration _config { get; }

        public AdoNetTradeStorage(IConfiguration config)
        {
            _config = config;
        }


        public void Persist(IEnumerable<TradeRecord> trades)
        {
            using (var connection = new SqlConnection(_config.GetSection("ConnectionString").Value))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);

                        command.ExecuteNonQuery();
                    }

                    //transaction.Commit();
                }
                connection.Close();
            }
        }
    }
}