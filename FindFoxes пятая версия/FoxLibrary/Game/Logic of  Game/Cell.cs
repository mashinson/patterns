using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{

    /// <summary>
    /// Сell in the playfield 
    /// </summary>
    public class Cell
    {
        public Cell()
        {
            _counOfFoxes = 0;
            _findFoxs = ShotInCell.NoAction;
        }
        public Cell( int CountOfFoxes)
        {
            _counOfFoxes = CountOfFoxes;
            _findFoxs = ShotInCell.NoAction;
        }

        /// <summary>
        /// count of foxes in cell
        /// </summary>
        public int CountOfFoxes
        {
            get
            {
                return _counOfFoxes;
            }
        }

        /// <summary>
        /// find/not find foxesin cell
        /// </summary>
        public ShotInCell FindFoxs
        {
            get
            {
                return _findFoxs;
            }

        }

        /// <summary>
        /// moditicate the state of the cell depending were there foxes or not
        /// </summary>
        /// <returns></returns>
        public ShotInCell Modificate()
        {
            ShotInCell sc = ShotInCell.NotFind;
            if (CountOfFoxes > 0)
            {
                sc = ShotInCell.Find;
            }
            return sc;
        }
    
        private int _counOfFoxes; // count of Foxes in one cell
        private ShotInCell _findFoxs = ShotInCell.NoAction;     // Foxes which found \ not found

    }
}
