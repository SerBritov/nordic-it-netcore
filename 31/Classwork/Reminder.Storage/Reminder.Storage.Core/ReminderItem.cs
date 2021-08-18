using System;

namespace Reminder.Storage.Core
{
	public class ReminderItem
	{
		public Guid Id { get; set; }

		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public bool IsTimeToSend
		{
			get { return DateTimeOffset.Now >= Date; }
		}

		public ReminderItem()
		{
		}

		public ReminderItem(
			Guid id,
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status)
		{
			Id = id;
			Date = date;
			Message = message;
			ContactId = contactId;
			Status = status;
		}

		public ReminderItemRestricted ToReminderItemRestricted()
		{
			return new ReminderItemRestricted(
				Date, Message, ContactId, Status);
		}
	}
}
