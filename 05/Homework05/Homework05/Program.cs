using System;

namespace Homework05
{
    class Program
    {
        const double pi = 3.1415;
        enum Figure : byte
        {
            Circle = 1,
            Triangle = 2,
            Rectangle = 3
        }
        static void Main(string[] args)
        {
            double perimetr, square;
            Figure choice = (Figure)0;
            do
            {
                Console.WriteLine("Choose figure:");
                Console.WriteLine("1.Circle");
                Console.WriteLine("2.Triangle");
                Console.WriteLine("3.Rectangle");
                try
                {
                    choice = (Figure)int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(Figure), choice))
                        break;
                }
                catch { }
                Console.WriteLine("Wrong command! Try again.");
            } while (true);

            switch (choice)
            {
                case Figure.Circle:
                    CircleParams(out perimetr, out square);
                    break;
                case Figure.Triangle:
                    TriangleParams(out perimetr, out square);
                    break;
                case Figure.Rectangle:
                    RectangleParams(out perimetr, out square);
                    break;
                default:
                    throw new InvalidOperationException("wrong command");
            }

            Console.WriteLine($"perimetr = {perimetr}; square = {square}");
        }

        static void CircleParams(out double per, out double sqr)
        {
            double diametr;
            Console.Write("Diametr = ");
            try
            {
                diametr = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            per = pi * diametr;
            sqr = pi * diametr * diametr / 4.0;
            return;
        }

        static void TriangleParams(out double per, out double sqr)
        {
            double sideLength;
            Console.WriteLine("Length = ");
            try
            {
                sideLength = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            per = sideLength * 3;
            sqr = Math.Sqrt(3) * sideLength / 4.0;

        }

        static void RectangleParams(out double per, out double sqr)
        {
            double length, width;
            Console.WriteLine("Length = ");
            try
            {
                length = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.WriteLine("Width = ");
            try
            {
                width = double.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            per = 2 * (length + width);
            sqr = length * width;
            return;
        }
    }
}
