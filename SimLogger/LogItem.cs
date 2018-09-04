using System;

namespace SimLogger
{
    /// <summary>
    /// Represents a single log item
    /// </summary>
    public class LogItem : ILogItem
    {
        #region fields
        private LogLevel _level;
        private string _source;
        private string _message;
        private DateTime _time;
        #endregion

        public LogItem(LogLevel level, string source, string message)
        {
            _level = level;
            _source = source;
            _message = message;
            _time = DateTime.Now;
        }

        #region properties
        /// <summary>
        /// Log Level indicator
        /// </summary>
        public LogLevel Level => _level;
        /// <summary>
        /// Property to indicate from which class log was originated
        /// </summary>
        public string Source => _source;
        /// <summary>
        /// Property for getting Message text
        /// </summary>
        public string Message => _message;
        /// <summary>
        /// Property which indicates when Log was created
        /// </summary>
        public DateTime Time => _time;
        #endregion properties


        public override string ToString()
        {
            return $"Level: {_level}, Source: {_source}, Message: {_message}, Time: {_time}";
        }

    }
}