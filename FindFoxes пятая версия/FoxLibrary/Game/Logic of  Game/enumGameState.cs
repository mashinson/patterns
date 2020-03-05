using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    /// <summary>
    /// States of game 
    /// </summary>
    public enum GameState
    {
        NoAction,
        Win,
        Lose,
        Hit,
        Miss,
        HitFirstCell
    }
}
