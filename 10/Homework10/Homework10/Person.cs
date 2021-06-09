using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10
{
    class Person
    {        
        public string Name;
        public byte Age;
        public byte SomeYears
        {
            get
            {
                return (byte)4;
            }
            set { }
        }
        public byte AgeInSomeYears
        {
            get { return (byte)(Age + SomeYears); }
            set { }
        }
    }
}
