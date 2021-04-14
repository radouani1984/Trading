using System.Collections.Generic;
using Trading.Core.Models;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{
    public class SimpleTradeMapper : ITradeMapper
    {
        private const float LotSize = 100000f;

        public TradeRecord Map(IList<string> fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);
            // calculate values
            var trade = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };
            return trade;
        }
    }
}