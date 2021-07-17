using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArguments
{
    public class AddingFailedEventArgs: ActionFailedEventArgs
    {
        public Exception Exception { get; set; }
        public AddingFailedEventArgs(ReminderItem reminderItem, Exception exception) : base(reminderItem, exception) { }

    }
}
