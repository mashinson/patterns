using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Thread(() =>
            {
                OperationSystem os = OperationSystem.getInstance("Windows 10");
                Console.WriteLine(os.Version);

            })).Start();


            OperationSystem os1 = OperationSystem.getInstance("Windows 8");
            Console.WriteLine(os1.Version);
            Console.ReadLine();
        }
    }
}
