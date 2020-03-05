using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{   
    public class PlayingField
    {
        public PlayingField(int size, GameModel model, Levels level)
        {

            _model = model;
            
            _size = size;
            _countFindFoxes = 0;
            _data.countPellingFoxes = 0;
            _level = level;
            SelectDataRelatedToLevels();
            _findNowFoxes = 0;
            _numberOfAllFoxes = _data.leftFoxes;
            _foxes = new Cell[size, size];
            FoxStart();
            RandomArray();
        }

        /// <summary>
        /// Create a new array of cells
        /// </summary>
        private void FoxStart()
        {
            for (int i = 0; i < _foxes.GetLength(0); i++)
            {
                for (int j = 0; j < _foxes.GetLength(1); j++)
                {
                    _foxes[i, j] = new Cell();
                }
            }
        }

        /// <summary>
        /// Select count of foxes and count of shots based on level and size of field
        /// </summary>
        /// <param name="size">size of playing field</param>
        /// <param name="x">random</param>
        private void SelectDataRelatedToLevels()
        {
            switch (_level)
            {
                case Levels.Easy:
                    _data.leftFoxes = SelectCountOfFoxes(70, 90);
                    _data.shots = _size * _size - _data.leftFoxes + 3;
                    break;
                case Levels.Medium:
                    _data.leftFoxes = SelectCountOfFoxes(50, 60);
                    _data.shots = _size * _size - _data.leftFoxes + 2;
                    break;
                case Levels.Hard:
                    _data.leftFoxes = SelectCountOfFoxes(30, 40);
                    _data.shots = _size * _size - _data.leftFoxes + 1;
                    break;
                case Levels.Training:
                    _data.leftFoxes = SelectCountOfFoxes(70, 90);
                    _data.shots = _size * _size + _size;
                    break;
            }
        }

        private int SelectCountOfFoxes(int min, int max)
        {
            return x.Next(min, max) * _size * _size / 100; 
        }
        /// <summary>
        /// Fills an array of numbers randomly
        /// </summary>
        private void RandomArray()
        {
            int i, j;
            int number = _numberOfAllFoxes;
            while (number != 0)
            {
                i = x.Next(0, _foxes.GetLength(0));
                j = x.Next(0, _foxes.GetLength(1));
                if ((i == 0) & (j == 0))
                {
                    j = +1;
                }
                if (_foxes[i, j].CountOfFoxes == 0)
                {
                    _foxes[i, j] = new Cell(1);
                    number -= 1;
                }
            }
        }

        /// <summary>
        /// When user hit in cell
        /// </summary>
        /// <param name="x">shift by horizontal </param>
        /// <param name="y">shift in the vertica</param>
        /// <returns></returns>
        public GameData EnterFox(int x, int y)
        {
            ShotInCell sc = ShotInCell.NoAction;

            sc = _foxes[x, y].Modificate();
            if (_data.leftFoxes > 0 && _data.shots > 0)
            {
                if (x == 0 && y == 0)
                {
                    _data.shots -= 1;
                    _data.state = GameState.HitFirstCell;
                    _model.HitFirstCell(_data);


                }
                else
                {
                    CountPelling(x, y);

                    if (sc == ShotInCell.NotFind)
                    {
                        _data.shots -= 1;
                        _data.state = GameState.Miss;
                        _model.MissFox(_data);
                    }
                    else
                    {
                        _countFindFoxes += _foxes[x, y].CountOfFoxes;
                        _findNowFoxes = _foxes[x, y].CountOfFoxes;
                        _data.leftFoxes -= _foxes[x, y].CountOfFoxes;

                        _data.state = GameState.Hit;
                        _model.HitFox(_data);
                    }
                }


            }
            if (_data.leftFoxes == 0)
            {
                _data.state = GameState.Win;
                _model.WinLoseGame(_data);
            }
            if (_data.shots <= 0)
            {
                _data.state = GameState.Lose;
                _model.WinLoseGame(_data);
            }
            //make void
            return _data;
        }

        /// <summary>
        /// Count pelling of cell(x, y)
        /// </summary>
        /// <param name="x">coordinate of cell  by horizontal </param>
        /// <param name="y">coordinate of cell in the vertica </param>
        private void CountPelling(int x, int y)
        {
            _data.countPellingFoxes = 0;
            for (int i = 0; i < _foxes.GetLength(0); i++)
            {
                _data.countPellingFoxes += _foxes[i, y].CountOfFoxes;
            }

            for (int j = 0; j < _foxes.GetLength(0); j++)
            {
                _data.countPellingFoxes += _foxes[x, j].CountOfFoxes;
            }
        }


        public int FieldSize
        {
            get
            {
                return _size;
            }
        }

        public Levels Level
        {
            get
            {
                return _level;
            }

        }

        public GameData Data
        {
            get
            {
                return _data;
            }
        }


        private Random x = new Random();
        private GameData _data;
        private int _size;
        private Cell[,] _foxes;
        private int _countFindFoxes;       // sum of caught foxes 
        private int _findNowFoxes;         // sum of caugnt foxes in the cell    
        private int _numberOfAllFoxes;
        private GameModel _model;
        private Levels _level;
    }
}
