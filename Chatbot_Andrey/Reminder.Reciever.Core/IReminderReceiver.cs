using System;

namespace Reminder.Reciever.Core
{
    public interface IReminderReceiver
    {
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
        void Run();
    }

}
