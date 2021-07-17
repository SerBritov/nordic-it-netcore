using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArguments
{
    public class SendingFailedEventArgs:ActionFailedEventArgs
    {
        public SendingFailedEventArgs(ReminderItem reminderItem, Exception exception)
            : base(reminderItem, exception)
        { }
        public SendingFailedEventArgs() { }
    }
}
