using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorymethod
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Airplane> planes = new List<Airplane>();

            Creator cr = new CargoAirplaneCreator();
            var cargoPlane = cr.CreatePlane("Cargo1");
            planes.Add(cargoPlane);

            Creator ps = new PassagerAirplaneCreator();
            var passagerPlane = ps.CreatePlane("Passager1");
            planes.Add(passagerPlane);

            foreach (var item in planes)
            {
                Console.WriteLine(item.DoAircraftMaintenance());
            }
            Console.ReadLine();
        }
    }
}
