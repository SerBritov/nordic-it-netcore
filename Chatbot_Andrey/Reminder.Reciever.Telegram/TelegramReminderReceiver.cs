using Reminder.Reciever.Core;
using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace Reminder.Reciever.Telegram
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
            _botClient.StartReceiving();    //как только запускаем бота -- начинается считывание сообщений
        }
        private void OnBotClientMessage(object sender, MessageEventArgs e)
        {
            var messageReceivedEventArg = new MessageReceivedEventArgs
            {
                ContactId = e.Message.Chat.Id.ToString(),
                Message = e.Message.Text
            };

            OnMessageReceived(this, messageReceivedEventArg);            
        }
        private void OnMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            MessageReceived?.Invoke(sender, e);
        }

    }
}
