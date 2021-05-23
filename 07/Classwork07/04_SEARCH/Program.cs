using System;

namespace _04_SEARCH
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Contains -- содержит ли
             * StartsWith -- начинается ли с
             * EndsWith -- заканчивается ли на
             * IndexOf -- позиция первого символа найденной подстроки или -1
             * LastIndexOf -- позиция последнего символа найденной подстроки или -1
             */

            string s = "something";
            Console.WriteLine(s.Contains("me"));    //true
            Console.WriteLine(s.StartsWith("so"));  //true
            Console.WriteLine(s.EndsWith("thin"));  //false

            int searchFromIndex = 0;
            int index = s.IndexOf("o");
            Console.WriteLine(index);   //1
            searchFromIndex = s.IndexOf("t", index);    //поиск начиная с индекса index

            Console.WriteLine();
            //найти индексы всех букв "s"
            string someString = "asdfsafsdafsfasfsadsfgas";
            
            for (int i = someString.IndexOf("sd"); i > 0;)
            {
                Console.Write(i.ToString().PadRight(3));
                i = someString.IndexOf("sd", i+1);
            }

        }
    }
}
