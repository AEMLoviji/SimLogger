namespace SimLogger.LogProviders
{
    public interface ILogProvider
    {
        string CallerMember { get; set; }

        void Info(string message);
        void Debug(string message);
        void Warning(string message);
        void Error(string message);
    }
}