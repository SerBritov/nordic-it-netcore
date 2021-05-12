using System;

namespace _03_SWITCH
{
    class Program
    {
        public enum Color
        {
            Red,
            Green,
            Blue,
            Yellow,
            White,
            Black
        }
        static void Main(string[] args)
        {
            /*
             * switch -- проверяет переменную на конкретные значения через перечисление
             * 
             */
            var randomInstance = new Random();
            for (int i = 0; i < 10; i++)
            {
                Color c = (Color)(randomInstance.Next(0, 6));    //.Next выдает значение от первого числа включительно до второго исключительно
                switch (c)
                {
                    case Color.Red:
                        Console.WriteLine("Red");
                        break;
                    case Color.Green:
                        Console.WriteLine("Green");
                        break;
                    case Color.Blue:
                    case Color.Yellow:
                        Console.WriteLine("Blue or Yellow");
                        break;
                    default:
                        Console.WriteLine("Unknown");
                        break;
                }
            }
            Console.WriteLine("");
        }
    }
}
