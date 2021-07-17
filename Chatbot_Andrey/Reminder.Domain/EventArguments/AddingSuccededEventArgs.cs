using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArguments
{
    public class AddingSucceededEventArgs : ActionSucceededEventArgs
    {
        public AddingSucceededEventArgs(ReminderItem reminderItem) : base(reminderItem) { }
    }
}
