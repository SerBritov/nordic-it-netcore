using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate;
        public string AlarmMessage;
        public TimeSpan TimeToAlarm
        {
            get
            { return AlarmDate - DateTimeOffset.Now; }
            set { }
        }
        public bool IsOutdated
        {
            get
            {
                return (TimeToAlarm < TimeSpan.FromMilliseconds(0));
            }
            set { }
        }

        public ReminderItem(DateTimeOffset alarmDate, string alarmMessage)
        {
            AlarmDate = alarmDate;
            AlarmMessage = alarmMessage;
        }

        public virtual void WriteProperties()
        {
            Console.WriteLine($"Alarm date: {AlarmDate}\nAlarm message: {AlarmMessage}\nTime to alarm: {TimeToAlarm}\nIsOutdated: {IsOutdated}\n");
        }
    }
}
