using System;

namespace Strategy
{
    partial class Program
    {
        public class WalkingStrategy : IRouteStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Go by foot");
            }
        }


    }
}
