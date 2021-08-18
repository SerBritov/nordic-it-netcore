using Telegram.Bot;
using Telegram.Bot.Types;
using Reminder.Sender.Core;

namespace Reminder.Sender.Telegram
{
	public class TelegramReminderSender : IReminderSender
	{
		private TelegramBotClient _botClient;

		public TelegramReminderSender(string accessToken)
		{
			_botClient = new TelegramBotClient(accessToken);
		}

		public void Send(string contactId, string message)
		{
			_botClient.SendTextMessageAsync(
				new ChatId(long.Parse(contactId)),
				message);
		}
	}
}
