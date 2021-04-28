using System;

namespace _07_enums
{
	class Program
	{
		/*
		 * код ОПИСАНИЯ переменных описывается в классах
		 */
		enum Day { Monday, Tuesday, Wensday, Thursday, Friday, Saturday, Sunday };
		enum DayTime: byte
		{
			Morning = 8,
			Midday =12,
			Day = 15,
			Evening = 20,
			Night = 0
		}
		enum Season : byte
		{
			Winter = 3,
			Spring = 6,
			Summer = 9,
			Autumn = 12
		}
		static void Main(string[] args)
		{
			Console.WriteLine("Enumerators");
			/*
			 * Тип перечисления необходимы для набора именованных коснстант, который можно назвать переменной
			 */
			Day today = Day.Wensday;
			Console.WriteLine(today);
			var dayTime = (DayTime)Enum.Parse(
				typeof(DayTime), 
				Console.ReadLine());
			Console.WriteLine(dayTime);

			Season season = Season.Spring;
			season++;
			for (; season.ToString().Length < 3 ; season++) ;
			Console.WriteLine(season);
			

		}
	}
}
