using System;

namespace _04_type_casting
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Explicit/implicit castig");
			/*
			 * существует явное и неявное приведение типов
			 * implicit -- неявное
			 */
			/*примеры неявных приведений*/
			int a = 10;
			double b = a;
			var c = a + 0.1f+ 0.2;  //double
			/*нельзя неявно приводить типы в сторону потенциальной потери данных*/
			//int d = c; error
			/*для этого нужно выполнить явное приведение*/
			int d = (int)c;
			Console.WriteLine("d = " + d + "; c = " +c);

			long e = 10;
			int f = (int)e;
			Console.WriteLine(f);
			Console.WriteLine(e);

			e = long.MaxValue;
			f = (int)e;
			Console.WriteLine(e);
			Console.WriteLine(f);
			e = 10;

			checked		//выход из программы в случае проблем(?), например, при опасном приведении типов
			{
				f = (int)e;
				Console.WriteLine(e);
				Console.WriteLine(f);
			}


		}
	}
}
