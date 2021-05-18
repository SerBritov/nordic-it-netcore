using System;

namespace _02_Terner_Operator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Тернарный оператор ?: возвращает одно из двух значений исходя из условия слева
             * используется в форме {bool} ? {valueIfTrue} : {valueIfFalse}
             */
            int a = 0, b;
            b = a > 0 ? 1 : 2;  // b == 2
            Console.WriteLine(b);

            b = true ? 1 : 2;   // b == 1
            Console.WriteLine(b);

        }
    }
}
