using System;
using System.Collections.Generic;
using System.Text;

namespace _01_Selfwork
{
	class Pet
	{
		private Location _birthPlace = new Location();
		private byte _age;
		private char _sex;

		public string Name;
		public AnimalKind Kind;

		public char Sex
		{
			get
			{
				return _sex;
			}
			set
			{
				switch (value)
				{
					case 'm':
					case 'M':
						_sex = 'M';
						break;
					case 'f':
					case 'F':
						_sex = 'F';
						break;
					default:
						throw new InvalidOperationException("Sex can be either M or F");
				}
			}
		}

		public byte Age          //публичное свойство, с которым можно явно работать
		{
			get                 //получение свойства Age описывается блоком ниже
			{
				return _age;
			}
			set                 //запись в Age приводит к выполнению блока ниже. value -- значение, которое присваивается Age при выполнении программы
			{
				if (value >= 0 && value < 40)
					_age = value;
				else
				{
					throw new InvalidOperationException("Age should be in range [0...40)");
				}
			}
		}

		public string PropertiesString		//get-only, свойство, которое можно только прочитать
		{
			get
			{
				return $"{Name} is a {Kind}({Sex}) of {Age} years old from {getBirthPlace}";
			}
		}

		public string getBirthPlace
		{
			get
			{
				return $"{_birthPlace.City}, {_birthPlace.Country}";
			}
		}

		public void WriteInfo()
		{
			Console.WriteLine($"{Name} is a {Kind}({Sex}) of {Age} years old from {getBirthPlace}");
		}

		public void SetBirthPlace(string country, string city)
		{
			_birthPlace.Country = country;
			_birthPlace.City = city;
		}

	}
}
	