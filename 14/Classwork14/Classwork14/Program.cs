using System;

namespace Classwork14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Log writing is running!");

            using (var logFileWriter = new LogFileWriter(@"d:\test_log.txt"))
            {
                logFileWriter.WriteToLog(@"test log record");

                logFileWriter.Dispose();
            }

        }
    }
}
