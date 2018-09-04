using SimLogger.LogProviders;

namespace SimLogger
{
    public static class SomeMoreClass
    {
        readonly static ILogProvider log = LogExposer.Instance.GetCurrentClassLogger();

        public static void CallMe()
        {
            for (int i = 1; i <= 5; i++)
            {
                log.Info($"{i} - Info text");
                log.Debug($"{i} - Debug text");
                log.Warning($"{i} - Warning text");
                log.Error($"{i} - Error text");
            }

        }
    }
}
