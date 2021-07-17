using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Reminder.Storage.Core.Tests
{
	[TestClass]
	public class ReminderItemTests
	{
		[TestMethod]
		public void Empty_Constructor_Creates_Instanse_With_Empty_Guid()
		{
			// prepare test data
			ReminderItem reminderItem;

			// action
			reminderItem = new ReminderItem();

			// check results
			Assert.IsNotNull(reminderItem);
			Assert.AreEqual(Guid.Empty, reminderItem.Id);
		}

		[TestMethod]
		public void Cunstructor_Without_Id_Initialized_Instance_With_New_Guid()
		{
			// prepare test data
			ReminderItem reminderItem;

			// action
			reminderItem = new ReminderItem(
				DateTimeOffset.MinValue,
				string.Empty,
				string.Empty,
				ReminderItemStatus.Awaiting);

			// check results
			Assert.IsNotNull(reminderItem);
			Assert.AreNotEqual(Guid.Empty, reminderItem.Id);
		}

		[TestMethod]
		public void IsTimeToSend_True_For_Date_In_Past()
		{
			ReminderItem reminderItem = new ReminderItem(
				DateTimeOffset.Now.AddSeconds(-1),
				string.Empty,
				string.Empty,
				ReminderItemStatus.ReadyToSend);

			Assert.AreEqual(true, reminderItem.IsTimeToSend);

		}
	}
}
