using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.EventArguments
{
	public abstract class ReminderItemActionEventArgs: EventArgs
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public ReminderItemActionEventArgs()
		{
		}

		public ReminderItemActionEventArgs(ReminderItem reminderItem)
		{
			Id = reminderItem.Id;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
			Status = reminderItem.Status;
		}
	}
}
