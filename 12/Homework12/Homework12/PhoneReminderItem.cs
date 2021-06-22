using System;
using System.Collections.Generic;
using System.Text;

namespace Homework12
{
	class PhoneReminderItem : ReminderItem
	{
		public string PhoneNumber { get; set; }
		public PhoneReminderItem(string phoneNumber, DateTimeOffset _alarmDate, string _alarmMessage):base(_alarmDate, _alarmMessage)
		{
			PhoneNumber = phoneNumber;
		}

		public override void WriteProperties()
		{
			Console.Write($"Phone number: {PhoneNumber}; ");
			base.WriteProperties();
		}

	}
}
