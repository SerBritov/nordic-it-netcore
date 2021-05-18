using System;

namespace _03_Selfwork
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
                var ex = new Exception("Programm cannot work if contract length is more or equals 30");
                throw ex;
            }

            string yearWord = string.Empty;
            switch (contractLength)
            {
                case 11:
                case 12:
                case 13:
                case 14:
                    yearWord = "лет";
                    break;
                default:
                    switch (contractLength%10)
                    {
                        case 1:
                            yearWord = "год";
                            break;
                        case 2:
                        case 3:
                        case 4:
                            yearWord = "года";
                            break;
                        default:
                            yearWord = "лет";
                            break;
                    }
                    break;
            }

            Console.Write($"Договор аренды оформлен на период длительностью {contractLength} {yearWord}");
        }
    }
}
