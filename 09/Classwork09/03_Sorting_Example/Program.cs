using System;
using System.Diagnostics;

namespace _03_Sorting_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            const int arrayLengthMultiplier = 10;
            const int MaxValue = 100;
            for (int i = 1; i < 65537; i*=2)
            {
                int arrayLength = i * arrayLengthMultiplier;

                var sw = new Stopwatch();
                int[] array = GetSourceArray(arrayLength, MaxValue);
                // WriteArray(array);
                sw.Start();
                //Console.WriteLine(DateTimeOffset.Now.ToString("hh:mm:ss.ffffff"));
                /*array = */
                SortArrayMinToMax(array);
                //WriteArray(array);
                //Console.WriteLine(DateTimeOffset.Now.ToString("hh:mm:ss.ffffff"));
                sw.Stop();
                var myMethodTime = sw.Elapsed;
                

                sw.Restart();
                Array.Sort(array);
                sw.Stop();
                var dotNetTime = sw.Elapsed;
                Console.WriteLine($"My method: {myMethodTime}\t\t.Net Time: {dotNetTime}");
                
            }
        }
        static void WriteArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
            return;
        }

        static int[] GetSourceArray(int length, int MaxValue)
        {
            int[] array = new int[length];
            var rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(MaxValue);
            }
            return array;
        }

        static int[] SortArrayMinToMax(int[] arrayPublic)
        {
            int[] array = (int[])arrayPublic.Clone();
            int buffer;
            int limit;
            for (int i = 0; i < array.Length; i++)
            {
                limit = array.Length - i - 1;
                for (int j = 0; j < limit; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        buffer = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = buffer;
                    }
                }
            }
            return array;
        }
    }
}
