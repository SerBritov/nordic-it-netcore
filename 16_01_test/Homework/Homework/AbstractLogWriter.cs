using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public abstract class AbstractLogWriter:ILogWriter
    {
        protected string _time
        {
            get
            {
                return String.Format("{0:yyyy-MM-dd hh:mm:ss.ffff+0000}", DateTimeOffset.Now);
            }
        }
        protected string _logInfo
        { get { return $"{_time}: Info - "; } }
        protected string _logError
        { get { return $"{_time}: Error - "; } }
        protected string _logWarning
        { get { return $"{_time}: Warning - "; } }

        public string _logMessage;
        
        public virtual void LogInfo(string message)
        {
            _logMessage = _logInfo + message;
        }

        public virtual void LogWarning(string message)
        {
            _logMessage = _logWarning + message;
        }

        public virtual void LogError(string message)
        {
            _logMessage = _logError + message;
        }
    }
}
