using System;

namespace _02_inc_dc
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Increment/decrement");
			/*
			 * ++i, i++ -- увеличение переменной на единицу
			 * в первому случае переменная будет изменена до того, как с ней будут производиться действия
			 * во втором -- после
			 */
			int a = 0;
			int b = 0;
			Console.WriteLine(a++); //0
			Console.WriteLine(++b); //1
			Console.WriteLine(++a); //2
			Console.WriteLine(b++); //1

			var c = 15;
			var d = c++;
			var e = ++c;
			Console.WriteLine("c = " + c + "; d = " + d + "; e = " + e);
			/*
			 * --i, i-- -- уменьшение переменной на единицу
			 */
			int x = 0, y = --x,/*-1*/ z = x--/*-1*/ /*x = -2*/;

			/*
			 * логическое отрицание
			 */
			bool m = true;
			bool n = !m;    //false

		}
	}
}
