using System;

namespace ConsoleApp1
{
    class Program
    {
        delegate int GetNumberFromNumbers(int[] numbers);
        static void Main(string[] args)
        {
            GetNumberFromNumbers method1 = Sum;
            int[] numbers = new[] { 1, 2, 3 };
            Console.WriteLine(method1(numbers));

            Func<int, int, int> method2;
            method2 = Min;
            Console.WriteLine(Min(1, 2));
            Func<int, int, int> method3 = (int a, int b) => Math.Min(a, b);

            string[] array = new[]
            {
                "abc",
                "dwa",
                "01",
                "02"
            };
            string[] result = Sort(
                array,
                (string a1, string b1) => a1[0] < b1[0]);

            foreach(var stringr in result)
                Console.WriteLine(stringr);
        }

        static int Sum(int[] numbers)
        {
            int result = 0;
            foreach (var number in numbers)
                result += number;
            return result;
        }

        static int Min(int a, int b)
        {
            return a > b ? b : a;
        }

        static string[] Sort(string[] inputArray, Func<string, string, bool> firstLessThanSecond)
        {
            string[] array = (string[])inputArray.Clone();

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (!firstLessThanSecond(array[j], array[j + 1]))
                    {
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return array;
        }

    }
}
