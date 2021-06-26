using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogWriter fileLogWriter = new FileLogWriter(@"D:\test.txt");
            ConsoleLogWriter consoleLogWriter = new ConsoleLogWriter();
            MultipleLogWriter multipleLogWriter = new MultipleLogWriter(
                new List<ILogWriter>()
                {
                    fileLogWriter,
                    consoleLogWriter
                });

            multipleLogWriter.LogError("Message for error");
            multipleLogWriter.LogInfo("Message for info");
            multipleLogWriter.LogWarning("Message for warning");

            fileLogWriter.Dispose();
            Console.ReadKey();
        }
    }
}
