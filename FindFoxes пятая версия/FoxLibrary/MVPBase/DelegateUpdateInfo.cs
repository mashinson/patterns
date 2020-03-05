using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    /// <summary>
    /// Delegate for all events in application
    /// </summary>
    public delegate void UpdateInfo<T>(T args) where T : EventArgs;
}
