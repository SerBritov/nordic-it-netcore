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
        public override void LogError(string message)
        {
            base.LogError(message);
            byte[] bytes = Encoding.ASCII.GetBytes(_logMessage + "\n");
            fileStream.Write(bytes, 0, bytes.Length);
        }

        public override void LogInfo(string message)
        {
            base.LogInfo(message);
            byte[] bytes = Encoding.ASCII.GetBytes(_logMessage + "\n");
            fileStream.Write(bytes, 0, bytes.Length);
        }

        public override void LogWarning(string message)
        {
            base.LogWarning(message);
            byte[] bytes = Encoding.ASCII.GetBytes(_logMessage + "\n");
            fileStream.Write(bytes, 0, bytes.Length);
        }

        public void Dispose()
        {
            fileStream.Close();
        }
    }
}
