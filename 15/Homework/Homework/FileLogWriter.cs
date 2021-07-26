using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Homework
{
    public class FileLogWriter : AbstractLogWriter, ILogWriter, IDisposable
    {
        private FileStream fileStream;        
        
        public FileLogWriter(string fileName)
        {
            fileStream = new FileStream(
                fileName,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.Read);
        }
       
        public void Dispose()
        {
            fileStream.Close();
        }

        public override void LogRecordByType(string record)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(record + "\n");
            fileStream.Write(bytes, 0, bytes.Length);
        }
    }
}
