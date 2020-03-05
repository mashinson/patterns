namespace Observer
{
    partial class Program
    {
        interface IEmailServer
        {
            void AddClient(IClient o);
            void RemoveClient(IClient o);
            void NotifyClients();
        }

    }
}
