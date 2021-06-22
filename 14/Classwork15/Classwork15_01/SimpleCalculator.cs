using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Delegates
{
    public static class SimpleCalculator
    {
        public static  int Sum(int x, int y)
        {
            Debug.WriteLine($"{nameof(Sum)} called");
            return x + y;
        }

        public static int Multiply(int x, int y)
        {
            Debug.WriteLine($"{nameof(Multiply)} called");
            return x * y;
        }
    }
}
