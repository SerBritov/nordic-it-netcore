using System;

namespace Classwork04
{
	[Flags]
	enum Colours: int
	{
		None = 0,
		Black = 0x1,
		Blue = 0x2,
		Cyan = 0x4,
		Grey = 0x8,
		Green = 0x10,
		Magenta = 0x20,
		Red = 0x40,
		White = 0x80,
		Yellow = 0x100
	}
	class Program
	{
		static void Main(string[] args)
		{
			//Colours pal = (Colours)(0x1FF);
			//Console.WriteLine(pal);
			Colours AllColours = (Colours)(0x1FF);
			for (int i = 1; i<0x200; i*=2)
			{
				Console.WriteLine((Colours)i + "  " + i);
			}
			
			Console.WriteLine("Pick up to 4 favorite colours");
			Colours favoritColours = (Colours)0;
			favoritColours += int.Parse(Console.ReadLine());
			favoritColours += int.Parse(Console.ReadLine());
			favoritColours += int.Parse(Console.ReadLine());
			favoritColours += int.Parse(Console.ReadLine());

			Console.WriteLine(favoritColours);
						
			Colours unFavoriteColours = AllColours ^ favoritColours;
			Console.WriteLine(unFavoriteColours);
		}

		
	}
}
