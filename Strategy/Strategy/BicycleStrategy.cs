using System;

namespace Strategy
{
    partial class Program
    {
        public class BicycleStrategy : IRouteStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Go by bicycle");
            }
        }


    }
}
