using System;

namespace Observer
{
    partial class Program
    {
        class Client : IClient
        {
            public Client(string name)
            {
                Name = name;
            }
            public string Name { get; set; }
            public void Update()
            {
                 Console.WriteLine($"Client {Name} gets email");
            }
        }

    }
}
