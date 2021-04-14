using System.Collections.Generic;

namespace Trading.Core.Services.Interfaces
{
    public interface ITradeValidator
    {
        bool Validate(IList<string> fields, int lineCount);
    }
}