using System;

namespace Reminder.Receiver.Core
{
	public class MessageReceivedEventArgs: EventArgs
	{
		public string Message { get; set; }

		public string ContactId { get; set; }
	}
}