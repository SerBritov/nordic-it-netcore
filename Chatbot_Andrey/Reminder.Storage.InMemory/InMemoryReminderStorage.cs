using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		private Dictionary<Guid, ReminderItem> _reminders;

		public InMemoryReminderStorage()
		{
			_reminders = new Dictionary<Guid, ReminderItem>();
		}

		public void Add(ReminderItem reminderItem)
		{
			_reminders.Add(reminderItem.Id, reminderItem);
		}

		public ReminderItem Get(Guid id)
		{
			return _reminders.ContainsKey(id)
				? _reminders[id]
				: null;
		}


		public List<ReminderItem> GetList(ReminderItemStatus status)
		{
			var result = new List<ReminderItem>();
			foreach(ReminderItem reminder in _reminders.Values)
			{
				if (reminder.Status == status)
					result.Add(reminder);
			}

			return result;
		}

		public void Update(ReminderItem reminderItem)
		{
			if (!_reminders.ContainsKey(reminderItem.Id))
				throw new InvalidOperationException("Could not find ReminderItem with the ID specified.");

			_reminders[reminderItem.Id] = reminderItem;
		}
	}
}
