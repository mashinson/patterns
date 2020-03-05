using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFoxes;
namespace ConsoleFindFoxes
{    
    public struct UserAction
    {
        /// <summary>
        /// Depending on which key was pressed, one of the actions is performed
        /// </summary>
        /// <returns>action</returns>
        public static Action GetUserAction()
        {
            Action action = Action.NoAction;


            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    action = Action.Left;
                    break;
                case ConsoleKey.RightArrow:
                    action = Action.Right;
                    break;
                case ConsoleKey.UpArrow:
                    action = Action.Top;
                    break;
                case ConsoleKey.DownArrow:
                    action = Action.Bottom;
                    break;
                case ConsoleKey.Escape:
                    action = Action.Exit;
                    break;
                case ConsoleKey.Enter:
                    action = Action.Enter;
                    break;

            }
            return action;
        }
    }
}
