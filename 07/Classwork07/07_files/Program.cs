using System;
using System.IO;
using System.Text;

namespace _07_files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Работа с файлами
             */

            /*
             * 
             */
            const string fileName = @"test.txt";    //если не указан путь, то файл лежит там, где находится исполняемый файл
            const string fileName1 = @".\..\..\..\test.txt"; // ".\ --текущая директория, "..\" на уровень выше
            //относительный путь -- исполняемый файл является точкой отсчета
            string testMessage = "Hello, world";

            //текст нужно подготовить как массив байтов, т.к. кодировка текста возможна различная
            byte[] messageAnsiBytes = Encoding.ASCII.GetBytes(testMessage);

            //Запись информации в файл
            File.WriteAllBytes(fileName, messageAnsiBytes);
            File.WriteAllBytes(fileName1, messageAnsiBytes);

            //чтение
            const string fileNameToRead = @".\..\..\..\read.txt";
            string fileContent = File.ReadAllText(fileNameToRead);
            Console.WriteLine(fileContent);

            Directory.CreateDirectory(@"d:\test");  //создание директории
            Directory.CreateDirectory(@"d:\test\test");
        }
    }
}
