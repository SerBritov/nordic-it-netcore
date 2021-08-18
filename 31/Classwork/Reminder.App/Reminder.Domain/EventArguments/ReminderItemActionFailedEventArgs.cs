using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.EventArguments
{
	public abstract class ReminderItemActionFailedEventArgs : EventArgs
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public Exception Exception { get; set; }

		public ReminderItemActionFailedEventArgs()
		{
		}

		public ReminderItemActionFailedEventArgs(ReminderItem reminderItem, Exception exception)
		{
			Id = reminderItem.Id;
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
			Status = reminderItem.Status;
			Exception = exception;
	}
	}
}
