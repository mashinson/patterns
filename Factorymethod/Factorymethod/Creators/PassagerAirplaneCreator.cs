using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorymethod
{
    public class PassagerAirplaneCreator : Creator
    {
        public override Airplane CreatePlane(string name)
        {
            return new PassagerAirplane(name);
        }
    }
}
