using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.EventArguments
{
	public class AddingFailedEventArgs: ReminderItemActionFailedEventArgs
	{
		public AddingFailedEventArgs()
		{
		}

		public AddingFailedEventArgs(ReminderItem reminderItem, Exception exception)
			:base(reminderItem, exception)
		{
		}
	}
}
