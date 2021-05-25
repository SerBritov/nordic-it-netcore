using System;
using System.Collections.Generic;

namespace _03_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> intInput = new Queue<int>();
            string input;

            Console.WriteLine("Enter list of integer to calculate; \"run\" for calculation; \"exit\" to exit");

            do
            {
                input = Console.ReadLine();
                if ("exit" == input.ToLower())
                    break;
                if ("run" == input.ToLower())
                {
                    for (; intInput.Count > 0;
                        Console.WriteLine($"sqrt({intInput.Peek()}) = {Math.Sqrt(intInput.Dequeue()):#.###}")) ;
                    continue;
                }
                try
                {
                    intInput.Enqueue(int.Parse(input));
                }
                catch
                {
                    Console.WriteLine("Wrong command!");
                    throw;
                }
            } while (true);

            Console.WriteLine($"Number of cancelled tasks in the queue: {intInput.Count}");

        }
    }
}
