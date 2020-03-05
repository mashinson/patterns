using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    public class GameView
    {
        // This event works when player has made a shoot, also in GamePresenter on this event 
        //signed the method handleCurrentEvent
        public event UpdateInfo<GameCurrentEventArgs> FoxShotEvent;  

        public GameView(frmGameInterface form)
        {
            _form = form;
            form.SetView(this);
        }

        /// <summary>
        /// it is called from Game Form and send info about coordinates of chosen cell
        /// </summary>
        /// <param name="X">Coordinate of the selected cell horizontally</param>
        /// <param name="Y">Coordinate of the selected cell vertically</param>
        public void ShotsFired(int X, int Y)
        {
            FoxShotEvent(new GameCurrentEventArgs(X, Y));
        }


        /// <summary>
        /// When in GameModel PlayingFieldCreatedEvent loaded, in GamePresenter handleGameCreatedEvent is called and handleGameCreatedEvent 
        /// called this method, that transmits the information to form for displaying
        /// </summary>
        /// <param name="size">size of playingFiled</param>
        /// <param name="leftFoxes">how many foxes player need to find</param>
        /// <param name="Shots">how many lifes player has</param>
        /// <param name="level">what level of game player has chosen</param>
        public void createField(int size, int leftFoxes, int Shots, Levels level)
        {
            _form.SetupGame(size, leftFoxes, Shots, level);
        }


        public void Show()
        {
            _form.Show();
        }

        /// <summary>
        /// Different situations depending on whether in the 
        /// selected cells were foxes or player win/lose game, hit first cell
        /// </summary>
        #region InfoToForm
        public void WinLoseState(GameState state)
        {
            _form.WinLose(state);
        }
        public void HitFoxState(int leftFoxes, int shots)
        {
            _form.HitCell(leftFoxes, shots);
        }
        public void MissFoxState(int pelling, int shots)
        {
            _form.MissFoxs(pelling, shots);
        }
        public void HitFirstCellState(int shots)
        {
            _form.HitFirstCell(shots);
        }
        #endregion


        private frmGameInterface _form;
    }
}
