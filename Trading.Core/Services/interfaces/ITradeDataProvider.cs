using System.Collections.Generic;
using System.IO;

namespace Trading.Core.Services.Interfaces
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> GetDataTrade();

    }
}