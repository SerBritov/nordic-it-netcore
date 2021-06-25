using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework12
{
    class ReminderItem
    {
        public DateTimeOffset AlarmDate { get; set; }
        public string AlarmMessage { get; set; }
        public TimeSpan TimeToAlarm
        {
            get
            { return AlarmDate - DateTimeOffset.Now; }            
        }
        public bool IsOutdated
        {
            get
            {
                return (TimeToAlarm < TimeSpan.FromMilliseconds(0));
            }
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
