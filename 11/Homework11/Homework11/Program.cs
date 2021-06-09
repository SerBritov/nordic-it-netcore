using System;

namespace Homework11
{
    class Program
    {
        static void Main(string[] args)
        {
             Alarm alarm1 = new Alarm(DateTimeOffset.Now + TimeSpan.FromHours(5), "5-hours alarm");
            Alarm alarm2 = new Alarm(DateTimeOffset.Now - TimeSpan.FromHours(5), "5-hours outdated alarm");
            alarm1.WriteProperties();
            alarm2.WriteProperties();
            Console.ReadKey();
        }
    }
}
