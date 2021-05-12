using System;

namespace _04_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {/*
          * Исключения позволяют обозначить, что во время выполнения программы произошла ошибка
          * Все исключения наследуются от System.Exception
          * 
          */
            Console.Write("Please enter the number value less than 100: ");
            int input = 0;

            try         //пытается перехватить исключение, если оно сработает
            {
                input = int.Parse(Console.ReadLine());
            }
            catch(FormatException ex)       //пишется что должно произойти, если ошибка произошла внутри блока try. После выполнения команд блока catch программа продолжает выполняться линейно
            /*в скобках можно выбирать какие исключения мы пытаемся поймать
             */
            {
                Console.WriteLine($"Это должно быть целочисленное значение менее 100, код ошибки {ex.HResult}");
                throw;  //выход из программы
                //throw new Exception(); << это плохо, так как скрывает оригинальное исключение
            }
            catch(OverflowException ex)
            {
                Console.WriteLine($"Значение вне разрешенного диапазона");
                throw;
            }

            if (input > 99)
            {
                var ex = new Exception("the programm cannot work with value is more or equals 100");    //техническое сообщение об ошибке для разработчика
                throw ex;
            }

        }
    }
}
