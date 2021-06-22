using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _01_Selfwork
{
    public class ErrorList : IDisposable, IEnumerable<string>
    {
        public static string OutputPrefixFormat
        { get; set; }
        
        static ErrorList()
        {
            OutputPrefixFormat = "dd-MM-yyyy (hh:mm)";
        }
        public string Category { get; private set; }

        private List<string> _errors;

        public ErrorList(string category)
        {
            Category = category;
            _errors = new List<string>();
        }

        public void Add(string adding)
        {
            _errors.Add(adding);
        }

        public void Dispose()
        {
            _errors.Clear();
            _errors = null;
        }

        public void WriteToConsole()
        {
            foreach (var error in _errors)
            {
                Console.WriteLine(
                    $"{DateTime.Now.ToString(OutputPrefixFormat)}: {Category}: {error}");
        }
    }

    public IEnumerator<string> GetEnumerator()
    {
        return _errors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
}
