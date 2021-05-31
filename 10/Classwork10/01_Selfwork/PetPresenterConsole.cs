using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Selfwork
{
	class PetPresenterConsole
	{
		public void Present(Pet pet)
		{
			Console.WriteLine(pet.PropertiesString);
		}
	}
}
