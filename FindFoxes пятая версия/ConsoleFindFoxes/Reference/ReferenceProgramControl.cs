using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFoxes;
namespace ConsoleFindFoxes
{
    class ReferenceProgram : CommonFormInterface
    {

        public ReferenceProgram(string strReference)
        {
            _strReference = strReference;
        }

        public void Show()
        {
            Reference();
        }

        public void Reference()
        {
            Console.Clear();
            Console.WriteLine(_strReference);
            Console.SetCursorPosition(0, 0);

            ReferenceExit();

        }

        /// <summary>
        /// Exit menu
        /// </summary>
        private void ReferenceExit()
        {
            bool bl = true;
            while (bl)
            {
                _action = UserAction.GetUserAction();
                if (_action == Action.Exit)
                {
                    bl = false;                  
                }
            }
            Program.controller.RunForm(GameForms.Menu);
        }

        private string _strReference;
        private Action _action;
    }
}
