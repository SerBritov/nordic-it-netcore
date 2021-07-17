using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;

namespace Reminder.Storage.Core.Tests
{
    [TestClass]
    public class ReminderItemTests
    {
        [TestMethod]    //�������, ���������� � �������� ������� ��������� ������
        public void Empty_Constructor_Creates_Instance_With_Empty_Guid()
        {
            //���������� �������� ������
            ReminderItem reminderItem;

            //��������
            reminderItem = new ReminderItem();

            //�������� �����������
            Assert.IsNotNull(reminderItem); //����������, ��� �������� �� ����� ���� -- ��������� ������ �������� � ������
            Assert.AreEqual(Guid.Empty, reminderItem.Id);    //�������� ����������
            
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
