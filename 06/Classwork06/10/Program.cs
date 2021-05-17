using System;

namespace _10
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Enter text to crypt:  ");
			string source = Console.ReadLine();
			Console.Write("Enter shift crypto key: ");
			int key = int.Parse(Console.ReadLine());
			Console.WriteLine();
			Console.Write("Encrypted string: ");

			foreach (char letter in source)
			{
				Console.Write((char)(letter + key));
			}
			Console.ReadKey();
		}
	}
}
