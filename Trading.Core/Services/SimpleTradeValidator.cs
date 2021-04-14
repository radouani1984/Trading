using System.Collections.Generic;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private readonly ILogger logger;

        public SimpleTradeValidator(ILogger Logger)
        {
            logger = Logger;
        }


        public bool Validate(IList<string> fields, int lineCount)
        {

            if (fields.Count != 3)
            {
                logger.Warn("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Count);
                return false;
            }

            if (fields[0].Length != 6)
            {
                logger.Warn("WARN: Trade currencies on line {0} malformed: '{1}'", fields, lineCount);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                logger.Warn("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                logger.Warn("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
            }
            return true;
        }
    }
}