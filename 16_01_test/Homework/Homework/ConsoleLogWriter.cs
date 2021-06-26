using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ConsoleLogWriter :AbstractLogWriter, ILogWriter
    {
        private string _timeNow
        {
            get
            {
                return String.Format("{0:yyyy-MM-dd hh:mm:ss.ffff+0000}", DateTimeOffset.Now);
            }
            set { }
        }
        public override void LogError(string message)
        {
            base.LogError(message);
            Console.WriteLine(_logMessage);
        }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            Console.WriteLine(_logMessage);
        }

        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            Console.WriteLine(_logMessage);
        }
    }
}
