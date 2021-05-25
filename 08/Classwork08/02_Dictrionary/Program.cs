using System;
using System.Collections.Generic;

namespace _02_Dictrionary
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Ditionary<T1,T2> -- словарь, который представляет пару ключ-значение
             * Ключ однозначно указывает на значение
             * Значение не указывает на ключ
             * Типы данных могут различаться
             */
            //Инициализация
            Dictionary<string, int> contents = new Dictionary<string, int>()
            {
                { "Введение", 1},
                { "Основная часть", 5},
                { "Заключение", 20}
            };

            contents.Add("Предисловие", 0);
            contents.Add("Послесловие", 25);

            Console.WriteLine($"Предисловие - {contents["Предисловие"]}");  //получение значения по ключу

            Console.Write(" 5 - ");
            foreach (KeyValuePair<string, int> pair in contents)
                if (pair.Value == 5)
                    Console.WriteLine(pair.Key);

            Console.WriteLine(contents.ContainsKey("Примечание"));
            Console.WriteLine(contents.ContainsValue(100));

            contents["Основная часть"] = 10; //добавить или отредактировать элемент

        }
    }
}
