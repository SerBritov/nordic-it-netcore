using Reminder.Storage.Core;
using System;

namespace Reminder.Domain.EventArguments
{
	public class SendingFailedEventArgs: ReminderItemActionFailedEventArgs
	{
		public SendingFailedEventArgs()
		{
		}

		public SendingFailedEventArgs(ReminderItem reminderItem, Exception exception)
			:base(reminderItem, exception)
		{
		}
	}
}