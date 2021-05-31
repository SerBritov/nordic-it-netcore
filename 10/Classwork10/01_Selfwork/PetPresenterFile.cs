using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace _01_Selfwork
{
	class PetPresenterFile
	{
		public void Present(Pet pet, string fileName)
		{
			File.WriteAllText(fileName, pet.PropertiesString);
		}
	}
}
