
using System;


namespace sw2
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> Perimetr = (radius) => 2 * Math.PI * radius;
            Func<double, double> Square = (radius) => Math.PI * radius * radius;

            var circle = new Circle.Core.Circle(1.5);

            Console.WriteLine($"Perimetr = {circle.Calculate((r) => 2 * Math.PI * r)}; Square = {circle.Calculate((r) => Math.PI * r * r)}; Diametr = {circle.Calculate(r => r * 2)}");
        }
    }
    }

