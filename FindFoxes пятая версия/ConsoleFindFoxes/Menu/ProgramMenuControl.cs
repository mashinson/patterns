using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFoxes;
namespace ConsoleFindFoxes
{
    class ProgramMenuControl : CommonFormInterface
    {

        public ProgramMenuControl(string strMenu, ProgramMenu progMenu, MenuForm menuForm)
        {
            _strMenu = strMenu;
            _progMenu = progMenu;
            _menuForm = menuForm;
        }

        /// <summary>
        /// Start show Menu Form
        /// </summary>
        public void Show()
        {
            Menu();
        }
        
        /// <summary>
        /// Move by Menu
        /// </summary>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public void Menu()
        {
            Console.Clear();
            Console.Write(_strMenu); // draw menu
            Console.CursorVisible = false;

            _progMenu.MoveMenu(_menuForm, 0);

            ChooseMenuItem();
           
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChooseMenuItem()
        {
            bool bl = true;
            while (bl)
            {
                _action = UserAction.GetUserAction();
                switch (_action)
                {
                    case Action.Bottom:
                        _progMenu.MoveMenu(_menuForm, 1);
                        break;
                    case Action.Top:
                        _progMenu.MoveMenu(_menuForm, -1);
                        break;
                    case Action.Enter:
                        bl = false;
                        Console.CursorVisible = true;
                        
                        break;
                }

            }
            switch (_progMenu.CursorMenu)
            {
                case 0:
                    Program.controller.RunForm(GameForms.SetInfo);
                    break;
                case 1:
                    Program.controller.RunForm(GameForms.Reference);
                    break;
                case 2:
                    //Environment.Exit(0);
                    break;

            }
        }

        private string _strMenu;
        private ProgramMenu _progMenu;
        private MenuForm _menuForm;
        private Action _action;

    }
}
