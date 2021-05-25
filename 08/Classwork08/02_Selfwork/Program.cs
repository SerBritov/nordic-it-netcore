using System;
using System.Collections.Generic;
using System.Linq;
namespace _02_Selfwork
{
    class Program
    {
        enum Country : int
        {
            England = 0,
            Russia = 1,
            USA = 2,
        }
        static void Main(string[] args)
        {
            Dictionary<Country, string> countriesCities = new Dictionary<Country, string>()
            {
                {Country.England, "London"},
                {Country.Russia, "Moscow"},
                {Country.USA, "Washington"}
            };

            Random random = new Random();
            Country randomCountry;
            string answer;

            do
            {
                randomCountry = (Country)(random.Next(countriesCities.Count));   //случайное число от 0 до длинны списка                
                Console.Write($" Capital of {randomCountry} is ");
                answer = Console.ReadLine();
                if (countriesCities[randomCountry].ToLower() == answer.ToLower())
                {
                    Console.WriteLine("Wrong!");
                    break;
                }
                else
                    Console.WriteLine("Nice!");
            }
            while (true);

        }
    }
}

/*
 * одобренный вариант
 */
//static void Main(string[] args)
//{
//    Dictionary<string, string> countriesCities = new Dictionary<string, string>()
//            {
//                {"England", "London"},
//                { "Russia", "Moscow"},
//                { "USA", "Washington"}
//            };

//    Random random = new Random();
//    int rnd;
//    KeyValuePair<string, string> element;
//    string answer;

//    do
//    {
//        rnd = random.Next(countriesCities.Count);
//        element = countriesCities.ElementAt(rnd);
//        Console.Write($" Capital of {element.Key} is ");
//        answer = Console.ReadLine();
//        if (answer != element.Value)
//        {
//            Console.WriteLine("Wrong!");
//            break;
//        }
//        else
//            Console.WriteLine("Nice!");
//    }
//    while (true);

//}

