using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {
        
        public override void LogRecordByType(string record)
        {
            Console.WriteLine(record);
        }
    }
}
