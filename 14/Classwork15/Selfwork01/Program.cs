using System;

namespace Selfwork01
{
    class Program
    {
        static void Main(string[] args)
        {
            Account<int> acc1 = new Account<int>(24, "Sergei");
            Account<string> acc2 = new Account<string>("id:256", "Andrei");
            Account<Guid> acc3 = new Account<Guid>(Guid.NewGuid(), "Alexei");

            IAccount[] account = new IAccount[3] { acc1, acc2, acc3 };

            foreach (IAccount acc in account)
                acc.WriteProperties();
        }
    }
}
