using System;
using System.Collections.Generic;
using System.Text;

namespace Homework12
{
	class ChatReminder:ReminderItem
	{
		public string ChatName { get; set; }
		public string AccountName { get; set; }
		public ChatReminder(
			string accountName, string chatName, 
			DateTimeOffset alarmDate, string alarmMessage)
			:base(alarmDate,alarmMessage)
		{
			AccountName = accountName;
			ChatName = chatName;
		}

		public override void WriteProperties()
		{
			Console.Write($"Account name {AccountName}; Chat name: {ChatName}; ");
			base.WriteProperties();
		}
	}
}
