using System;

namespace Reminder.Storage.Core
{
    public class ReminderItem
    {
        public DateTimeOffset Date { get; set; }
        public string Message { get; set; }
        public string ContactId { get; set; }
        public ReminderItemStatus Status { get; set; }
        public Guid Id { get; private set; }

        public ReminderItem(
            Guid guid,
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status)
        {
            Date = date;
            Id = Guid.NewGuid();
            Message = message;
            ContactId = contactId;
            Status = status;
        }

        public ReminderItem(
            DateTimeOffset date,
            string message,
            string contactId,
            ReminderItemStatus status) :
            this(Guid.NewGuid(), date, message, contactId, status)
        { }


            public ReminderItem() { }
    }
}
