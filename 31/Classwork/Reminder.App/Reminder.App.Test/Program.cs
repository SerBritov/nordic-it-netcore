using System;
using Reminder.Storage.Core;
using Reminder.Storage.WebApi.Client;

namespace Reminder.App.Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var client = new ReminderStoageWebApiClient("https://localhost:44348/api/reminders");

			var item = new ReminderItemRestricted(
				DateTimeOffset.Now,
				"TestMessage",
				"TestContactId",
				ReminderItemStatus.ReadyToSend);

			Guid id = client.Add(item);
			ReminderItem readItem = client.Get(id);

			readItem.Status = ReminderItemStatus.SuccessfullySent;
			client.Update(readItem);
			readItem = client.Get(id);


			var list = client.GetList(ReminderItemStatus.SuccessfullySent);

		}
	}
}
