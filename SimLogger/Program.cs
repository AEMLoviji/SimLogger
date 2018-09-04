using SimLogger.Loggers;
using System;

namespace SimLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            var log = new FileLogHandler();
            log.Info("Info text");
            log.Debug("Debug text");
            log.Warning("Warning text");
            log.Error("Error text");
        }
    }
}
