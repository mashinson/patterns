using FindFoxes;
using System;

namespace ConsoleFindFoxes
{
    public class GameProgramControl : frmGameInterface
    {
        public const string NO_ACTION = "   ";
        public const string FIND_FOX = (" V ");
        public const string MiSS_FOX = (" X ");

        public GameProgramControl(string strExit)
        {
            _strExit = strExit;

        }
        public void Show()
        {
            Game();
        }

        public void SetView(GameView view)
        {
            _view = view;
        }


        /// <summary>
        /// Set info for game
        /// </summary>
        /// <param name="size">size of game</param>
        /// <param name="leftFoxes">count of foxes</param>
        /// <param name="Shots">count of shots</param>
        /// <param name="level">level of game</param>
        public void SetupGame(int size, int leftFoxes, int Shots, Levels level)
        {
            _size = size;
            _form = new GameForm(size);
            findFoxes = new string[size, size];
            NoActioninField();
            _form.DrawField(findFoxes);
            MoveGameCursore(0, 0);
        }

        private void NoActioninField()
        {
            for (int i = 0; i < findFoxes.GetLength(0); i++)
            {
                for (int j = 0; j < findFoxes.GetLength(1); j++)
                {
                    findFoxes[i, j] = NO_ACTION;
                }
            }
        }

        /// <summary>
        /// Move the cursor on the playing field
        /// </summary>
        /// <param name="dx">shift by horizontals</param>
        /// <param name="dy">shift in the vertical</param>
        public void MoveGameCursore(int dx, int dy)
        {
            if (cursorX + dx >= 0 && cursorX + dx < _size && cursorY + dy >= 0 && cursorY + dy < _size)
            {
                cursorX = cursorX + dx;
                cursorY = cursorY + dy;
            }
            _form.CursorPosition(cursorX, cursorY);
        }


        /// <summary>
        /// All actions in game 
        /// </summary>
        public void Game()
        {

            Console.CursorVisible = true;
            _game = ExitTheGame.ContinueGame;
            while (_game == ExitTheGame.ContinueGame)
            {
                action = UserAction.GetUserAction();
                switch (action)
                {
                    case Action.Left:
                        MoveGameCursore(-1, 0);
                        break;
                    case Action.Right:
                        MoveGameCursore(1, 0);
                        break;
                    case Action.Top:
                        MoveGameCursore(0, -1);
                        break;
                    case Action.Bottom:
                        MoveGameCursore(0, 1);
                        break;
                    case Action.Enter:
                        showPeleng = !showPeleng;
                        if (showPeleng)
                        {
                            Console.Clear();
                            _form.DrawField(findFoxes);
                            Console.CursorVisible = false;
                            if (findFoxes[cursorX, cursorY].Equals(NO_ACTION))
                            {
                                _view.ShotsFired(cursorX, cursorY);
                            }

                        }
                        else
                        {
                            Console.Clear();
                            _form.DrawField(findFoxes);
                            MoveGameCursore(0, 0);
                            Console.CursorVisible = true;
                        }
                        break;
                    case Action.Exit:
                        Console.WriteLine(_strExit);
                        if (GameExit() == false)
                        {
                            _game = ExitTheGame.MenuGame;
                        }
                        else
                        {
                            Console.Clear();
                            _form.DrawField(findFoxes);
                            showPeleng = false;
                        }
                        break;
                }
            }
            WhatToDoNext();

        }

        private void WhatToDoNext()
        {
            switch (_game)
            {
                case ExitTheGame.WinGame:
                    Program.controller.RunForm(GameForms.Win);
                    break;
                case ExitTheGame.LoseGame:
                    Program.controller.RunForm(GameForms.Lose);
                    break;
                case ExitTheGame.MenuGame:
                    Program.controller.RunForm(GameForms.Menu);
                    break;
            }
        }

        //Show info on form
        #region ShowHintOnForm
        public void HitCell(int leftFoxes, int shots)
        {

            findFoxes[cursorX, cursorY] = FIND_FOX;
            _form.Peleng(findFoxes, cursorX, cursorY);

            Console.SetCursorPosition(0, 7 + 2 * _size);
            Console.Write("Вы попали!!!");

            Console.SetCursorPosition(0, 8 + 2 * _size);
            Console.Write("Количество лис, которых нужно найти: {0}", leftFoxes);

            Console.SetCursorPosition(0, 9 + 2 * _size);
            Console.Write("Количество жизней осталось: {0}", shots);
            _game = ExitTheGame.ContinueGame;

        }

        public void HitFirstCell(int shots)
        {

            findFoxes[cursorX, cursorY] = MiSS_FOX;
            _form.Peleng(findFoxes, cursorX, cursorY);

            Console.SetCursorPosition(0, 7 + 2 * _size);
            Console.WriteLine("Здесь находитесь ВЫ. Введите другую клеточку.");

            Console.SetCursorPosition(0, 8 + 2 * _size);
            Console.Write("Количество жизней осталось: {0}", shots);
            _game = ExitTheGame.ContinueGame;

        }

        public void MissFoxs(int pelling, int shots)
        {

            findFoxes[cursorX, cursorY] = MiSS_FOX;
            _form.Peleng(findFoxes, cursorX, cursorY);

            Console.SetCursorPosition(0, 7 + 2 * _size);
            Console.Write("Вы не попали:((((");

            Console.SetCursorPosition(0, 8 + 2 * _size);
            Console.Write("Количество лис по пеллингу: {0}", pelling);

            Console.SetCursorPosition(0, 9 + 2 * _size);
            Console.Write("Количество жизней осталось: {0}", shots);
            _game = ExitTheGame.ContinueGame;
        }

        public void WinLose(GameState state)
        {

            switch (state)
            {
                case GameState.Win:
                    _game = ExitTheGame.WinGame;
                    break;
                case GameState.Lose:
                    _game = ExitTheGame.LoseGame;
                    break;
            }
        }
        #endregion


        /// <summary>
        /// Exit from game
        /// </summary>
        /// <param name="strExit">Picture of Exit</param>
        /// <param name="pm">Program Menu</param>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        private bool GameExit()
        {
            bool EndGame = false;
            ProgramMenu progMenu = new ProgramMenu();
            MenuForm menuForm = new MenuForm();
            Console.Clear();
            Console.WriteLine(_strExit);
            progMenu.MoveYesNoExit(menuForm, 0);
            bool bl = true;
            while (bl)
            {
                action = UserAction.GetUserAction();
                switch (action)
                {
                    case Action.Left:
                        progMenu.MoveYesNoExit(menuForm, -1);
                        break;
                    case Action.Right:
                        progMenu.MoveYesNoExit(menuForm, 1);
                        break;
                    case Action.Enter:

                        if (progMenu.CursorYesNoExit == 0)
                        {
                            EndGame = false;
                            bl = false;


                        }
                        else
                        {
                            EndGame = true;
                            bl = false;
                        }
                        break;
                }
            }
            return EndGame;
        }

        // <summary>
        /// View of this form
        /// </summary>
        private GameView _view;
        private GameForm _form;
        private string _strExit;
        private int cursorX;
        private int cursorY;
        private Action action;
        private bool showPeleng;
        private int _size;
        private string[,] findFoxes;
        private ExitTheGame _game = ExitTheGame.ContinueGame;
    }
}
