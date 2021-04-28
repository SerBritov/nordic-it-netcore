using System;

namespace _01_Arithmetic_operators
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Arithmetic operators");
			int d = (int)(11.5 / 3);
			Console.WriteLine(d);
			Console.WriteLine("11/3=" + 11 / 3);
			Console.WriteLine("11F/3 = " + 11F / 3);
			Console.WriteLine("11.0 / 3 = " + 11.0 / 3);

			Console.WriteLine();
			Console.WriteLine();
			double a1 = 100, b1 = 17;
			double a2 = 48.13, b2 = 2.5;

			AllOperations(a1, b1);
			AllOperations(a2, b2);

		}

		static void AllOperations(double a, double b)
		{
			Console.WriteLine(a + " & " + b);
			Console.WriteLine(a + b);
			Console.WriteLine(a - b);
			Console.WriteLine(a * b);
			Console.WriteLine(a / b);
			Console.WriteLine(a % b);
			Console.WriteLine();
		}
		//ctrl+h -- выделить документ для стандартных команд, типа ctrl+r, ctrl+k,d, ctrl+f etc
	}
}
