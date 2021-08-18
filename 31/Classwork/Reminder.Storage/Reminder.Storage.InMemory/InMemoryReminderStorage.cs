using System;
using System.Collections.Generic;
using Reminder.Storage.Core;

namespace Reminder.Storage.InMemory
{
	public class InMemoryReminderStorage : IReminderStorage
	{
		internal readonly Dictionary<Guid, ReminderItemRestricted> _reminders;

		public InMemoryReminderStorage()
		{
			_reminders = new Dictionary<Guid, ReminderItemRestricted>();
		}

		public Guid Add(ReminderItemRestricted reminderItemRestricted)
		{
			Guid id = Guid.NewGuid();
			_reminders.Add(id, reminderItemRestricted);
			return id;
		}

		public ReminderItem Get(Guid id)
		{
			return _reminders.ContainsKey(id)
				? _reminders[id].ToReminderItem(id)
				: null;
		}

		public List<ReminderItem> GetList(ReminderItemStatus status)
		{
			var result = new List<ReminderItem>();
			foreach (KeyValuePair<Guid, ReminderItemRestricted> kvp in _reminders)
			{
				if (kvp.Value.Status == status)
					result.Add(kvp.Value.ToReminderItem(kvp.Key));
			}

			return result;
		}

		public void Update(ReminderItem reminderItem)
		{
			if (!_reminders.ContainsKey(reminderItem.Id))
				throw new InvalidOperationException("Could not find ReminderItem with the ID specified.");

			_reminders[reminderItem.Id] = reminderItem.ToReminderItemRestricted();
		}
	}
}
