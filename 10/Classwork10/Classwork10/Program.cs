using System;

namespace Classwork10
{
	class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Person p1 = new Person();       //создание объекта класса Person при помощи конструктора (метода) Person()

			p1.Age = 100;
			p1.Name = "Some Name";      //вызов свойства
			p1.Name2 = "Some Name";     //вызов поля
			Console.WriteLine($"Age is: {p1.Age}");
			Console.WriteLine($"Name is {p1.Name}");
			Console.WriteLine($"Name is {p1.Name2}");

			p1.SetDateOfBirth(DateTimeOffset.Parse("2010-10-3+0300"));
			Console.WriteLine($"{p1.getDateOfBirth:dd.MM.yyy}");
		}
	}
}
