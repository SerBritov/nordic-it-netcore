using System;

namespace Reminder.Parsing
{
	public static class MessageParser
	{
		// datetime long message
		//		"2021-07-08T12:20:00+0300 Example of reply message"

		// date time long message:
		//		"2021-07-08 12:20:00+0300 Example of reply message"

		// relationaltime long message
		//		"10s Example of reply message"
		//		"2m15s Example of reply message"
		//		"1h2m15s Example of reply message"
		//		"3d2h Example of reply message"

		public static void Parse(string message, out DateTimeOffset date, out string replyMessage)
		{
			if (message == null)
				throw new ArgumentNullException(message);

			int firstSpacePosiotion = message.IndexOf(" ");
			if (firstSpacePosiotion <= 0)
				throw new ArgumentException("Invalid string format", message);

			string firstWord = message.Substring(0, firstSpacePosiotion);
			if (!DateTimeOffset.TryParse(firstWord, out date))
				throw new ArgumentException("Invalid string format", message);

			replyMessage = message.Substring(firstSpacePosiotion).Trim();
		}
	}
}
