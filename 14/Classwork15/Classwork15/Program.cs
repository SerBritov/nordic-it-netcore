using System;

namespace Classwork15
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = -1;
            int b = 100;

            Console.WriteLine($" a = {a}, b = {b}");
            Swapper.Swap(ref a, ref b);
            
            Console.WriteLine($" a = {a}, b = {b}");

            byte c = 0; byte d = 100;
            Console.WriteLine($" c = {c}, d = {d}");
            Swapper.Swap(ref c, ref d);
            Console.WriteLine($" c = {c}, d = {d}");

            string s1 = "s1";
            string s2 = "s2";

            Console.WriteLine($"{nameof(s1)} = {s1}; {nameof(s2)} = {s2}");
            Swapper.Swap(ref s1,ref  s2);
            Console.WriteLine($"{nameof(s1)} = {s1}; {nameof(s2)} = {s2}");

            Account<int> acc1 = new Account<int>(24, "Sergei");
            Account<int> acc2 = new Account<int>(256, "Andrei");

            Console.WriteLine($"{nameof(acc1)} = {acc1}; {nameof(acc2)} = {acc2}");
            Swapper.Swap(ref acc1,ref  acc2);
            Console.WriteLine($"{nameof(acc1)} = {acc1}; {nameof(acc2)} = {acc2}");
        }
    }
}
