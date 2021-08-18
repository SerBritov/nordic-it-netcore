using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Reminder.Receiver.Core;

namespace Reminder.Receiver.Telegram
{
	public class TelegramReminderReceiver : IReminderReceiver
	{
		public event EventHandler<MessageReceivedEventArgs> MessageReceived;

		private TelegramBotClient _botClient;

		public TelegramReminderReceiver(string accessToken)
		{
			_botClient = new TelegramBotClient(accessToken);
			_botClient.OnMessage += OnBotClientMessage;
		}

		public void Run()
		{
			_botClient.StartReceiving();
		}

		private void OnBotClientMessage(object sender, MessageEventArgs e)
		{
			var messageReceivedEventArgs = new MessageReceivedEventArgs
			{
				ContactId = e.Message.Chat.Id.ToString(),
				Message = e.Message.Text
			};

			OnMessageReceived(this, messageReceivedEventArgs);
		}

		private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
		{
			MessageReceived?.Invoke(sender, e);
		}
	}
}
