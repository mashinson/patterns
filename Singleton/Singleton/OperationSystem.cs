using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class OperationSystem
    {
        public string Version { get; private set; }

        private OperationSystem(string version)
        {
            Version = version;
        }

        public static OperationSystem getInstance(string version)
        {
            lock (syncRoot)
            {
                if (instance == null)
                    instance = new OperationSystem(version);
            }
            return instance;
        }

        private static OperationSystem instance;
        private static object syncRoot = new Object();
    }
}
