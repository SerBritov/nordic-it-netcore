using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Homework
{
    public class FileLogWriter : AbstractLogWriter, ILogWriter, IDisposable
    {
        private FileStream fileStream;

        private static FileLogWriter instance;
        private FileLogWriter(string fileName)
        {
            fileStream = new FileStream(
                fileName,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read);
        }
        public static FileLogWriter GetInstance(string fileName)
        {
            if (instance == null)
                instance = new FileLogWriter(fileName);
            return instance;
        }
        public static FileLogWriter GetInstance()
        {            
            return instance;
        }

        public void Dispose()
        {
            fileStream.Close();
        }

        protected override void LogRecordByType(string record)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(record + "\n");
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
