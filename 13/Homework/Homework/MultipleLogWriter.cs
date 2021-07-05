using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class MultipleLogWriter : ILogWriter, IEnumerable<ILogWriter>
    {
        private static MultipleLogWriter instance;
        private MultipleLogWriter()
        {
            _logWriters = new List<ILogWriter> 
            { 
                ConsoleLogWriter.GetInstance(), 
                FileLogWriter.GetInstance() 
            };
        }
        public static MultipleLogWriter GetInstance()
        {
            if (instance == null)
                instance = new MultipleLogWriter();
            return instance;
        }
        private List<ILogWriter> _logWriters;

        public void LogError(string message)
        {
            foreach (var logWriter in _logWriters)
                logWriter.LogError(message);
        }

        public void LogInfo(string message)
        {
            foreach (var logWriter in _logWriters)
                logWriter.LogInfo(message);
        }

        public void LogWarning(string message)
        {
            foreach (var logWriter in _logWriters)
                logWriter.LogWarning(message);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<ILogWriter> GetEnumerator()
        {
            return _logWriters.GetEnumerator();
        }

    }
}
