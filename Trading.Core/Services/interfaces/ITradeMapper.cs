using System.Collections.Generic;
using Trading.Core.Models;

namespace Trading.Core.Services.Interfaces
{
    public interface ITradeMapper
    {
        TradeRecord Map(IList<string> fields);
    }
}