using System;
using System.Reflection.Metadata.Ecma335;

namespace Selfwork01
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> Perimetr = (radius) => 2 * Math.PI * radius;
            Func<double, double> Square = (radius) => Math.PI * radius * radius;

            Circle circle = new Circle(1.5);

            Console.WriteLine($"Perimetr = {circle.Calculate((r) => 2 * Math.PI * r)}; Square = {circle.Calculate((r) => Math.PI * r * r)}; Diametr = {circle.Calculate(r=>r*2)}");
        }
    }
}
