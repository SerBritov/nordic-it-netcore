using System;

namespace Homework06
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            uint userNumber = 0;
            byte evenNumbers = 0;
            Console.Write("Enter your natural number less than 2 billions: ");
            do
            {
                userInput = Console.ReadLine();
                try
                {
                    userNumber = uint.Parse(userInput);
                }
                catch (Exception e)
                {
                    Console.Write(e + "! Try again: ");
                    continue;
                }
                if (userNumber > 2000000)
                    Console.Write("System.OverflowException! Try again: ");
                else if (userNumber == 0)
                    Console.WriteLine("Not natural number! Try again: ");
                else
                    break;
            } while (true);

            foreach (var number in userInput)
            {
                if ((number - '0') % 2 == 0)
                    evenNumbers++;
            }

            Console.WriteLine($"Your number {userInput} have {evenNumbers} even numbers");
        }
    }
}
