using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork15
{
    public static class Swapper
    {
        public static void Swap<T>(ref T a, ref T b) 
        {
            T temp = a;
            a = b;
            b = temp;
        }

       /* public static void Swap<T>(ref T a, ref T b) where T : class
        {
            T temp = a;
            a = b;
            b = temp;
        }*/
    }
    /*
    public static class Swapper2<T> where T: class
    {
        public static void Swap(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }*/
}
