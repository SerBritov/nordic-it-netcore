using System;
using System.Threading;

namespace Classwork17
{


    class Program
    {
        
        private static void Main(string[] args)
        {            
            WorkPerformedEventHandler del1 = WorkPerformed1;

            del1(8, WorkType.Work);
            del1(1, WorkType.DoNothig);

            WorkPerformedEventHandler del2 = WorkPerformed2;
            WorkPerformedEventHandler del3 = WorkPerformed3;
            del1 += del2 + del3;
            del1(8, WorkType.Work);

            Console.WriteLine("\n_______________________________\n");
            Worker workerAlice = new Worker("Alice");
            Worker workerPeter = new Worker("Peter");
            Worker workerBob = new Worker("Bob");



            Thread threadForAlice = new Thread(() =>
            {
                workerAlice.WorkComplete += OnWorkCompleteEventHandler;
                workerAlice.WorkPerformed += WorkPerformed3;
                workerAlice.DoWork(20, WorkType.Work);
            });

            Thread threadForBob = new Thread(() =>
            {
                workerBob.WorkComplete += OnWorkCompleteEventHandler;
                workerBob.WorkPerformed += WorkPerformed2;
                workerBob.DoWork(5, WorkType.DoNothig);
            });

            threadForAlice.Start();     //начало выполнения блока потока
            threadForBob.Start();

            threadForAlice.Join();  //указание на то, чтобы дожидаться выполнения дочерних потоков по отношению к main
            threadForBob.Join();
        }

        static void OnWorkCompleteEventHandler(object? sender, EventArgs e)
        {
            if (sender != null)
                Console.WriteLine($"{((Worker)sender).Name} has finished his work!");
        }
        public static void WorkPerformed1(int hours, WorkType workType)
        {
            Console.WriteLine($"1: Type of work {workType} done in {hours} hours");
        }

        public static void WorkPerformed2(int hours, WorkType workType)
        {
            Console.WriteLine($"2: Type of work {workType} done in {hours} hours");
        }
        public static void WorkPerformed3(int hours, WorkType workType)
        {
            Console.WriteLine($"3: Type of work {workType} done in {hours} hours");
        }

        public static void WorkPerformed1(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"1: Type of work {e.WorkType} done in {e.Hours} hours");
        }

        public static void WorkPerformed2(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"2: Type of work {e.WorkType} done in {e.Hours} hours");
        }
        public static void WorkPerformed3(object sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine($"3: Type of work {e.WorkType} done in {e.Hours} hours");
        }
    }
}
