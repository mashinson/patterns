using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFoxes;

namespace ConsoleFindFoxes
{
    public class WinLoseGame : CommonFormInterface
    {
        private string _strWinLose;
        private GameState _state;
        public WinLoseGame(string strWinLose, GameState state)
        {
            _strWinLose = strWinLose;
            _state = state;
        }



        public void Show()
        {
            WinGame();
        }

        /// <summary>
        /// If user wins/loses game
        /// </summary>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public void WinGame()
        {
            ProgramMenu progMenu = new ProgramMenu();
            MenuForm menuForm = new MenuForm();
            Console.Clear();
            Console.Write(_strWinLose);

            if (_state == GameState.Win)
            {
                Console.SetCursorPosition(19, 13);
                Console.WriteLine(" Поздравляю, вы победили! ");

            }
            if (_state == GameState.Lose)
            {
                Console.SetCursorPosition(24, 13);
                Console.WriteLine(" Вы проиграли! ");
            }
            progMenu.MoveYesNo(menuForm, 0);
            Console.SetCursorPosition(38, 12);

            GameWinMoveYesNo(progMenu, menuForm);
        }

        /// <summary>
        /// Choose to begin a new game or to go to the menu
        /// </summary>
        /// <param name="progMenu">Program Menu</param>
        /// <param name="menuForm">User Table</param>
        public void GameWinMoveYesNo(ProgramMenu progMenu, MenuForm menuForm)
        {
            bool ch = true;
            while (ch)
            {
               Action action = UserAction.GetUserAction();
                switch (action)
                {
                    case Action.Left:
                        progMenu.MoveYesNo(menuForm, -1);
                        break;
                    case Action.Right:
                        progMenu.MoveYesNo(menuForm, 1);
                        break;
                    case Action.Enter:
                        ch = false;                     
                        break;
                }
            }
            if (progMenu.CursorYesNo == 0)
            {
                Program.controller.RunForm(GameForms.SetInfo);
            }
            else
            {
                Program.controller.RunForm(GameForms.Menu);
            }
        }
     
    }
}
