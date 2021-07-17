using System;
using Telegram.Bot;
using Reminder.Sender.Core;
using Telegram.Bot.Types;
using System.Security.Principal;

namespace Reminder.Sender.Telegram
{
    public class TelegramReminderSender : IReminderSender
    {
        //bot_key: 1658241756:AAEGWnqk2BVg6qTOmaaQAby-g00DiqWhFRY

        private TelegramBotClient _botClient;

        //private string _token = @"1658241756:AAEGWnqk2BVg6qTOmaaQAby-g00DiqWhFRY";
        public TelegramReminderSender(string token)
        {
            _botClient = new TelegramBotClient(token);
        }
        

        /// <summary>
        /// TODO: try to use username
        /// </summary>


        public void Send(string contactId, string message)
        {           
           var chatId = new  ChatId(long.Parse(contactId));
            _botClient.SendTextMessageAsync(
           chatId,
           message);
        }
    }
}
