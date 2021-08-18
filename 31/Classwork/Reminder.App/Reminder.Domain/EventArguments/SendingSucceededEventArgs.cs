using Reminder.Storage.Core;

namespace Reminder.Domain.EventArguments
{
	public class SendingSucceededEventArgs : ReminderItemActionEventArgs
	{
		public SendingSucceededEventArgs()
		{
		}

		public SendingSucceededEventArgs(ReminderItem reminderItem)
			: base(reminderItem)
		{
		}
	}
}