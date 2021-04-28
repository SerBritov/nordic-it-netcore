using System;

namespace _06_complex_expressions
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Complex expressions");
			double a = 3, b = 4;
			double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
			Console.WriteLine(c);

			Console.WriteLine();

			double a1, h, n;    //1, 6, 2.5
			a1 = double.Parse(Console.ReadLine());
			h = double.Parse(Console.ReadLine());
			n = double.Parse(Console.ReadLine());

			double x =
				a1 / (2 * Math.Tan(Math.PI / n));
			double y =
				Math.Sqrt(h * h + x * x);
			double sFull =
				n * a1 / 2 * (x + y);
			double sRear =
				n * a1 / 2 * y;
			double volume =
				h * n * a1 / 6 * x;

			Console.WriteLine(sFull);   //	10,5
			Console.WriteLine(sRear);   //	7,9
			Console.WriteLine(volume);  //	2,16

			
		}
	}
}
