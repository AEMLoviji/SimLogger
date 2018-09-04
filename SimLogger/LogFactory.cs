using SimLogger.LogProviders;

namespace SimLogger
{
    public class LogFactory
    {
        public LogFactory(ILogProvider provider)
        {
            var logFabricInstance = LogExposer.Instance;
            logFabricInstance.Provider = provider;
        }
    }
}