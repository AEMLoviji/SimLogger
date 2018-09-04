using System;
using System.Collections.Generic;

namespace SimLogger.Loggers
{
    public class LocalLogHandler : ILogHandler
    {
        private List<LogItem> localLogs = new List<LogItem>();
        
        public void Debug(string message)
        {
            AddToLogList(LogLevel.Debug, message);
        }

        public void Error(string message)
        {
            AddToLogList(LogLevel.Error, message);
        }

        public void Info(string message)
        {
            AddToLogList(LogLevel.Info, message);
        }

        public void Warning(string message)
        {
            AddToLogList(LogLevel.Warning, message);
        }

        private void AddToLogList(LogLevel logLevel, string message)
        {
            var logItem = new LogItem(logLevel, "", message);
            localLogs.Add(logItem);
        }
    }
}