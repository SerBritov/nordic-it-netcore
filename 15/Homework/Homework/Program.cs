using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            LogWriterFactory logWriterFactory = LogWriterFactory.GetInstance();           
            ILogWriter multipleLogWriter =
                logWriterFactory.GetLogWriter<MultipleLogWriter>(
                    new List<ILogWriter>{
                        logWriterFactory.GetLogWriter<ConsoleLogWriter>()
                        ,logWriterFactory.GetLogWriter<FileLogWriter>(@"D:\test_15.txt")});
            multipleLogWriter.LogError("Message for error");
            multipleLogWriter.LogInfo("Message for info");
            multipleLogWriter.LogWarning("Message for warning");

            Console.ReadKey();
        }
    }
}
