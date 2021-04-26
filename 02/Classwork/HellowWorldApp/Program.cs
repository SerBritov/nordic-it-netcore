using System;
using System.Text;
namespace HellowWorldApp
{/// <summary>
 /// Для публичных классов и методов
 /// </summary>
	class Program
	{/// <summary>
	 /// Main main main
	 /// </summary>
	 /// <param name="args">args args</param>
		/*
         * комментарии. Выделение CTRL + K, C 
         * Убрать комментарий CTRL + K, U
         */
		static void Main(string[] args)
		{
			Console.InputEncoding = Encoding.Unicode;   //support unicode for input
			Console.OutputEncoding = Encoding.Unicode;  //support unicode for output
			Console.Write("Введите имя: ");
			/*string name = Console.ReadLine();
			Console.WriteLine(
				$"Привет, {name}!");*/
			Console.WriteLine(
				$"Привет, {Console.ReadLine()}");
			Console.ReadKey();
			/*проверка видимости
			 * int a = 0;
			{
				a =1;
			}
			Console.WriteLine(a);
			Console.ReadKey();*/

			/*
			 * объявление переменных
			 * переменные не могут начинаться с числа
			 * в переменные кладутся буквальные значения
			 * объявлять следует как camelCase
			 * но глобальные переменные объявлять с большой буквы
			 */

			int intExample;
			int intSecondExample = 10;
			string s1 = "Sergey";
			s1 = Console.ReadLine();

			//char - это и символ, и целочисленное значение в нем
			char symbol = '@';
			//float и double занимают 4 и 8 байта соответственно
			//когда пишется буквальное дробное значение, то это значение считается как double
			//для объявления буквального значения float требуется в конце числа написать f
			double doubleExample = 123.123;
			float pi = 3.1415f;     //f

			bool birdIsFlying = true; //булевые переменные следует объявлять как утверждение
			char letter = 'A';
			System.Char letter2 = 'B';
			Console.WriteLine(letter);
			letter++;
			Console.WriteLine(letter);
			Console.WriteLine((int)letter);
			intExample = letter;
			Console.WriteLine(intExample);

			string name = "Alice";
			System.String name2 = "Bob";
			Console.WriteLine(name);
			name += letter; //name=letter не вышло
			Console.WriteLine(name);
			name += intExample; //name = intExample не вышло
			Console.WriteLine(name);

			/*
			 * Целые числа
			 */
			byte age = 36; //до 255 включительно, только положительные
			byte age2 = age;
			Console.WriteLine(age2);

			sbyte temp = -128; //signed byte, -128...127
			System.SByte temp2 = temp;
			Console.WriteLine(temp2);

			short pressure = -21200; //-32768...32767. Два байта
			System.Int16 pressure2 = pressure;
			Console.WriteLine(pressure2);
			ushort yearOfBirth = 1992; //0..65635, беззнаковый short
			System.UInt16 yearOfBirth2 = 1992;
			int integerExample = 65636; //4 байта
			System.Int32 integerExample2 = integerExample;
			Console.WriteLine(integerExample2);
			uint uIntExample = 65635 * 32326;   //беззнаковый инт
			System.UInt32 uIntExample2 = uIntExample;
			Console.WriteLine(uIntExample2);
			long longIntValue = 846464879764564;    //8 байт
			System.Int64 lontIntValue2 = longIntValue;
			Console.WriteLine(lontIntValue2);

			/*
			 * Числа с плавающей точкой
			 * 
			 */
			float floatExample = 3.5F;  // 4 байта, F в конце
			System.Single floatExample2 = floatExample * 2.5F;
			Console.WriteLine(floatExample2);
			double d = -3.5;    //8 байт
			System.Double d2 = d / 3;
			Console.WriteLine(d2);

			//----------------------
			Console.WriteLine();
			Console.Write("Введите Ваш возраст: ");
			int myAge = int.Parse(Console.ReadLine());
			Console.WriteLine(myAge * 2);

			/*
			 * Булевые значения
			 */
			bool b1 = true;
			System.Boolean b2 = !b1;    //отрицание
										//Операторы для булевых значений
			Console.WriteLine();
			Console.WriteLine(3 < 7); //сравнение
			Console.WriteLine();
			Console.WriteLine("asdf" == "ASDF");    //проверка равенства
			Console.WriteLine(3.14f == 3.14);   //false
			Console.WriteLine((double)3.14f == 3.14);   //false
			Console.WriteLine(b1 == false); //нужно писать !b1
			Console.WriteLine(b2 == false); //!b2
											//(b1 == true) = (b1); (b2 == true) = b2;
			Console.WriteLine(3.14 != 3.14);    //проверка неравенства

			/*
			 * Логические операции
			 */
			// && - AND
			// || - OR
			Console.WriteLine(true || false);
			Console.WriteLine(true && false);
			//Логические операции выполняются по следующему приоритету ! - && - ||
			Console.WriteLine();


			/*
			 * Побитовые операторы
			 */
			int a1 = 0b0000001; //бинарное число объявляется 0b в начале
			int a2 = 0b0000011; //3
			Console.WriteLine(a1 | a2);   //0b00000011
			/* 0b00000001; a1
			 * 0b00000011; a2
			 * 0b00000011; a1|a2
			 * 0b00000010; a1&a2;
			 */
		}
	}
}
