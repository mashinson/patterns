namespace Strategy
{
    partial class Program
    {
        public class Navigator
        {
            public IRouteStrategy RouteStrategy { get; set; }
            public Navigator()
            {

            }
            public Navigator(IRouteStrategy strategy)
            {
                RouteStrategy = strategy;
            }

            public void ExecuteAlgorithm()
            {
                RouteStrategy.Algorithm();
            }
        }


    }
}
