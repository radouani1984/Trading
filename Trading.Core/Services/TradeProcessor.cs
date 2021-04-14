using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Trading.Core.Models;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{

    public class TradeProcessor
    {
        IConfiguration _config;

        private ITradeDataProvider _dataProvider { get; }
        private ITradeParser _tradeParser { get; }
        private ITradeStorage _tradeStorage { get; }
        public TradeProcessor(IConfiguration configuration,
                ITradeDataProvider dataProvider,
                ITradeParser tradeParser,
                ITradeStorage tradeStorage)
        {
            _config = configuration;
            _dataProvider = dataProvider;
            _tradeParser = tradeParser;
            _tradeStorage = tradeStorage;
        }



        public void ProcessTrades()
        {
            // read rows
            IEnumerable<string> lines = _dataProvider.GetDataTrade();
            IList<TradeRecord> trades = _tradeParser.Parse(lines);
            _tradeStorage.Persist(trades);

            Console.WriteLine("INFO: {0} trades processed", trades.Count);
        }

    }
}