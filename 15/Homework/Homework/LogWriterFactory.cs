using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class LogWriterFactory
    {
        private static LogWriterFactory instance;
        private LogWriterFactory() { }
        public static LogWriterFactory GetInstance()
        {
            if (instance == null)
                instance = new LogWriterFactory();
            return instance;
        }
        public ILogWriter GetLogWriter<T>(object parameters = null) where T : ILogWriter
        {
            switch (typeof(T).ToString())
            {
                case "Homework.FileLogWriter":
                    return new FileLogWriter(parameters.ToString());
                case "Homework.MultipleLogWriter":
                    return new MultipleLogWriter((List<ILogWriter>)parameters);
                case "Homework.ConsoleLogWriter":
                    return new ConsoleLogWriter();
                default:
                    throw new Exception("switch (typeof(T)) exception");
            }
                
        }    


    }
}
