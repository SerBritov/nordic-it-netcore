using Reminder.Storage.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Domain.EventArguments
{
    public class SendingSucceededEventArgs : ActionSucceededEventArgs
    {
        public SendingSucceededEventArgs(ReminderItem reminderItem) : base(reminderItem) { }
    }
}
