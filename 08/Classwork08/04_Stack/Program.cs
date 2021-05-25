using System;
using System.Collections.Generic;

namespace _04_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Стек Stack<T> --в отличии от Queue<T> -- последним пришел - первым обрабатывается
             */

            Stack<bool> boolStack = new Stack<bool>();
            string input;
            Console.WriteLine(@"""Wash"", ""dry"" plates or ""exit""");
            do
            {
                input = Console.ReadLine();
                if ("exit" == input.ToLower())
                    break;
                if ("wash" == input.ToLower())
                    boolStack.Push(true);   //добавление элемента в конец стека
                if ("dry" == input.ToLower())
                {
                    try
                    {
                        boolStack.Pop();    //получение элемента с конца стека и удаление
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Stack of plates is empty");
                        break;
                    }
                }
                Console.WriteLine($"{boolStack.Count} left.");
            } while (true);
            Console.WriteLine($"{boolStack.Count} left.");
        }
    }
}
