using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.EventArguments
{
    public class ActionSucceededEventArgs: EventArgs
    {
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }

        public string ContactId { get; set; }

        public ActionSucceededEventArgs()
        {

        }

        public ActionSucceededEventArgs(ReminderItem reminderItem)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
        }
    }
}