using System;


namespace _02_ESCAPE_special_symbols
{
    class Program
    {
        static void Main(string[] args)
        {   /*
             * Escape-последовательности -- последовательность символов, которая не воспринимается буквально
             */
            Console.WriteLine("Hello     World!");
            Console.WriteLine("Hello\tWorld");  //табуляция
            Console.WriteLine("Hello\nWorld");  //новая строка
            Console.WriteLine("Hello\rWorld");  //"возврат каретки" -- возврат курсора в начало строки и перезапись начиная с первого символа
            Console.WriteLine("Hello World\r Removed");
            Console.Write("Hello");
            Console.WriteLine("\rRemoved");
            Console.WriteLine("\u2665");    //unicode-символ с кодом
            Console.WriteLine("Hello World\aWarning");  //Звуковой сигнал
            Console.WriteLine("Hello \' world \""); //кавычки
            Console.WriteLine("Hello \f world");
            Console.WriteLine("C:\\temp\\test.file.txt");   //писать путь к файлу нужно с использованием escape-последовательности
            Console.WriteLine("C:\temp\test.file.txt");
            /*
             * буквальные строковые литералы @
             * это указание на то, что в строке нет escape-последовательности, то есть строка считается буквальной
             */
            Console.WriteLine(@"C:\temp\test.file.txt");
            string multiline = @"first line
second line
third line";
            Console.WriteLine(multiline);

            char c = '\u2665';  //escape-последовательности являются символами
            Console.WriteLine("C:\\temp\\test.file.txt" == @"C:\temp\test.file.txt");   //true, буквальный строковой литерал представляет строку для разработчика, но не является свойством строки
            Console.WriteLine(@"""test"""); //использование двойных двойных кавычек -- единственный способ написать двойные кавычки с буквальным литералом
        }
    }
}
