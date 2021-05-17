using System;

namespace _04_Selfwork
{
	class Program
	{
		static void Main(string[] args)
		{

			int length;
			string input;
			do
			{
				Console.WriteLine("Enter string");
				input = Console.ReadLine();
				if (input == "exit")
					break;
				length = input.Length;
				if (length > 15)
				{
					Console.WriteLine("Too long string. Try another");
					continue;
				}

				Console.WriteLine($"Entered string length is {length}");
			} while (true);
		}
	}
}
