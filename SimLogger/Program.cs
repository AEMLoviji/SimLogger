using SimLogger.Loggers;
using SimLogger.LogProviders;
using SimLogger.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace SimLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Initialize provider once in entry point of application
            var provider = new FileLogProvider();
            var logFactory = new LogFactory(provider);

            var log = LogExposer.Instance.GetCurrentClassLogger();

            for (int i = 1; i <= 5; i++)
            {
                log.Info($"{i} - Info text");
                log.Debug($"{i} - Debug text");
                log.Warning($"{i} - Warning text");
                log.Error($"{i} - Error text");
            }
            SomeMoreClass.CallMe();

            //fake logs
            //while (true)
            //{
            //    log.Info("Info text");
            //    log.Debug("Debug text");
            //    log.Warning("Warning text");
            //    log.Error("Error text");
            //}


            Console.Read();
        }

    }
}