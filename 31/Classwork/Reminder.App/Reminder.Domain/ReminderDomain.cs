using System;
using System.Collections.Generic;
using System.Threading;
using Reminder.Domain.EventArguments;
using Reminder.Parsing;
using Reminder.Receiver.Core;
using Reminder.Sender.Core;
using Reminder.Storage.Core;


namespace Reminder.Domain
{
	public class ReminderDomain : IDisposable
	{
		private readonly IReminderStorage _storage;
		private readonly IReminderSender _sender;
		private readonly IReminderReceiver _receiver;

		private readonly TimeSpan _awaitingRemindersCheckingPeriod;
		private readonly TimeSpan _readyRemindersCheckingPeriod;

		private Timer _awaitingRemindersCheckTimer;
		private Timer _readyRemindersSendTimer;

		public event EventHandler<SendingSucceededEventArgs> SendingSucceeded;
		public event EventHandler<SendingFailedEventArgs> SendingFailed;
		public event EventHandler<AddingSucceededEventArgs> AddingSucceeded;
		public event EventHandler<AddingFailedEventArgs> AddingFailed;

		public ReminderDomain(
			IReminderStorage storage,
			IReminderSender sender,
			IReminderReceiver receiver,
			TimeSpan awaitingRemindersCheckingPeriod,
			TimeSpan readyRemindersCheckingPeriod)
		{
			_storage = storage;
			_sender = sender;
			_receiver = receiver;
			_awaitingRemindersCheckingPeriod = awaitingRemindersCheckingPeriod;
			_readyRemindersCheckingPeriod = readyRemindersCheckingPeriod;
		}

		public void Run()
		{
			_awaitingRemindersCheckTimer = new Timer(
				CheckAwaitingReminders,
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

		private void OnReceiverMessageReceived(object sender, MessageReceivedEventArgs e)
		{
			ReminderItemRestricted reminderItemRestricted = null;

			try
			{
				MessageParser.Parse(
					e.Message,
					out DateTimeOffset date,
					out string replyMessage);

				reminderItemRestricted = new ReminderItemRestricted(
					date,
					replyMessage,
					e.ContactId,
					ReminderItemStatus.Awaiting);
			}
			catch (Exception exception)
			{
				_sender.Send(e.ContactId, $"Invalid input string format, try again! Exception: {exception}");
			}

			if (reminderItemRestricted == null)
				return;

			try
			{
				Guid id = _storage.Add(reminderItemRestricted);
				OnAddingSucceeded(
					this,
					new AddingSucceededEventArgs(reminderItemRestricted.ToReminderItem(id)));
			}
			catch (Exception exception)
			{
				OnAddingFailed(
					this,
					new AddingFailedEventArgs(reminderItemRestricted.ToReminderItem(Guid.Empty), exception));
			}
		}


		private void CheckAwaitingReminders(object dummy)
		{
			List<ReminderItem> awaitingItems = _storage.GetList(ReminderItemStatus.Awaiting);
			foreach (ReminderItem reminderItem in awaitingItems)
			{
				if (reminderItem.IsTimeToSend)
				{
					reminderItem.Status = ReminderItemStatus.ReadyToSend;
					_storage.Update(reminderItem);
				}
			}
		}

		private void CheckReadyReminders(object dummy)
		{
			List<ReminderItem> readyToSendItems = _storage.GetList(ReminderItemStatus.ReadyToSend);
			foreach (ReminderItem reminderItem in readyToSendItems)
			{
				try
				{
					_sender.Send(reminderItem.ContactId, reminderItem.Message);
					reminderItem.Status = ReminderItemStatus.SuccessfullySent;
					OnSendingSucceeded(this, new SendingSucceededEventArgs(reminderItem));
				}
				catch (Exception exception)
				{
					reminderItem.Status = ReminderItemStatus.Failed;
					OnSendingFailed(this, new SendingFailedEventArgs(reminderItem, exception));
				}

				_storage.Update(reminderItem);
			}
		}

		public void OnSendingSucceeded(object sender, SendingSucceededEventArgs e)
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

		public void Dispose()
		{
			_awaitingRemindersCheckTimer?.Dispose();
			_readyRemindersSendTimer?.Dispose();
		}
	}
}
