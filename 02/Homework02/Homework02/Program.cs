using System;


namespace Homework02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                "Enter the expression using 0-9, ., +, -, *, / : ");
            string expression = Console.ReadLine() + "?";   //to not get out of array
            int stringIndex = 0;
            double finalResult;
            bool dividedByZero = false;
            finalResult = Computing();
            if (!dividedByZero)
                Console.WriteLine(finalResult);
			else
                Console.WriteLine("Don't divide by zero");
            Console.ReadKey();


            double Computing()
            {

                double value1 = 0, value2 = 0;

            MethodStart:
                for (; (expression[stringIndex] == ' '); stringIndex++) ;   //skipping spaces
                for (; (expression[stringIndex] >= '0') && (expression[stringIndex] <= '9'); stringIndex++) //reading value
                    value1 = value1 * 10 + (double)expression[stringIndex] - 48;

                if (expression[stringIndex] == '.')     //decimal part
                {
                    stringIndex++;
                    for (int dotIndex = stringIndex; (expression[stringIndex] >= '0') && (expression[stringIndex] <= '9'); stringIndex++)
                    {
                        value1 += ((double)expression[stringIndex] - 48) * Math.Pow(0.1, (stringIndex - dotIndex + 1));
                    }
                }


                /*
                 * low priority computations
                 */
                if (expression[stringIndex] == '+')
                {
                    stringIndex++;
                    value1 += Computing();
                }
                if (expression[stringIndex] == '-')
                {
                    stringIndex++;
                    value1 -= Computing();
                }

                /*
                 * high priority computations
                 */
                if (expression[stringIndex] == '*')
                {
                    stringIndex++;
                    value2 = 0;
                    for (; (expression[stringIndex] == ' '); stringIndex++) ;
                    for (; (expression[stringIndex] >= '0') && (expression[stringIndex] <= '9'); stringIndex++)
                        value2 = value2 * 10 + (double)expression[stringIndex] - 48;
                    value1 *= value2;
                    goto MethodStart;
                }
                if (expression[stringIndex] == '/')
                {
                    stringIndex++;
                    value2 = 0;
                    for (; (expression[stringIndex] == ' '); stringIndex++) ;
                    for (; (expression[stringIndex] >= '0') && (expression[stringIndex] <= '9'); stringIndex++)
                        value2 = value2 * 10 + (double)expression[stringIndex] - 48;
                    if (value2 == 0)    //если поделили на ноль :(
                    {
                        dividedByZero = true;
                        return 0;
                    }
                    value1 /= value2;
                    goto MethodStart;
                }

                return value1;
            }
        }
    }
}
