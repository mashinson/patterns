using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFindFoxes
{
    public class ProgramMenu
    {
        public int CursorMenu
        {
            get
            {
                return cursorMenu;
            }
        }
        /// <summary>
        /// choose menu items
        /// </summary>
        /// <param name="mc">Menu of the console</param>
        /// <param name="dy">shift in the vertical</param>
        public void MoveMenu(MenuForm mc, int dy)
        {

            cursorMenu += dy;
            if (cursorMenu < 0)
            {
                cursorMenu = 2;
            }
            if (cursorMenu > 2)
            {
                cursorMenu = 0;
            }
            mc.SelectItemMenu((Menu)cursorMenu);
        }

        /// <summary>
        /// choose through Yes or No (If user win)
        /// </summary>
        /// <param name="mc">Menu of the console</param>
        /// <param name="dx">shift by horizontals</param>
        public void MoveYesNo(MenuForm mc, int dx)
        {
            cursorYesNo += dx;
            if (cursorYesNo <= 0)
            {
                cursorYesNo = 0;
            }
            if (cursorYesNo >= 1)
            {
                cursorYesNo = 1;
            }
            int x = 20;
            int y = 20;
            mc.SelectYesNo((YesNo)cursorYesNo, x, y);
        }

        /// <summary>
        /// choose through Yes or No (Exit game) 
        /// </summary>
        /// <param name="mc">Menu of the console</param>
        /// <param name="dx">shift by horizontals</param>
        public void MoveYesNoExit(MenuForm mc, int dx)
        {
            cursorYesNoExit += dx;
            if (cursorYesNoExit <= 0)
            {
                cursorYesNoExit = 0;
            }
            if (cursorYesNoExit >= 1)
            {
                cursorYesNoExit = 1;
            }
            int x = 20;
            int y = 10;
            mc.SelectYesNo((YesNo)cursorYesNoExit, x, y);
        }

        public int CursorYesNoExit
        {
            get
            {
                return cursorYesNoExit;
            }

        }
        public int CursorYesNo
        {
            get
            {
                return cursorYesNo;
            }
        }
        private int cursorMenu;
        private int cursorYesNo;
        private int cursorYesNoExit;
    }
}
