using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    public class SetGameView
    {
        /// <summary>
        /// This event works when player has chosen size and level of game, also in GamePresenter on this event 
        ///signed the method handleBeginEvent
        /// </summary>
        public event UpdateInfo<GameBeginEventArgs> SizeUpdateEvent;


        public SetGameView(frmSetGameInterface form)
        {
            _form = form;
            _form.SetView(this);         
        }

        /// <summary>
        /// it is called from form when player has chosen size and level of game
        /// </summary>
        /// <param name="size">size f playing field</param>
        /// <param name="level">level of game</param>
        public void sizeUpdated(int size, Levels level)
        {
            SizeUpdateEvent(new GameBeginEventArgs(size, level));
        }

        public void Show()
        {
            _form.Show();
        }

        private frmSetGameInterface _form;
    }
}
