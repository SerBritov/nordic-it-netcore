using System;
using Reminder.Storage.Core;
using Reminder.Storage.InMemory;
using Reminder.Domain;
using Reminder.Sender.Telegram;
using Reminder.Reciever.Telegram;

namespace Reminder.App
{
    class Program
    {
        static void Main(string[] args)
        {
			string token = @"1658241756:AAEGWnqk2BVg6qTOmaaQAby-g00DiqWhFRY";
			var storage = new InMemoryReminderStorage();
            var sender = new TelegramReminderSender(token);
            var receiver = new TelegramReminderReceiver(token);

            using var domain = new ReminderDomain(
                storage,
                sender,
                receiver,
                TimeSpan.FromSeconds(1),
                TimeSpan.FromSeconds(1));
			domain.AddingSucceeded += (s, e) =>
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("OK ");
				Console.ResetColor();
				Console.WriteLine(
					$"Reminder item ID {e.Id} " +
					$"from {e.ContactId} " +
					$"with message \"{e.Message}\" " +
					$"SCHEDULED on {e.Date:G}");
			};

			domain.AddingFailed += (s, e) =>
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write($"Error ");
				Console.ResetColor();
				Console.WriteLine(
					$"Cannot SCHEDULE reminder item ID {e.Id} " +
					$"from {e.ContactId} " +
					$"with message \"{e.Message}\" " +
					$"to be sent on {e.Date:G}");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(e.Exception);
				Console.ResetColor();
			};

			domain.SendingSucceeded += (s, e) =>
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("OK ");
				Console.ResetColor();
				Console.WriteLine(
					$"Reminder item ID {e.Id} " +
					$"from {e.ContactId} " +
					$"with message \"{e.Message}\" " +
					$"SENT on {e.Date:G}");
			};

			domain.SendingFailed += (s, e) =>
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write($"Error ");
				Console.ResetColor();
				Console.WriteLine(
					$"Cannot SEND reminder item ID {e.Id} " +
					$"from {e.ContactId} " +
					$"with message \"{e.Message}\" " +
					$"on {e.Date:G}");
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(e.Exception);
				Console.ResetColor();
			};

			domain.Run();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
    }
}
