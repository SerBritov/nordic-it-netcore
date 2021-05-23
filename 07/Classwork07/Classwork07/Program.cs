using System;

namespace Classwork07
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Строка -- тип данных, представляющий последовательность символов
             * простейшие операции -- сравнение == и != , несмотря на то, что строки являются ссылочным типом данных
             */
            object o1 = new object();
            object o2 = new object();

            Console.WriteLine(o1 == o2);    //false, так как это ссылочный тип данных

            string s1 = "value";
            string s2 = "value";
            Console.WriteLine(s1 == s2);    //true, несмотря на то, что строки так же являются ссылочным типом данных
            //это происходит потому, что значение value занимает одно и то же место в памяти
            Console.WriteLine(s1.Equals(s2));   //то же, что и ==
            
            string input = Console.ReadLine();
            if (input == "show message")
                Console.WriteLine("message");

            if (input.Equals("show message"))   //если строка null, то метод не будет выполнен
                Console.WriteLine("message");
            if ("show message".Equals(input))   //но так сделать возможно
                Console.WriteLine("message");

            /*
             * Метод Equals помогает настраивать параметры сравнения
             */
            Console.WriteLine("==========================");
            Console.WriteLine("Test" == "test");    //false
            Console.WriteLine("Test".Equals("test", StringComparison.InvariantCultureIgnoreCase));  //так будет проигнорирован регистр, true
            
        }   
    }
}
