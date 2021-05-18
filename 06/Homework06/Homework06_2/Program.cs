using System;

namespace Homework06_2
{
    class Program
    {
        static void Main(string[] args)
        {
            float contribution = 0;
            float accumulationPercentage = 0;
            float desiredOutput = 0;
            ushort daysToWait = 0;

            UserInputFloatParsing("Enter your contribution: ", out contribution);
            UserInputFloatParsing("Enter accumulation percentage: ", out accumulationPercentage);
            UserInputFloatParsing("Enter desired output: ", out desiredOutput);
            
            for (float moneyThatDay = contribution;
                moneyThatDay < desiredOutput;
                daysToWait++)
                moneyThatDay *= (1f + accumulationPercentage / 100f);

            Console.WriteLine($"Days until you get desired value: {daysToWait}");

        }
        static void UserInputFloatParsing(string s, out float inputed)
        {
            do
            {
                Console.Write(s);
                try
                {
                    inputed = float.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error input! Try again.");
                    continue;
                }
                break;
            } while (true);
        }
    }
}
