using System;

namespace _07_Rename
{
	class Program
	{
		static void Main(string[] args)
		{/*
		  * while -- цикл с предусловием, и может ни разу не выполниться в отличии от do
		  */
			float[] numbers = { -1.5f, 2.5f, 17.5f, -2f };
			int i = -1;
			float sum = 0;
			while (++i<numbers.Length)
			{
				sum += numbers[i];
				Console.WriteLine(sum);
			}
			
			
		}
	}
}
