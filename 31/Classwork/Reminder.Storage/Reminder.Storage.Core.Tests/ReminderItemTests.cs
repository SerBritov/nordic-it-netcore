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
		public void IsTimeToSend_True_For_Date_In_The_Past()
		{
			var reminderItem = new ReminderItem(
				Guid.NewGuid(),
				DateTimeOffset.Now.AddDays(-1),
				string.Empty,
				string.Empty,
				ReminderItemStatus.Awaiting);

			Assert.IsTrue(reminderItem.IsTimeToSend);
		}
	}
}
