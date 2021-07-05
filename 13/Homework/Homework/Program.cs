using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogWriter fileLogWriter = FileLogWriter.GetInstance(@"D:\test.txt");
            MultipleLogWriter multipleLogWriter = MultipleLogWriter.GetInstance();

            multipleLogWriter.LogError("Message for error");
            multipleLogWriter.LogInfo("Message for info");
            multipleLogWriter.LogWarning("Message for warning");

            fileLogWriter.Dispose();
            Console.ReadKey();
        }
    }
}
