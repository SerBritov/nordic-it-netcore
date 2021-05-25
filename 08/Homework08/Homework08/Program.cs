using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework08
{
    class Program
    {
        static void Main(string[] args)
        { //label1:
            string input;
            Dictionary<char, char> brackets = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
             };
            Console.WriteLine("Enter your brackets");
            input = Console.ReadLine();
            string[] testInputNonEmpty = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (testInputNonEmpty.Length < 1)
            {
                Console.WriteLine("Empty string");
                return;
            }

            int initialLength;
            do
            {
                initialLength = input.Length;
                foreach (var bracketPair in brackets)
                {
                    for (int i = input.IndexOf(bracketPair.Key);
                        i > -1 && i < input.Length - 1;
                        )
                    {
                        if (input[i + 1] == bracketPair.Value && input[i] == bracketPair.Key)
                        {
                            input = input.Remove(i, 2);
                            i = input.IndexOf(bracketPair.Key);
                            continue;
                        }
                        i++;
                    }
                }

            } while (initialLength != input.Length);
            Console.WriteLine((input.Length == 0));
            //goto label1;
        }
    }
}

