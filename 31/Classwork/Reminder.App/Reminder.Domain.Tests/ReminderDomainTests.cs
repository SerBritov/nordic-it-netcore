using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using System.Threading;
using Moq;
using Reminder.Sender.Core;
using Reminder.Receiver.Core;

namespace Reminder.Domain.Tests
{
	[TestClass]
	public class ReminderDomainTests
	{
		[TestMethod]
		public void When_Send_OK_SendingSucceeded_Event_Raised()
		{
			var item = new ReminderItem { Date = DateTimeOffset.Now };
			var storage = new InMemoryReminderStorage();
			storage.Add(item);

			var senderMock = new Mock<IReminderSender>();
			var receiverMock = new Mock<IReminderReceiver>();

			using var domain = new ReminderDomain(
				storage,
				senderMock.Object /* IReminderSender */,
				receiverMock.Object /* IReminderReceiver */,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromMilliseconds(50));

			bool eventHandlerCalled = false;

			domain.SendingSucceeded += (s, e) =>
			{
				eventHandlerCalled = true;
			};

			domain.Run();

			Thread.Sleep(150);

			Assert.IsTrue(eventHandlerCalled);
		}

		[TestMethod]
		public void When_Send_Throws_Exception_SendingFailed_Event_Raised()
		{
			var item = new ReminderItem { Date = DateTimeOffset.Now };
			var storage = new InMemoryReminderStorage();
			storage.Add(item);

			var senderMock = new Mock<IReminderSender>();
			senderMock
				.Setup(x => x.Send(It.IsAny<string>(), It.IsAny<string>()))
				//.Callback(() => {  });
				.Throws(new Exception("Sending Failed Exception"));

			var receiverMock = new Mock<IReminderReceiver>();

			using var domain = new ReminderDomain(
				storage,
				senderMock.Object /* IReminderSender */,
				receiverMock.Object /* IReminderReceiver */,
				TimeSpan.FromMilliseconds(50),
				TimeSpan.FromMilliseconds(50));

			bool eventHandlerCalled = false;

			domain.SendingFailed += (s, e) =>
			{
				eventHandlerCalled = true;
			};

			domain.Run();

			Thread.Sleep(150);

			Assert.IsTrue(eventHandlerCalled);
		}
	}
}