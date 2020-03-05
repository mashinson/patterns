using System;

namespace Strategy
{
    partial class Program
    {
        static void Main(string[] args)
        {
            IRouteStrategy b = new BicycleStrategy();
            IRouteStrategy f = new WalkingStrategy();
            IRouteStrategy p = new PublicTransportStrategy();
            IRouteStrategy a = new AutoStrategy();

            Navigator navigator = new Navigator(b);
            navigator.ExecuteAlgorithm();
            navigator.RouteStrategy = f;
            navigator.ExecuteAlgorithm();

            Console.ReadLine();
        }


    }
}
