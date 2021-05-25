using System;
using System.Collections.Generic;

namespace Homework08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your brackets");
            string input = Console.ReadLine();
            Dictionary<char, char> bracket = new Dictionary<char, char>()
            {
                {'(', ')' },
                {'{', '}' },
                {'[', ']' },
            };
            List<char> brackets = new List<char>();
            brackets.AddRange(input.ToCharArray());
            int i1, i2, otherPairBetweenIndex = 0;
            bool hasOtherPairBetween;
            foreach (KeyValuePair<char, char> symbol in bracket)
                do
                {
                    if (brackets.Contains(symbol.Key))
                    {
                        i1 = brackets.IndexOf(symbol.Key);
                        i2 = i1 + 1;
                        hasOtherPairBetween = true;
                        do
                        {
                            try
                            {
                                if (brackets[i2] == symbol.Value && hasOtherPairBetween)
                                {
                                    brackets.RemoveAt(i2);
                                    brackets.RemoveAt(i1);
                                    break;
                                }
                                else if (brackets[i2] == symbol.Key)
                                {
                                    i1 = i2;
                                    otherPairBetweenIndex = i2;
                                    hasOtherPairBetween = false;
                                    i2++;        
                                    continue;
                                }
                                i2++;
                                if (bracket[brackets[otherPairBetweenIndex]] == brackets[i2])
                                    hasOtherPairBetween = true;
                            }
                            catch
                            {
                                Console.WriteLine(false);
                                Console.ReadLine();
                                return;
                            }
                        } while (brackets.Contains(symbol.Key));
                    }
                    else break;
                } while (brackets.Count > 0);
            if (brackets.Count >0)
            Console.WriteLine(true);
            else
                Console.WriteLine(false);
            Console.ReadLine();


        }
    }
}
