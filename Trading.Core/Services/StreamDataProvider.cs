using System.Collections.Generic;
using System.IO;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{

    public class StreamDataProvider : ITradeDataProvider
    {
        private readonly Stream stream;

        public StreamDataProvider(Stream stream)
        {
            this.stream = stream;
        }

        public IEnumerable<string> GetDataTrade()
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}