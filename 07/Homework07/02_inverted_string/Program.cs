using System;

namespace _02_inverted_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Enter non-empty string");
                try
                {
                    input = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("String seems too long");
                    continue;
                }
                string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 0)
                    break;
                Console.WriteLine("Empty string");
            } while (true);

            for (int i = 0; i < input.Length; i++)
                Console.Write(input[input.Length - 1 - i]);
        }
    }
}