using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    /// <summary>
    ///  info that will be shown on form  
    /// </summary>
    public struct GameData
    {
        public int shots;              // sum of shots
        public int countPellingFoxes;    // sum of caught foxes by pelling
        public int leftFoxes;            // sum of the remaining foxes        
        public GameState state;          // state of Game
    }
}
