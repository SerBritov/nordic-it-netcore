using System;
using System.IO;

namespace Reminder.Sender.Core
{
    public interface IReminderSender
    {
        public void Send(string id, string message);
    }
}
