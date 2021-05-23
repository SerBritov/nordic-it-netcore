using System;

namespace _03_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            float a, b;
            Console.Write("Enter first number: ");
            a = float.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            b = float.Parse(Console.ReadLine());

            Console.WriteLine(a + " * " + b + " = " + (a * b).ToString("0.##"));
            Console.WriteLine(string.Format("{0} + {1} = {2:0.##}", a, b, a+b));
            Console.WriteLine($"{a} - {b} = {(a-b):0.##}");
        }
    }
}
