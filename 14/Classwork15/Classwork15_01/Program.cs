using System;

namespace Delegates
{
    class Program
    {
        delegate int DoCalc(int a, int b);


        static void Main(string[] args)
        {

            Console.WriteLine(SimpleCalculator.Sum(10, 10));
            Console.WriteLine(SimpleCalculator.Multiply(10, 10));

            DoCalc performCalculation;
            int result;

            performCalculation = SimpleCalculator.Sum;
            result = performCalculation(10, 5);
            Console.WriteLine(result);

            performCalculation = SimpleCalculator.Multiply;
            result = performCalculation(10, 5);
            Console.WriteLine(result);


            DoCalc doCalc1 = SimpleCalculator.Sum;
            DoCalc doCalc2 = SimpleCalculator.Multiply;
            DoCalc doCalc3 = (DoCalc)Delegate.Combine(doCalc1, doCalc2);

            result = doCalc3(10, 5);
            Console.WriteLine(result);

            DoCalc doCalc4 = doCalc1 + doCalc2;
            doCalc4 += doCalc2 + doCalc2;
            doCalc4 -= doCalc1;
            result = doCalc4(10, 5);
            Console.WriteLine(result);

            Func<int, int, int> doCalc5 = SimpleCalculator.Sum;
            Func<int, int, int> doCalc6 = SimpleCalculator.Sum;
            doCalc6 += doCalc5 + doCalc5 + doCalc5;
            

        }
    }
}
