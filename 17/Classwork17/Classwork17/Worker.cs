using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork17
{
    public class Worker
    {
        public string Name { get; set; }
        //public event WorkPerformedEventHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        public event EventHandler WorkComplete;     //базовый тип делегата для ивентов
        public virtual void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                var e = new WorkPerformedEventArgs
                {
                    Hours = i + 1,
                    WorkType = workType
                };
                //OnWorkPerformed(this, i + 1, workType);
                OnWorkPerformed(this, e);
            }

            OnWorkComplete(this, EventArgs.Empty);
        }

        protected virtual void OnWorkPerformed(object sender, WorkPerformedEventArgs e)
        {
            WorkPerformed?.Invoke(this, e); //? означает if (WorkPerformed != null)
        }

        protected virtual void OnWorkComplete(object sender, EventArgs e)
        {
            WorkComplete?.Invoke(sender, e);
        }

        public Worker(string name)
        {
            Name = name;
        }

        public Worker()
        { }
    }
}
