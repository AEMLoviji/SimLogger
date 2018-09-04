using System;
using System.Globalization;
using System.IO;
using SimLogger.Loggers;

namespace SimLogger
{
    public class FileLogHandler : ILogHandler
    {
        private static string _logFilePath = "D:\\simlogger.txt";

        static FileLogHandler()
        {
            if (!File.Exists(_logFilePath))
            {
                using (var sw = File.CreateText(_logFilePath))
                {
                    var logStartedString = $"{DateTime.Now} - Logging started";
                    sw.WriteLine(logStartedString);
                }
            }
        }

        public void Debug(string message)
        {
            CheckLogFileForExistence();
            AddToLogList(LogLevel.Debug, message);
        }

        public void Error(string message)
        {
            CheckLogFileForExistence();
            AddToLogList(LogLevel.Error, message);
        }

        public void Info(string message)
        {
            CheckLogFileForExistence();
            AddToLogList(LogLevel.Info, message);
        }

        public void Warning(string message)
        {
            CheckLogFileForExistence();
            AddToLogList(LogLevel.Warning, message);
        }


        #region private methods
        private void AddToLogList(LogLevel logLevel, string message)
        {
            using (var sw = File.AppendText(_logFilePath))
            {
                var logString = FormatOutput(logLevel, message);
                sw.WriteLine(logString);
            }
        }

        private string FormatOutput(LogLevel logLevel, string message)
        {
            return $"{DateTime.Now.ToString("G",CultureInfo.InvariantCulture)} - [{logLevel}] : {message}";
        }

        private static void CheckLogFileForExistence()
        {
            if (!File.Exists(_logFilePath))
            {
                throw new Exception("Log file not exists");
            }
        }
        #endregion
    }
}
