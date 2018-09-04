using System;

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
