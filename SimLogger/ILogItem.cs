using System;
using SimLogger.Enums;

namespace SimLogger
{
    public interface ILogItem
    {
        string Source { get; }
        string Message { get; }
        LogLevel Level { get; }
        DateTime Time { get; }
    }
}
