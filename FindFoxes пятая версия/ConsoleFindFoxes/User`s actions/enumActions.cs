using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFindFoxes
{
    ///// <summary>
    ///// All actions that a user can make
    ///// </summary>
    public enum Action : ushort
    {
        NoAction = 0x00,
        Left = 0x01,
        Right = 0x02,
        Exit = 0x04,
        Top = 0x08,
        Bottom = 0x10,
        Enter = 0x20

    }
}
