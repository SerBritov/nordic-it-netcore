using System;

namespace _06_Double_Cycle
{
	class Program
	{
		static void Main(string[] args)
		{
			bool isOkay = true;
			int a = 0;
			int b = 0;
			do
			{
				do
				{
					Console.Write("Enter a number");
					try
					{
						a = int.Parse(Console.ReadLine());
					}
					catch
					{
						continue;
					}

					Console.Write("Enter b number");
					try
					{
						b = int.Parse(Console.ReadLine());
					}
					catch
					{
						continue;
					}
					break;
				} while (true);
				Console.WriteLine($"{a}+{b} = {a + b}");
				Console.WriteLine("Enter 'continue' to continue");
			} while (Console.ReadLine() == "continue");
		}
	}
}
