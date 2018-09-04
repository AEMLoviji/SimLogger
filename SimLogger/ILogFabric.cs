namespace SimLogger.Loggers
{
    public interface ILogFabric
    {
        void Info(string message);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
    }
}