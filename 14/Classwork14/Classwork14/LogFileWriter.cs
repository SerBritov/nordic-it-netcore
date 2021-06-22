using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Classwork14
{
    public class LogFileWriter : IDisposable
    {
        private StreamWriter _logFileWriter;
        public string LogFileName
        {
            get;
            private set;
        }

        

        public LogFileWriter(string fileName)
        {
            LogFileName = fileName;

            Stream stream = File.Open(      //возвращает FileStream, наследника Stream
                LogFileName, 
                FileMode.OpenOrCreate, 
                FileAccess.ReadWrite, 
                FileShare.Read);

            _logFileWriter = new StreamWriter(stream);
        }

        public void WriteToLog(string logRecord)
        {
            _logFileWriter.WriteLine(
                "{0:yyyy-MM-dd hh:mm:ss}+00:00\t{1}",
                DateTime.UtcNow,
                logRecord);
            _logFileWriter.Flush();//чтобы сразу записывать данные

        }

        public void Dispose()
        {
            _logFileWriter?.Dispose();      //if (_logFileWriter != null) _logFileWriter.Dispose()
        }

       
    }
}
