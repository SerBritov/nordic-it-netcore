using System;
using System.Collections.Generic;

namespace _01_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var doubleList = new List<double>();
            string input;
            do
            {
                Console.Write("Enter double: ");
                input = Console.ReadLine();
                if (input == "stop")
                    break;
                try
                {
                    doubleList.Add(double.Parse(input));
                }
                catch
                {
                    Console.WriteLine("Wrong input");
                    throw;
                }
            } while (true);

            int i = 0;
            double sum = 0;
            foreach (double element in doubleList)
            {
                sum += element;
                i++;
            }
            if (i == 0)
                Console.WriteLine("List has no elements");
            else
                Console.WriteLine($"Sum = {sum:#.###}, average = {sum / i:#.###}");
        }
    }
}
