using SimLogger.Loggers;
using SimLogger.LogProviders;
using SimLogger.Utils;
using System;

namespace SimLogger
{
    public class LogExposer : ILogFabric
    {
        private ILogProvider _provider;

        private static LogExposer instance;
        private static object syncRoot = new Object();

        protected LogExposer() { }

        public static LogExposer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new LogExposer();
                    }
                }
                return instance;
            }
        }

        public ILogProvider Provider { set { _provider = value; } }



        public ILogProvider GetCurrentClassLogger()
        {
            _provider.CallerMember = ExecutionPointDetectorUtil.GetClassFullName();
            return _provider;
        }

        public void Debug(string message)
        {
            _provider.Debug(message);
        }

        public void Error(string message)
        {
            _provider.Error(message);
        }

        public void Info(string message)
        {
            _provider.Info(message);
        }

        public void Warning(string message)
        {
            _provider.Warning(message);
        }
    }
}