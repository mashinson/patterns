using System;

namespace Strategy
{
    partial class Program
    {
        public class PublicTransportStrategy : IRouteStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Go by train/bus");
            }
        }


    }
}
