using System;

namespace _09_For_each
{
	class Program
	{
		static void Main(string[] args)
		{
			var marks = new[]
			{
				new[] {2, 3, 3, 2, 3},
				new[] {2, 4, 5, 3 },
				null,
				new[] {5, 5, 5, 5},
				new[] {4 }
			};

			/*
			 * для каждого элемента в массиве marks (элемент этого массива -- массив), 
			 * который обозначен как аrray и имеет тип int[] совершить действия в блоке
			 */
			foreach(int[] array in marks)
			{
				Console.WriteLine(array != null? array.Length: -1);
			}

			float[] fNumbers = new float[0];
			foreach(float fNumber in fNumbers)
				Console.WriteLine(fNumber);


		}
	}
}
