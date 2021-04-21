using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Greetings();

			void Greetings()
			{
				Console.InputEncoding = Encoding.Unicode;
				Console.OutputEncoding = Encoding.Unicode;
				Console.WriteLine("Как вас зовут?");

				string name;
				name = Console.ReadLine();
				Thread.Sleep(5000);
				Console.WriteLine($"Здравствуйте, {name}!");
				Thread.Sleep(5000);
				Console.WriteLine($"До встречи, {name}!");
				Console.ReadKey();
				/*Если нужно приветствовать множество людей*/
				/*Thread.Sleep(1000);
				Console.WriteLine("Хотите еще кого-нибудь поприветствовать?y/n");
				if Console.ReadKey() == "y" 
					Greetings();*/
				
			}

		}
	}
}
