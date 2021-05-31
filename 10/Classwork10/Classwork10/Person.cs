using System;

namespace Classwork10
{
	class Person
	{
		private DateTimeOffset _dateOfBirth;

		public string Name2;        //поле с типом string, обращение к полю происходит быстрее
		public string Name { get; set; }    //свойство с типом string, данные записываются стандартно как get {return Name} set{Name = value}

		private int _age;       //все закрытые поля именуются начиная с "_". к нему нет доступа

		public int Age          //публичное свойство, с которым можно явно работать
		{
			get                 //получение свойства Age описывается блоком ниже
			{
				return _age;
			}
			set                 //запись в Age приводит к выполнению блока ниже. value -- значение, которое присваивается Age при выполнении программы
			{
				if (value >= 0 && value < 140)
					_age = value;
				else
				{
					throw new InvalidOperationException("Age should be in range [0...140)");
				}
			}
		}

		public void SetDateOfBirth(DateTimeOffset dateOfBirth)
		{
			_dateOfBirth = dateOfBirth;
		}

		public DateTimeOffset getDateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
		}
	}
}

/*
 * Порядок объявления членов классов
 */
//private fields
//public fields

//private properties
//public properties

//constructor(s)

//private methods
//public methods