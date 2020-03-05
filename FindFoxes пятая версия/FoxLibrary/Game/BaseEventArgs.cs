using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    /// <summary>
    /// class inherit EventArgs and used for setting info for Game
    /// </summary>
    public class GameBeginEventArgs : EventArgs
    {
        public GameBeginEventArgs(int size, Levels level)
        {
            _size = size;
            _level = level;
        }
        public GameBeginEventArgs(int size, int leftFoxes, int Shots, Levels level)
        {
            _size = size;
            _leftFoxes = leftFoxes;
           _shots = Shots;
            _level = level;
        }
        public int Size
        {
            get
            {
                return _size;
            }
        }

        public int LeftFoxes
        {
            get
            {
                return _leftFoxes;
            }
        }

        public int Shots
        {
            get
            {
                return _shots;
            }
        }

        public Levels Level
        {
            get
            {
                return _level;
            }
        }
        private int _size = 0;
        private int _leftFoxes = 0;
        private int _shots = 0;
        private Levels _level = Levels.Easy;
    }


    /// <summary>
    ///  class inherit EventArgs and used for setting PlayingField
    /// </summary>
    public class GameCurrentEventArgs : EventArgs
    {
        public GameCurrentEventArgs(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }
        private int x = 0;
        private int y = 0;
    }


    /// <summary>
    /// class inherit EventArgs and used for setting GameData
    /// </summary>
    public class GameModelUpdateEventArgs : EventArgs
    {
        public GameModelUpdateEventArgs(GameData data)
        {
            _data = data;
        }

        public GameState State
        {
            get
            {
                return _data.state;
            }
        }

        public int Shots
        {
            get
            {
                return _data.shots;
            }
        }

        public int Pelling
        {
            get
            {
                return _data.countPellingFoxes;
            }
        }

        public int LeftFoxes
        {
            get
            {
                return _data.leftFoxes;
            }
        }

      

        private GameData _data;
      
    }
}
