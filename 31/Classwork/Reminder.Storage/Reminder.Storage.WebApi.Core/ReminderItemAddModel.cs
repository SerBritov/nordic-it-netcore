using Reminder.Storage.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Reminder.Storage.WebApi.Core
{
	public class ReminderItemAddModel
	{
		public DateTimeOffset Date { get; set; }

		[MaxLength(50)]
		public string Message { get; set; }

		public string ContactId { get; set; }

		public ReminderItemStatus Status { get; set; }

		public ReminderItemAddModel()
		{
		}

		public ReminderItemAddModel(ReminderItem reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
			Status = reminderItem.Status;
		}

		public ReminderItemAddModel(ReminderItemRestricted reminderItem)
		{
			Date = reminderItem.Date;
			Message = reminderItem.Message;
			ContactId = reminderItem.ContactId;
			Status = reminderItem.Status;
		}

		public ReminderItem ToReminderItem(Guid id)
		{
			return new ReminderItem(id, Date, Message, ContactId, Status);
		}

		public ReminderItemRestricted ToReminderItemRestricted()
		{
			return new ReminderItemRestricted(Date, Message, ContactId, Status);
		}
	}
}
