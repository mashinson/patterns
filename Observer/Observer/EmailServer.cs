using System.Collections.Generic;

namespace Observer
{
    partial class Program
    {
        class EmailServer : IEmailServer
        {
            private List<IClient> clients;
            public EmailServer()
            {
                clients = new List<IClient>();
            }
            public void AddClient(IClient o)
            {
                clients.Add(o);
            }

            public void RemoveClient(IClient o)
            {
                clients.Remove(o);
            }

            public void NotifyClients()
            {
                foreach (var observer in clients)
                    observer.Update();
            }
        }

    }
}
