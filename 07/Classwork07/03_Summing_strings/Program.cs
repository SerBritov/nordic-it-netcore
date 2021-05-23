using System;

namespace _03_Summing_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Конкатенация строк
             */
            string hello = "Hello";
            string world = "World";

            Console.WriteLine(hello+" " + world+ "!");

            Console.WriteLine(hello + " " + 25);

            /*
             * format -- позволяет получить строку используя шаблон
             */

            string welcomeStringTemplate = "Hello {0}!\nWelcome to {1}";
            int value = 1;
            Console.WriteLine(string.Format(welcomeStringTemplate, world, value) ); //выводит строку, где {0} и {1} были заменены на world и value соответственно
            welcomeStringTemplate = "Hello {1}!\nWelcome to {0}";
            Console.WriteLine(string.Format(welcomeStringTemplate, value, world));

            float[] distances = { 1f, -21.536f, 0.026f };
            DateTimeOffset[] dates =
                {
                DateTimeOffset.Now,
                DateTimeOffset.MinValue,
                DateTimeOffset.MaxValue
                };

            foreach (var distance in distances)
            {
                Console.WriteLine(string.Format("Distance is {0:#.##}", distance)); //{0: #.##} после двоеточия будет обозначено форматирование
                Console.WriteLine(string.Format("Distance is {0:0.0#}", distance)); //# -- выводиться только если этот символ значащий. 
                Console.WriteLine(string.Format("Distance is {0:0.000000}", distance)); //0 -- выводить 0 в этом месте
            }

            foreach (var date in dates)
            {
                Console.WriteLine(string.Format("Date is {0}", date));
                Console.WriteLine(string.Format("Date is {0:dd.MM.yyyy HH:mm:ss.ffff}", date));
                Console.WriteLine(string.Format("Date is {0:MM.yy HH:mm}", date));
                Console.WriteLine(string.Format("Date is {0:MMM dddd(HH mm)}", date));
                Console.WriteLine(string.Format("Date is {0:t}", date));    //U -- универсальный шаблон
            }

            /*
             * Интерполяция
             * $ в начале строки делает интерполяцию
             */

            double i = 431.2131;
            double j = 321.2111;
            Console.WriteLine($"{i:0.00}/{j:0.00} = {i/j:0.###}");
        }
    }
}
