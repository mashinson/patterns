using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorymethod
{
    public class CargoAirplane : Airplane
    {
        public CargoAirplane(string name) : base(name) { }

        public override string DoAircraftMaintenance()
        {
            return String.Format("The cargo aircraft {0} maintenance is complited", Name);
        }
    }
}
