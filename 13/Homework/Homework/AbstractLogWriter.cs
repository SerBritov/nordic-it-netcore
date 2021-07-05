using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public abstract class AbstractLogWriter : ILogWriter
    {
        protected string LogRecordFormat
        {
            get
            {
                return "{0:yyyy-MM-dd hh:mm:ss.ffff+0000}: {1} - {2}";
            }
        }

        private string GetLogRecord(string message, string logType)
        {
            return String.Format(LogRecordFormat, DateTimeOffset.Now, logType, message);
        }

        public virtual void LogInfo(string message)
        {
            LogRecordByType(GetLogRecord(message, "Info"));
        }

        public virtual void LogWarning(string message)
        {
            LogRecordByType(GetLogRecord(message, "Warning"));
        }

        public virtual void LogError(string message)
        {
            LogRecordByType(GetLogRecord(message, "Error"));
        }
                
        abstract protected void LogRecordByType(string record);
    }
}
