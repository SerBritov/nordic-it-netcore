using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ConsoleLogWriter : AbstractLogWriter, ILogWriter
    {

        protected override void LogRecordByType(string record)
        {
            Console.WriteLine(record);
        }
    }
}
