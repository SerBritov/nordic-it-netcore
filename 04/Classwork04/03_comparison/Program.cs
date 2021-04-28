using System;

namespace _03_comparison
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Comparison operators");

			/*
			 * Сравнивать между собой можно числа, символы
			 * можно проверить строки на равенство, но не сравнить их
			 * 
			 */
			Console.WriteLine(10 > 15);
			Console.WriteLine(10 <= 15);
			Console.WriteLine(10 != 15);
			Console.WriteLine("10" == "10");
			Console.WriteLine('1' > '0');

			int a = 18, b = a++;
			Console.WriteLine($"a==b: " + (a == b));
			Console.WriteLine($"a!=b: " + (a != b));
			Console.WriteLine($"a>b: " + (a > b));
			Console.WriteLine($"a<b: " + (a < b));
			Console.WriteLine($"a>=b: " + (a >= b));
			Console.WriteLine($"a<=b: " + (a <= b));
		}
	}
}
