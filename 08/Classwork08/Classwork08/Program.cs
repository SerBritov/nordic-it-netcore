using System;
using System.Collections.Generic;
namespace Classwork08
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Список List<T> -- класс для списка однотипных проектов
             * <T> -- тип данных
             */
            var intArray = new[] { 4, 5, 6, 7 };
            var intList = new List<int> { 1, 2, 3, 4 };

            intList.Add(5); //добавить элемент в список
            intList.AddRange(intArray); //добавить массив в список
            
            Console.WriteLine(string.Join(',', intList));
            intList.Insert(3, 10);  //вставить в позицию 3 значение 10
            Console.WriteLine(string.Join(',', intList));
            intList.Sort();
            Console.WriteLine(string.Join(',', intList));

        }
    }
}
