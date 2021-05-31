using System;

namespace _01_Selfwork
{
	class Program
	{
		static void Main(string[] args)
		{
			PetPresenterConsole petPresenterConsole = new PetPresenterConsole();
			var petPresenterFile = new PetPresenterFile();

			Pet pet1 = new Pet();       //инициализация через свойства
			pet1.Name = "Кисольда";
			pet1.Kind = AnimalKind.Cat;
			pet1.Sex = 'f';
			pet1.Age = 12;
			pet1.SetBirthPlace("Russia", "Moscow");

			pet1.WriteInfo();       //использование метода внутри класса -- так делать не стоит
			Write(pet1);            //использование стороннего метода
			Console.WriteLine(pet1.PropertiesString);       //использование get-only свойства
			petPresenterConsole.Present(pet1);      //использование метода из стороннего класса -- так делать предпочтительнее, чем WriteInfo();
			petPresenterFile.Present(pet1, @"c:\somefile.txt");

			Pet pet2 = new Pet()        //инициализация через инициализатор
			{
				Kind = AnimalKind.Dog,
				Name = "Терри",
				Sex = 'M',
				Age = 7
			};
			pet2.SetBirthPlace("Russia", "St. Petersburg");

			pet2.WriteInfo();
			Write(pet2);
			Console.WriteLine(pet2.PropertiesString);

			void Write(Pet pet) //объявление класса объекта, над которым работает метод
			{
				Console.WriteLine($"{pet.Name} is a {pet.Kind}({pet.Sex}) of {pet.Age} years old");
			}
		}
	}
}
