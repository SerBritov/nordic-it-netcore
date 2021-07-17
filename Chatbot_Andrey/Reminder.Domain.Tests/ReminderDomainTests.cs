using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Sender.Core;
using System;
using System.Threading;
using Moq;  //пакет для генерации классов на лету без описания его интерфейсов

namespace Reminder.Domain.Tests
{
    [TestClass]
    public class ReminderDomainTests
    {
        [TestMethod]
        public void When_Send_OK_SendingSucceededEvent_Raised()
        {
            var item = new ReminderItem { Date = DateTimeOffset.Now };
            var storage = new InMemoryReminderStorage();
            storage.Add(item);

            var senderMock = new Mock<IReminderSender>();   //"заглушка", которая зависит от интерфейса, а не класса

            using var domain = new ReminderDomain(
                storage,
                /*IReminderSender-объект-пустышка для тестирований*/senderMock.Object,
                TimeSpan.FromMilliseconds(10),
                TimeSpan.FromMilliseconds(10));

            bool eventHandlerCalled = false;
            domain.SendingSucceeded += (s, e) =>
              {
                  eventHandlerCalled = true;
              };

            domain.Run();
            Thread.Sleep(150);
            Assert.IsTrue(eventHandlerCalled);
        }


        //Доделать
        [TestMethod]
        public void When_Send_ThrowException_FailEvent_Raised()
        {
            var item = new ReminderItem { Date = DateTimeOffset.Now };
            var storage = new InMemoryReminderStorage();
            storage.Add(item);

            var senderMock = new Mock<IReminderSender>();   //"заглушка", которая зависит от интерфейса, а не класса
            senderMock
                .Setup(x => x.Send(It.IsAny<ReminderItem>())) //It.IsAny -- cоздаст любой объект
                // .Callback(() => {  });   
               .Throws(new Exception("Sending Failed Exception"));
            using var domain = new ReminderDomain(
                storage,
                /*IReminderSender-объект-пустышка для тестирований*/senderMock.Object,
                TimeSpan.FromMilliseconds(10),
                TimeSpan.FromMilliseconds(10));

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
