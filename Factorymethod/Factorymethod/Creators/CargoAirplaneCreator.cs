using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorymethod
{
    class CargoAirplaneCreator : Creator
    {
        public override Airplane CreatePlane(string name)
        {
            return new CargoAirplane(name);
        }
    }
}
