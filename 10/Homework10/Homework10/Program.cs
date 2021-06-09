using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework10
{
    class Program
    {
        static void Main(string[] args)
        {
            const byte length = 3;
            Person[] persons = new Person[length];

            for (int i = 0; i < length; i++)
            {
                persons[i] = new Person();
                Console.Write("Enter name: ");
                persons[i].Name = Console.ReadLine();
                Console.Write($"Enter {persons[i].Name}'s age: ");
                persons[i].Age = (byte)(IntInput());
            }

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Name: {persons[i].Name}; age in {persons[i].SomeYears} years: {persons[i].AgeInSomeYears}");
            }
            Console.ReadKey();
        }

        static int IntInput()
        {
            int result;
            do
                try
                {
                    result = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Use only digits! Try again.");
                    continue;
                }
            while (true);
            return result;
        }
    }
}
