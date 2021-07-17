using System;
using System.Collections.Generic;
using System.Text;

namespace Classwork17
{
    public class WorkPerformedEventArgs: EventArgs
    {
        //int hours, WorkType workType

        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
