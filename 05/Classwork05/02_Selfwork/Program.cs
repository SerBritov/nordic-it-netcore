using System;

namespace _02_Selfwork
{
    class Program
    {
        static void Main(string[] args)
        {
            const int minValue = 0, maxValue = 100;
            const int borderValue = 50;
            
            int userValue;
            string outputMessage = string.Empty;

            Console.Write($"Введите число от {minValue} до {maxValue}: ");
            try
            {
                userValue = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Не было прочитано число. Код ошибки: {e.HResult}");
                throw;
            }
            if (userValue > 100)
            {
                throw new Exception($"Число должно быть в диапазоне от{minValue} до {maxValue}");

            }
            
            outputMessage = userValue < borderValue
                ? $"Введенное число меньше {borderValue}"
                : $"Введенное число больше {borderValue}";

            Console.WriteLine(outputMessage);
        }
    }
}
