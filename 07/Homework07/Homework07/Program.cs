using System;

namespace Homework07
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string[] words;
            char symbolToCount = 'a';
            do
            {
                Console.WriteLine("Enter at least 2 words");
                try
                {
                    input = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("String seems too long");
                    continue;
                }
                words = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 1)
                    break;
                Console.WriteLine("Not enough words");
            } while (true);

            int aCounter = 0;
            foreach (var word in words)
            {
                if (word[0] == symbolToCount)
                    aCounter++;
            }

            Console.WriteLine($"Count of words starting with 'a': {aCounter}");
        }
    }
}
