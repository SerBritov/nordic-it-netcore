using System;

namespace Classwork06
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			 * Оператор do...while выполяет определенный блок кода, пока условное выражение истинно
			 * Условие этого выражение оценивается после выполнения тела цикла, поэтому тело всегда выполняется как минимум один раз
			 */
			
			/*
			 * Программа будет запрашивать у пользователя число до тех пор, пока он не введет целое число
			 */
			int sum = 0;
			string input;
			do
			{
				Console.WriteLine("Enter integer value");
				input = Console.ReadLine();
			}
			while (!int.TryParse(input, out sum));
		}
	}
}
