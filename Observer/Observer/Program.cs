using System;

namespace Observer
{
    partial class Program
    {
        static void Main(string[] args)
        {
            IClient cl1 = new Client("Client1");
            IClient cl2 = new Client("Client2");
            IClient cl3 = new Client("Client3");
            IEmailServer server = new EmailServer();
            server.AddClient(cl1);
            server.AddClient(cl2);
            server.AddClient(cl3);

            server.NotifyClients();
            Console.ReadLine();
        }

    }
}
