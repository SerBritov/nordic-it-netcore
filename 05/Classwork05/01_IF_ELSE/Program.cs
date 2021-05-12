using System;

namespace _01_IF_ELSE
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolValue;
            Console.WriteLine("Press any key to analyze it: ");
            char c = Console.ReadKey(true).KeyChar;     //true -- не показывать клавишу в консольном окне; false -- показать
          //  Console.WriteLine();
            
            if (char.IsLetter(c))   //если нажать на лапочку слева -- будет предложение инвертировать выражение в условии
                Console.WriteLine("You entered letter ");
            else if (char.IsDigit(c))
                Console.WriteLine("You entered a digit ");
            else if (char.IsPunctuation(c))
                Console.WriteLine("You entered a punctuation");
            else
                Console.WriteLine("You entered some strange symbol");

            


        }
    }
}
