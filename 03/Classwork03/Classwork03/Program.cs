using System;

namespace Classwork03
{
	class Program
	{
		static void Main(string[] args)
		{
			//CTRL+R,R --rename, rename, переименовать переменную/метод и тд. за один раз вов сех местах
			ConstantLessonPart();
			Console.WriteLine();
			
			ObjectLessonPart();
			Console.WriteLine();
			
			DynamicLessonPart();
			Console.WriteLine();
			
			VarLessonPart();
			Console.WriteLine();
			
			ReferenceTypeLessonPart();
			Console.WriteLine();

			NullableLessonPart();
			Console.WriteLine();

			ArraysLessonPart();
			Console.WriteLine();

		}

		static void ConstantLessonPart()	//постоянные величины, которые не могут изменяться
		{
			Console.WriteLine("ConstantLessonPart");
			const string name = "Masha";
			const int age = 20;
			
			string welcomeText = "hello" + name;
			//name = "Petya"; нельзя
			int[] array = { 10, -22, 3, 0, 7 };
			int[] array2 = new int[5];
			for (int i = 0; i < 5; i++)
				array2[i] = array[i] * array[i];
			for (int i = 4; i>=0; i--)
				Console.WriteLine($"{array[i]}:{array[i]} = {array2[i]}");  //$ нужен чтобы не читать {} как часть строки
			/*
			 * сверху большой код, в котором случае изменения размерности массива придется делать изменения в половине строк
			 */
			/*
			 * исправленный код с учетом констант ниже
			 */
			const int numberOfItems = 7;
			int[] array3 = { 10, -22, 3, 0, 7 , 3, 1};
			int[] array4 = new int[numberOfItems];
			for (int i = 0; i < numberOfItems; i++)
				array4[i] = array3[i] * array3[i];
			for (int i = numberOfItems-1; i >= 0; i--)
				Console.WriteLine($"{array3[i]}:{array3[i]} = {array4[i]}");


		}
		static void ObjectLessonPart()
		{
			/*
			 * Тип данных Object
			 * В переменных данного типа можно хранить данные любого типа
			 */
			Console.WriteLine("ObjectLessonPart");
			object name = "Masha";
			Console.WriteLine(name);
			string name2 = "Sasha";
			Console.WriteLine(name2);
			Console.WriteLine($"{name2}, букв в имени : {name2.Length}");

			// не выйдет получить размер строки из данных типпа Object 
			//Console.WriteLine($"{name}, букв в имени : {name.Length}");
			//но можно сделать приведение данных
			Console.WriteLine($"{name}, букв в имени : {((string)name).Length}");
			object integerValue = 2;
			object integerValue2 = 15;
			Console.WriteLine((int)integerValue*(int)integerValue2);	//boxing -- вкладывание простых данных в object. unboxing -- извлекание. 
			//Анбоксинг занимает много времени на вычесления
		}

		static void DynamicLessonPart()
		{/*
		  * тип данных dynamic самостоятельно пытается определить тип данных, вложенный в данный момент
		  * но IDE не дает подсказок по поводу методов и свойств, и не отслеживает опечатку
		  */
			Console.WriteLine("DynamicLessonPart");
			dynamic name = "Masha";
			Console.WriteLine(name.Length);
		}

		static void VarLessonPart()
		{/*
		  * var -- способ объявить переменную, тип данных и значение за одну короткую запись
		  * переменная однозначно получает тип данных на основе инициализирующих значений и не меняет его, как в случае с object и dynamic
		  * 
		  */
			var name = "Alexander";
			Console.WriteLine(name.GetType().Name); //.GetType().Name или .GetType().FullName-- название типа переменной.
			var age = 29;
			Console.WriteLine(age.GetType().FullName);

			//int age2 = int.Parse(Console.ReadLine());	//int.Parse --перевод строки в int
			
		}

		static void ReferenceTypeLessonPart()
		{
			/*
			 * Ссылочные и значимые типы данных
			 * Числа и булевые перменные являются значимыми типами данных (value types)
			 * Значимые данные лежат в определенной области памяти -- номер в памяти (адрес) с которого начинаются эти данные
			 * Пример -- адрес 0х00012: 255, где 0х00012 -- адрес(17 строка, т.к. 0х -- указание на 16ричную систему, 255 -- значение
			 */
			Console.WriteLine("ReferenceTypeLessonPart");
			int A = 255;
			Console.WriteLine(A);
			/*
			 * объекты сохраняются в первое попавшееся место в памяти вне стека
			 * но в стеке пишется адрес памяти вне стека, в которой лежит этот объект
			 * данные, которые хранят адрес данных, а не значение, называются ссылочными
			 * Пример вне стека объект лежит в 0х0А08 и имеет значение object: 0x0A08:object
			 * в стеке будет храниться адрес 0х0008:0х0А08
			 */
			object O = null;	//null позволяет выделить место в памяти для объекта в 0х0000, это означает "Без значения"
			Console.WriteLine(O);
			O = new object();
			Console.WriteLine(O);

			/*
			 * Cтек -- это место в памяти программы, которое контролируемо отдается текущему потоку выполнения
			 * Ссылочные типы лежат в оперативной памяти
			 * 
			 */

			//Garbage Collect -- при выходе из области видимости данные из стека удаляются, но остаются в оперативной памяти
			//данные из оперативной памяти может удалять платформа .Net когда посчитает это выгодным
			//GC.Collect() позволяет вручную удалить ненужные данные
			GC.Collect();

			//default(type) -- возвращает значение по умолчанию для данного типа
			string s = null;
			s = string.Empty;
			string ss = "";
			Console.WriteLine(string.Empty == null);
			Console.WriteLine(default(int));
			var sss = default(string);
			Console.WriteLine(default(string));
			Console.WriteLine(sss);
			sss += default(int);
			Console.WriteLine(sss);
		}

		static void NullableLessonPart()
		{
			/*int a = 0;
			string s = Console.ReadLine();
			int.TryParse(s, out a)) 
			Console.WriteLine(a * a);*/
			/*
			 * В данной программе если а будет равно 0, то будет неизвестно, ввел ли пользователь какие-либо данные
			 * чтобы этого избежать, для буквальных значенений можно принудительно присвоить null
			 *int? -- тип данных, который может принимать null
			 */

			int? a = null;
			if (a.HasValue && a.Value > 0)
				Console.WriteLine(a*a);

			int? a1 = 5;
			float? a2;
			Console.WriteLine("int? a1 ="+a1+"; HasValue = " +a1.HasValue);

			//погуглить GenericMethods
			//сделать метод, который проверяет наличие значений в nullable типах вне зависимости от типа
			static void HasValue()
			{

			}
		}
		static void ArraysLessonPart()
		{/*
		  * Массив необходим для работы с множеством значений одного типа
		  * массивы лежат в стеке подряд с адресами на элементы массива, которые лежат вне стека
		  * для того, чтобы выйти на элемент массива, программа ищет адрес начала и прибавляет произведение элемента и размера данных элемента
		  */
			string[] cities = new string[3];    //вызов конструктора, необходим для объявления массива
			cities[0] = "Moscow";
			cities[1] = "New-York";
			cities[2] = "Dallas";

			for (int i = 0; i < 3; Console.WriteLine(cities[i++])) ;
			for (int i = -1; i < 2; Console.WriteLine(cities[++i])) ;

			Console.WriteLine();

			const int treesNumber = 3;
			string[] trees = new string[treesNumber];
			int[] ages = new int[treesNumber];
			trees[0] = "Ясень";
			trees[1] = "Клен";
			trees[2] = "Липа";
			ages[0] = 21;
			ages[1] = 6;
			ages[2] = 42;
			for (int i = 0; i < trees.Length;
				Console.WriteLine($"{trees[i]} -  возраст в годах {ages[i++]}"));



		}
		
	}
}
