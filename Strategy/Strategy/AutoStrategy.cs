using System;

namespace Strategy
{
    partial class Program
    {
        public class AutoStrategy : IRouteStrategy
        {
            public void Algorithm()
            {
                Console.WriteLine("Go by auto");
            }
        }


    }
}
