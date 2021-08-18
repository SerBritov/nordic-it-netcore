using Reminder.Storage.Core;

namespace Reminder.Domain.EventArguments
{
	public class AddingSucceededEventArgs : ReminderItemActionEventArgs
	{
		public AddingSucceededEventArgs()
		{
		}

		public AddingSucceededEventArgs(ReminderItem reminderItem)
			: base(reminderItem)
		{
		}
	}
}