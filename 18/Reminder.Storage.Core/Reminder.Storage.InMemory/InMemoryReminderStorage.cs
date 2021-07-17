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
            return _reminders.ContainsKey(id) ? 
                _reminders[id] : null;
        }

        public List<ReminderItem> GetList(ReminderItemStatus status)
        {
            throw new NotImplementedException();
        }

        public void Update(ReminderItem reminderItem)
        {
            throw new NotImplementedException();
        }
    }
}
