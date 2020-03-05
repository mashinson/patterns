using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorymethod
{
    public abstract class Airplane
    {
        public Airplane(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public abstract string DoAircraftMaintenance();
    }
}
