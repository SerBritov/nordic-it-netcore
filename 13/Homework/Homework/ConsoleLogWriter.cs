using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        private static ConsoleLogWriter instance;
        private ConsoleLogWriter() { }
        public static ConsoleLogWriter GetInstance()
        {
            if (instance == null)
                instance = new ConsoleLogWriter();
            return instance;
        }

        protected override void LogRecordByType(string record)
        {
            Console.WriteLine(record);
        }
    }
}
