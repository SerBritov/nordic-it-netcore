using System;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
			Console.WriteLine("Имя");
						
			string name;
			name = Console.ReadLine();
			Thread.Sleep(5000);
			Console.WriteLine($"Здравствуйте, {name}!");
			/*Thread.Sleep(1000);
			Console.WriteLine("Хотите еще кого-нибудь поприветствовать?y/n");
			if Console.ReadKey() == "y" */
				


		}
	}
}
