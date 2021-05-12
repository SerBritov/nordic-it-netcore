using System;

namespace _01_IF_ELSE_on_my_own
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minYears = 1, maxYears = 30;
            int contractLength;
            Console.Write("Введите длительность договора аренды в годах: ");
            contractLength = int.Parse(Console.ReadLine());

            if (contractLength < minYears || contractLength > maxYears)
            {
                Console.WriteLine("Вы ввели неправильное значение");
                return;
            }

            string yearWord = string.Empty;
            if (contractLength > 4 && contractLength < 21 || contractLength % 10 > 4 || contractLength % 10 == 0)
                yearWord = "лет";
            else if (contractLength % 10 == 1)
                yearWord = "год";
            else
                yearWord = "года";

            Console.Write($"Договор аренды оформлен на период длительностью {contractLength} {yearWord}");
        }
    }
}
