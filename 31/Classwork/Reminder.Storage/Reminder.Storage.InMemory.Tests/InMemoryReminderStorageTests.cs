using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reminder.Storage.Core;
using System;
using System.Collections.Generic;

namespace Reminder.Storage.InMemory.Tests
{
	[TestClass]
	public class InMemoryReminderStorageTests
	{
		[TestMethod]
		public void Get_Returns_Null_For_Absent_Id()
		{
			var storage = new InMemoryReminderStorage();

			ReminderItem actual = storage.Get(Guid.Empty);

			Assert.IsNull(actual);
		}

		[TestMethod]
		public void Get_Returns_Just_Added_Item()
		{
			DateTimeOffset date = DateTimeOffset.Now;
			string message = "TEST MESSAGE";
			string contactId = "TEST ID 123";
			ReminderItemStatus status = ReminderItemStatus.Failed;

			var expected = new ReminderItemRestricted(date, message, contactId, status);

			var storage = new InMemoryReminderStorage();

			// test action

			Guid guid = storage.Add(expected);
			var actual = storage.Get(guid);

			// check results
			Assert.IsNotNull(actual);
			Assert.AreEqual(guid, actual.Id);
			Assert.AreEqual(expected.Date, actual.Date);
			Assert.AreEqual(expected.ContactId, actual.ContactId);
			Assert.AreEqual(expected.Message, actual.Message);
			Assert.AreEqual(expected.Status, actual.Status);
		}

		[TestMethod]
		public void GetList_Does_Not_Return_Null_If_No_Items_Found()
		{
			var storage = new InMemoryReminderStorage();

			var actual = storage.GetList(ReminderItemStatus.Awaiting);

			Assert.IsNotNull(actual);
		}

		[TestMethod]
		public void GetList_Returns_2_Failed_ReminderItems_From_All()
		{
			var reminders = new List<ReminderItem>
			{
				new ReminderItem {
					Id = Guid.Parse("00000000-0000-0000-0000-111111111111"),
					Date = DateTimeOffset.Parse("2001-01-01 01:01:01+0000"),
					Message = "Awaiting",
					ContactId = "1",
					Status = ReminderItemStatus.Awaiting
				},
				new ReminderItem {
					Id = Guid.Parse("00000000-0000-0000-0000-222222222222"),
					Date = DateTimeOffset.Parse("2002-02-02 02:02:02+0000"),
					Message = "ReadyToSend",
					ContactId = "2",
					Status = ReminderItemStatus.ReadyToSend
				},
				new ReminderItem {
					Id = Guid.Parse("00000000-0000-0000-0000-333333333333"),
					Date = DateTimeOffset.Parse("2003-03-03 03:03:03+0000"),
					Message = "SuccessfullySent",
					ContactId = "3",
					Status = ReminderItemStatus.SuccessfullySent
				},
				new ReminderItem {
					Id = Guid.Parse("00000000-0000-0000-0000-444444444444"),
					Date = DateTimeOffset.Parse("2004-04-04 04:04:04+0000"),
					Message = "Failed",
					ContactId = "4",
					Status = ReminderItemStatus.Failed
				},
				new ReminderItem {
					Id = Guid.Parse("00000000-0000-0000-0000-555555555555"),
					Date = DateTimeOffset.Parse("2005-05-05 05:05:05+0000"),
					Message = "Failed",
					ContactId = "5",
					Status = ReminderItemStatus.Failed
				}
			};

			var storage = new InMemoryReminderStorage();

			foreach (var reminder in reminders)
				storage._reminders.Add(reminder.Id, reminder.ToReminderItemRestricted());

			var actual = storage.GetList(ReminderItemStatus.Failed);

			Assert.IsNotNull(actual);
			Assert.AreEqual(2, actual.Count);

			ReminderItem itemForFullTest;
			itemForFullTest = actual[0].Id == Guid.Parse("00000000-0000-0000-0000-444444444444")
				? actual[0]
				: actual[1];

			Assert.AreEqual(DateTimeOffset.Parse("2004-04-04 04:04:04+0000"), itemForFullTest.Date);
			Assert.AreEqual("Failed", itemForFullTest.Message);
			Assert.AreEqual("4", itemForFullTest.ContactId);
			Assert.AreEqual(ReminderItemStatus.Failed, itemForFullTest.Status);

			itemForFullTest = actual[1].Id == Guid.Parse("00000000-0000-0000-0000-555555555555")
				? actual[1]
				: actual[0];

			Assert.AreEqual(DateTimeOffset.Parse("2005-05-05 05:05:05+0000"), itemForFullTest.Date);
			Assert.AreEqual("Failed", itemForFullTest.Message);
			Assert.AreEqual("5", itemForFullTest.ContactId);
			Assert.AreEqual(ReminderItemStatus.Failed, itemForFullTest.Status);
		}

		[TestMethod]
		public void Update_Throws_InvalidOperationException_If_ReminderItem_With_Given_Id_Does_Not_Exist()
		{
			var storage = new InMemoryReminderStorage();

			var itemToUpdate = new ReminderItem();

			Assert.ThrowsException<InvalidOperationException>(() => storage.Update(itemToUpdate));
		}

		[TestMethod]
		public void Update_Updates_All_Properties_Of_ReminderItem_With_Given_Id_If_It_Exists()
		{
			var original = new ReminderItem
			{
				Id = Guid.Parse("00000000-0000-0000-0000-111111111111"),
				Date = DateTimeOffset.Parse("2001-01-01 01:01:01+0000"),
				Message = "Awaiting",
				ContactId = "1",
				Status = ReminderItemStatus.Awaiting
			};
			var storage = new InMemoryReminderStorage();
			storage._reminders.Add(original.Id, original.ToReminderItemRestricted());

			var updated = new ReminderItem
			{
				Id = Guid.Parse("00000000-0000-0000-0000-111111111111"),
				Date = DateTimeOffset.Parse("2002-02-02 02:02:02+0000"),
				Message = "ReadyToSend",
				ContactId = "2",
				Status = ReminderItemStatus.ReadyToSend
			};

			storage.Update(updated);

			var actual = storage.Get(Guid.Parse("00000000-0000-0000-0000-111111111111"));

			Assert.IsNotNull(actual);
			Assert.AreEqual(updated.Id, actual.Id);
			Assert.AreEqual(updated.Date, actual.Date);
			Assert.AreEqual(updated.Message, actual.Message);
			Assert.AreEqual(updated.ContactId, actual.ContactId);
			Assert.AreEqual(updated.Status, actual.Status);
		}
	}
}
