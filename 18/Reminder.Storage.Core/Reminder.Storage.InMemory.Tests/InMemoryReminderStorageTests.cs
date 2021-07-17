using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;


namespace Reminder.Storage.InMemory.Tests
  
{
    [TestClass]
    public class InMemoryReminderStorageTests
    {
        [TestMethod]
        public void Get_Returns_Null_For_Absent_Id()
        {
            //подготовка данных к тестировнию
            InMemoryReminderStorage storage = new InMemoryReminderStorage();
            //действие
            ReminderItem actual = storage.Get(Guid.Empty);

            //проверка
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Get_Returns_Just_Added_Item()
        {
            Guid guid = Guid.NewGuid();
            DateTimeOffset date = DateTimeOffset.Now;
            string message = "test message";
            string contactId = "test ID";
            ReminderItemStatus status = ReminderItemStatus.Failed;

            var expected = new ReminderItem(
                guid,
                date,
                message,
                contactId,
                status);

            var storage = new InMemoryReminderStorage();

            //
            storage.Add(expected);
            var actual =  storage.Get(guid);


            //
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Date, actual.Date);
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.ContactId, actual.ContactId);
            Assert.AreEqual(expected.Status, actual.Status);

           // Assert.ThrowsException<>

        }

        [TestMethod]
        public void Get_Add_Of_Item_With_Already_Added_Id_Throws_Exception()
        {
            var guid = new Guid();
            guid = Guid.NewGuid();
            var reminderItem1 = new ReminderItem(
                guid,
                DateTimeOffset.Now,
                "1",
                "1",
                ReminderItemStatus.Failed);
            var reminderItem2 = new ReminderItem(
                guid,
                DateTimeOffset.Now,
                "2",
                "2",
                ReminderItemStatus.Failed);
            var storage = new InMemoryReminderStorage();

            storage.Add(reminderItem1);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                
                try
                {
                    storage.Add(reminderItem2);
                }
                catch (ArgumentException e)
                {
                    return;
                }
                throw new ArgumentException();                    
            });
        }
    }
}
