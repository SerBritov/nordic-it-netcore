using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Classwork17
{
    public class WorkerWithStopwatch : Worker
    {
        private long _lastWorkElapsedMS = 0;
        public override void DoWork(int hours, WorkType workType)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            base.DoWork(hours, workType);

            sw.Stop();
            _lastWorkElapsedMS = sw.ElapsedMilliseconds;
            Debug.WriteLine($"Worker {Name} finished his work in {_lastWorkElapsedMS} ms");
        }

        protected override void OnWorkComplete(object sender, EventArgs e)
        {
            base.OnWorkComplete(sender, e);
            Console.WriteLine();
        }
    }
}
