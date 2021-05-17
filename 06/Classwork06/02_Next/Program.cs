using System;

namespace _02_Next
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Break - досрочный выход из цикла
			 */
			do
			{
				Console.WriteLine("Enter 'exit' to exit");
				if (Console.ReadLine() == "exit")
					break;				
			}
			while (true);
		}
	}
}
