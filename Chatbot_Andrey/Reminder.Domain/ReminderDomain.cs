using System;
using System.Threading;
using Reminder.Reciever.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;
using Reminder.Domain.EventArguments;
using System.Runtime.CompilerServices;
using Reminder.Parsing;
using System.Net.Http;

namespace Reminder.Domain
{
    public class ReminderDomain : IDisposable
    {
        private Timer _awaitingRemindersCheckTimer;
        private Timer _readyRemindersSendTimer;

        private readonly IReminderStorage _storage;
        private readonly IReminderSender _sender;
        private readonly IReminderReceiver _receiver;

        private readonly TimeSpan _awaitingRemindersCheckingPeriod;
        private readonly TimeSpan _readyRemindersCheckingPeriod;

        public event EventHandler<ActionSucceededEventArgs> SendingSucceeded;
        public event EventHandler<ActionFailedEventArgs> SendingFailed;
        public event EventHandler<AddingSucceededEventArgs> AddingSucceeded;
        public event EventHandler<AddingFailedEventArgs> AddingFailed;
        public ReminderDomain(
            IReminderStorage storage,
            IReminderSender sender,
            IReminderReceiver receiver,
            TimeSpan awaitingReminderCheckingPeriod,
            TimeSpan readyRemindersCheckingPeriod)
        {
            _storage = storage;
            _sender = sender;
            _receiver = receiver;
            _awaitingRemindersCheckingPeriod = awaitingReminderCheckingPeriod;
            _readyRemindersCheckingPeriod = readyRemindersCheckingPeriod;
        }

        public void Run()
        {
            //объявление таймера и для выполнения операций не чаще раза в секунду
            _awaitingRemindersCheckTimer = new Timer(
                CheckAwaintingReminders,
                null,
                TimeSpan.Zero,
                _awaitingRemindersCheckingPeriod);


            _readyRemindersSendTimer = new Timer(
                CheckReadyReminders,
                null,
                TimeSpan.Zero,
                _readyRemindersCheckingPeriod);
            _receiver.MessageReceived += OnReceiverMessageReceived;
            _receiver.Run();

        }

        private void CheckReadyReminders(object state)
        {
            var readyToSendItems = _storage.GetList(ReminderItemStatus.Awaiting);
            foreach (var reminderItem in readyToSendItems)
            {
                try
                {
                    _sender.Send(reminderItem.ContactId, reminderItem.Message);
                    reminderItem.Status = ReminderItemStatus.SuccessfullySent;
                    OnSendingSucceeded(
                        this,
                        new ActionSucceededEventArgs(reminderItem));
                    // Raise event SendingSucceeded;
                }              
                catch (Exception exception)
                {
                    reminderItem.Status = ReminderItemStatus.Failed;
                    OnSendingFailed(
                        this,
                        new SendingFailedEventArgs(reminderItem, exception));
                    // Raise event SendingFailed;
                }
                _storage.Update(reminderItem); ;
            }
        }
        private void CheckAwaintingReminders(object dummy)
        {
            var awaitingItems = _storage.GetList(ReminderItemStatus.Awaiting);
            foreach (var reminderItem in awaitingItems)
            {
                if (reminderItem.IsTimeToSend)
                {
                    reminderItem.Status = ReminderItemStatus.ReadyToSend;
                    _storage.Update(reminderItem);
                }
            }
        }

        

        public void OnSendingSucceeded(object sender, ActionSucceededEventArgs e)
        {
            SendingSucceeded?.Invoke(sender, e);
        }
        public void OnSendingFailed(object sender, SendingFailedEventArgs e)
        {
            SendingFailed?.Invoke(sender, e);
        }
        public void OnAddingSucceeded(object sender, AddingSucceededEventArgs e)
        {
             AddingSucceeded?.Invoke(sender, e);
        }

        public void OnAddingFailed(object sender, AddingFailedEventArgs e)
        {
            AddingFailed?.Invoke(sender, e);
        }

        private void OnReceiverMessageReceived(object sender, MessageReceivedEventArgs e)
        {
            ReminderItem reminderItem = null;
            try
            {
                MessageParser.Parse(
                    e.Message,
                    out DateTimeOffset date,
                    out string replyMessage);
                reminderItem = new ReminderItem(
                    date,
                    replyMessage,
                    e.ContactId,
                    ReminderItemStatus.Awaiting);
            }
            catch (Exception exception)
            {
                _sender.Send(e.ContactId, "Invalid input string format, try again!");
            }
            if (reminderItem == null)
                return;
            try
            {
                _storage.Add(reminderItem);
                OnAddingSucceeded(this, new AddingSucceededEventArgs(reminderItem));
            }
            catch (Exception exception)
            {
                OnAddingFailed(this, new AddingFailedEventArgs(reminderItem, exception));
            }
        }
        public void Dispose()
        {
            _awaitingRemindersCheckTimer?.Dispose();
            _readyRemindersSendTimer?.Dispose();
        }
    }


}

