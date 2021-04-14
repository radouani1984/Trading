using System.Collections.Generic;
using Trading.Core.Models;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{

    public class SimpleTraderParser : ITradeParser
    {
        private readonly ITradeMapper mapper;
        private readonly ITradeValidator validator;

        public SimpleTraderParser(ITradeMapper mapper, ITradeValidator validator)
        {
            this.mapper = mapper;
            this.validator = validator;
        }
        public IList<TradeRecord> Parse(IEnumerable<string> lines)
        {
            var trades = new List<TradeRecord>();

            var lineCount = 1;
            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                if (!validator.Validate(fields, lineCount))
                {
                    continue;
                }

                TradeRecord trade = mapper.Map(fields);

                trades.Add(trade);

                lineCount++;
            }

            return trades;
        }
    }
}