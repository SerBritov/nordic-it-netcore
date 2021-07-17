using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTests
    {
        [TestMethod]    //атрибут, обязателен к указанию каждого тестового метода
        public void Empty_Constructor_Creates_Instance_With_Empty_Guid()
        {
            //подготовка тестовых данных
            ReminderItem reminderItem;

            //действие
            reminderItem = new ReminderItem();

            //проверка результатов
            Assert.IsNotNull(reminderItem); //убеждаемся, что аргумент не равен нулю -- противный случай приведет к ошибке
            Assert.AreEqual(Guid.Empty, reminderItem.Id);    //проверка аргументов
            
        }

        [TestMethod]
        public void Constructor_Without_Id_Initializes_New_Guid()
        {
            ReminderItem reminderItem;

            reminderItem = new ReminderItem(
                DateTimeOffset.UtcNow,
                String.Empty,
                String.Empty,
                ReminderItemStatus.Awaiting);

            Assert.IsNotNull(reminderItem.Id);
            Assert.IsNotNull(reminderItem);
            Assert.AreNotEqual(Guid.Empty, reminderItem.Id);
        }
    }
}
