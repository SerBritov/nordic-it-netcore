using System;
using System.Collections.Generic;
using System.Text;

namespace Reminder.Storage.Core
{
	public interface IReminderStorage
	{
		Guid Add(ReminderItemRestricted reminderItem);

		void Update(ReminderItem reminderItem);

		ReminderItem Get(Guid id);

		List<ReminderItem> GetList(ReminderItemStatus status);
	}
}
