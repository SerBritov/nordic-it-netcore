using System;
using Reminder.Storage.Core;


namespace Reminder.Reciever.Core
{
    public class MessageReceivedEventArgs:EventArgs
    {
        
        public string Message { get; set; }

        public string ContactId { get; set; }

        
    }
}