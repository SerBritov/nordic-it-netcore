using System;

namespace Reminder.Storage.Core
{
	public class ReminderItemRestricted
	{
		public DateTimeOffset Date { get; set; }

		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public bool IsTimeToSend
		{
			get { return DateTimeOffset.Now >= Date; }
		}

		public ReminderItemRestricted()
		{
		}

		public ReminderItemRestricted(
			DateTimeOffset date,
			string message,
			string contactId,
			ReminderItemStatus status)
		{
			Date = date;
			Message = message;
			ContactId = contactId;
			Status = status;
		}

		public ReminderItem ToReminderItem(Guid id)
		{
			return new ReminderItem(
				id, Date, Message, ContactId, Status);
		}
	}
}
