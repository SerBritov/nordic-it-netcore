using System;

namespace _03_CONTINUE
{
	class Program
	{
		static void Main(string[] args)
		{/*
		  * Continue -- оператор пропуска операций в теле цикла
		  */
			int sum = 0, i;
			Console.WriteLine("Hello World!");
			do
			{
				try
				{
					i = int.Parse(Console.ReadLine());
				}
				catch (Exception)
				{
					Console.WriteLine("Wrong input");
					continue;
				}
				sum += i;	//если был неверный ввод, оператор continue вернет нас к началу цикла
			} while (sum < 100);


		}
	}
}
