using System.Collections.Generic;
using Trading.Core.Models;

namespace Trading.Core.Services.Interfaces
{
    public interface ITradeParser
    {
        IList<TradeRecord> Parse(IEnumerable<string> lines);
    }
}