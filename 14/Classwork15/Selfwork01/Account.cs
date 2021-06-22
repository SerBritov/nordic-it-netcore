using System;
using System.Collections.Generic;
using System.Text;

namespace Selfwork01
{
    public  class Account<T>: IAccount 
    {
        public T Id { get; private set; }
        public string Name { get; private set; }

        public  Account(T id, string name)
        {
            Id = id;
            Name = name;
        }

        public void WriteProperties()
        {
            Console.WriteLine($"Id = {Id}; Name = {Name}");
        }
    }

    public interface IAccount
    {
        public void WriteProperties();
    }
}
