using System.Collections.Generic;
using Trading.Core.Models;

namespace Trading.Core.Services.Interfaces
{
    public interface ITradeStorage
    {
        void Persist(IEnumerable<TradeRecord> trades);
    }
}