using System;
using System.Runtime.CompilerServices;

namespace _05_String_Modigy
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * replace -- заменить все найденные подстроки на другую подстроку
             */
            string a = "my test string/test";
            string b = a.Replace("test", "best");
            
            Console.WriteLine(a + "\n"+b);
            /*
             * Substring -- взять подстроку начиная с символа под индексом и до конца либо заданное число символов
             */
            string c = a.Substring(3, 4);
            Console.WriteLine(c);
            /*
             * Split -- разделить строку на массив подстрок с заданным символом в качестве разделителя
             */
            string[] lines = a.Split(' ');
            foreach(var line in lines)
                Console.WriteLine($"{line}: {line.Length}");

            string[] lines1 = "here  we  go".Split(' ');    //в строке несколько пробелов подряд и созданы лишние пустые строки
            foreach(var line in lines1)
                Console.WriteLine($"{line}: {line.Length}");

            string[] lines2 = "here  we  go".Split(' ', StringSplitOptions.RemoveEmptyEntries); //позволяет убрать пустые подстроки
            foreach (var line in lines2)
                Console.WriteLine($"{line}: {line.Length}");
            /*
             * Join -- объединение массивов строк через разделитель
             */
            Console.WriteLine(string.Join("*", lines ));
            Console.WriteLine(lines);
        }   
    }
}
