using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using SimLogger.Enums;

namespace SimLogger.LogProviders
{
    public class FileLogProvider : ILogProvider
    {
        private static string _logFilePath = "D:\\simlogger.txt";

        public string CallerMember { get; set; }

        static FileLogProvider()
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
            return $"{DateTime.Now.ToString("G", CultureInfo.InvariantCulture)} - [{logLevel}] {CallerMember}: {message}";
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
