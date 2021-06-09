using System;

namespace _01_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var passport2 = new Passport("124253", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");
            var passport3 = new Passport("124253", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");
            
            //passport2.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"), "Russia", "Sergei");

           
            passport2.WriteToConsole();
            Console.WriteLine(passport2.Equals(passport3));

            var doc1 = new BaseDocument();
            var doc2 = new BaseDocument();
            doc1.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"));
            doc1.WriteToConsole();
            doc2.SetProperties("name", "12421354", DateTimeOffset.Parse("12.01.2020"));

            Console.WriteLine(doc1.Equals(doc2));
        }
    }
}

