using System;
using System.Collections.Generic;

namespace Homework12
{
	class Program
	{
		static void Main(string[] args)
		{
			ReminderItem reminderItem = 
				new ReminderItem(
				DateTimeOffset.Now + TimeSpan.FromHours(8), 
				"Alarm in 8 Hours");

			ChatReminder chatReminder =
				new ChatReminder(
					"@sergei",
					"Sergei",
					DateTimeOffset.Now + TimeSpan.FromHours(12),
					"Chat reminder in 12 hours");

			PhoneReminderItem phoneReminder =
				new PhoneReminderItem(
					"+7890345235",
					DateTimeOffset.Now + TimeSpan.FromHours(16),
					"Phone alarm in 16 hours");

			List<ReminderItem> ReminderList = new List<ReminderItem>();
			ReminderList.Add(reminderItem);
			ReminderList.Add(chatReminder);
			ReminderList.Add(phoneReminder);

			foreach (var reminder in ReminderList)
				reminder.WriteProperties();
		}
	}
}
