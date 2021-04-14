using System;
using Trading.Core.Services.Interfaces;

namespace Trading.Core.Services
{
    public class Logger : ILogger
    {
        public Logger()
        {
        }

        public void Error(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Info(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}