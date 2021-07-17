using Reminder.Storage.Core;
using System;
namespace Reminder.Domain.EventArguments
{
    public class ActionFailedEventArgs:EventArgs
    {
        public Guid Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public string Message { get; set; }

        public string ContactId { get; set; }
        public Exception Exception { get; set; }

        public ActionFailedEventArgs()
        {

        }

        public ActionFailedEventArgs(ReminderItem reminderItem, Exception exception)
        {
            Id = reminderItem.Id;
            Date = reminderItem.Date;
            Message = reminderItem.Message;
            ContactId = reminderItem.ContactId;
            Exception = exception;
        }
    }
}