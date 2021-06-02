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
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty string");
                return;
            }

            int initialLength;
            do      /*в наихудшем случае каждый цикл будет уменьшать количество символов в строке на 2 и будет выполняться N/2 раз. 
                     *В наилучшем (?) -- на 6, и будет выполняться N/6 раз
                     */
            {
                initialLength = input.Length;
                foreach (var bracketPair in brackets)   //3, т.к. три пары ключей
                {
                    for (int i = input.IndexOf(bracketPair.Key);    //N/2, линейная зависимость от количества символов в строке. Наилучший (?) случай -- N/3
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

/*Все прочие операции не зависят от количества входных данных. 
 * В наихудшем случае -- (N/2)*3*(N/2) = (3/4)N^2 и сводится к порядку N^2;
 * в наилучшем (если входная строка написана правильно) случае (N/6)*3*(N/3) = (1/6)N^2, что также сводится к порядку N^2. 
 * Если за наилучший случай принимать условие, что строка написана неправильно, 
 * то сложность зависит только от внутреннего цикла for и сводится к порядку N^1.
 */
