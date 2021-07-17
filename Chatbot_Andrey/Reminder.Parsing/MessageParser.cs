using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        //date time long message    2021_07_08 12:20:00 example of reply message
        //datetime long message     2021_07_08T12:20:00 example of reply message
        //relationaltime long message 
        //  20s example of reply message
        //  10m10s example of reply message
        //  1h2m13s example of reply message
        public static void Parse(string message, out DateTimeOffset date, out string replyMessage)
        {
            if (message == null)
                throw new ArgumentNullException("Null message", message);

            int firstSpacePosition = message.IndexOf(" ");
            if (firstSpacePosition < 1)
                throw new ArgumentException("Invalid string format", message);

            string firstWord = message.Substring(0, firstSpacePosition);
            if (!DateTimeOffset.TryParse(firstWord, out date))
                throw new ArgumentException("Invalid string format", message);

            replyMessage = message.Substring(firstSpacePosition).Trim();

        }
    }
}
