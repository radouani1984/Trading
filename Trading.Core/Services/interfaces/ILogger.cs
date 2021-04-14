namespace Trading.Core.Services.Interfaces
{
    public interface ILogger
    {
        void Warn(string message, params object[] args);
        void Info(string message, params object[] args);
        void Error(string message, params object[] args);

    }
}