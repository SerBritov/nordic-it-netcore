using System;

namespace _05_rounding
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Rounding");
			double i = 9.49;
			double j = 9.5;
			double k = 10.49;
			double l = 10.5;
			double m = 10.51;
			Console.WriteLine(Convert.ToInt32(i));
			Console.WriteLine(Convert.ToInt32(j));
			Console.WriteLine(Convert.ToInt32(k));
			Console.WriteLine(Convert.ToInt32(l));		//не 11
			Console.WriteLine(Convert.ToInt32(m));
			/*
			 * Особенность Convert.
			 * каждое нечетное округляется в большую сторону
			 * каждое четное округляется в меньшую сторону
			 */

			/*
			 * Класс Math (или MathF для работые с float) имеет свои методы
			 */
			double f = Math.Round(l, 0, MidpointRounding.AwayFromZero);
			Console.WriteLine(f);

			float z = 0.15f;
			Console.WriteLine(MathF.Floor(z));	//округление вниз
			Console.WriteLine(MathF.Ceiling(z));	//округление вверх
		}
	}
}
