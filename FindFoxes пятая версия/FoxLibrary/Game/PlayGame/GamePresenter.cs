using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    public class GamePresenter : BasePresenter
    {
        public GamePresenter(GameView view, GameModel model)
        {
            _model = model;
            _view = view;
            subscribeHandlers();
        }

        /// <summary>
        /// methods are signed on different events
        /// </summary>
        public void subscribeHandlers()
        {
            //This event works when player has made a shoot
            _view.FoxShotEvent += handleCurrentEvent;

            //This event works when the playField is Initialized
            _model.PlayingFieldCreatedEvent += handleGameCreatedEvent;

            //This event works when player lose/win game
            _model.WinLoseGameEvent += handleModelWinLoseUpdateEvent;
            //This event works when player has found a fox
            _model.HitFoxEvent += handleModelHitFoxUpdateEvent;
            //This event works when player hasn`t found a fox
            _model.MissFoxEvent += handleModelMissFoxUpdateEvent;
            //This event works when player hot in the first cell
            _model.HitFirstCellEvent += handleModelHitFirstStateUpdateEvent;
        }

        /// <summary>
        /// Model sends info for setting playing field on game from, signed on PlayingFieldCreatedEvent
        /// </summary>
        /// <param name="args">GameBeginEventArgs</param>
        private void handleGameCreatedEvent(GameBeginEventArgs args)
        {
            _view.createField(args.Size, args.LeftFoxes, args.Shots, args.Level);
        }

        /// <summary>
        /// View sends info to model about coordinates of the selected cell 
        /// </summary>
        /// <param name="args">GameCurrentEventArgs</param>
        private void handleCurrentEvent(GameCurrentEventArgs args)
        {
            _model.updateField(args.X, args.Y);
        }
        

        /// Model send info to view, what to dispaly depending on whether 
        /// in the selected cells were foxes or player win/lose game, hit first cell
        #region InfoToView
        private void handleModelWinLoseUpdateEvent(GameModelUpdateEventArgs args)
        {
            _view.WinLoseState(args.State);
        }

        private void handleModelHitFoxUpdateEvent(GameModelUpdateEventArgs args)
        {
            _view.HitFoxState(args.LeftFoxes, args.Shots);

        }

        private void handleModelMissFoxUpdateEvent(GameModelUpdateEventArgs args)
        {
            _view.MissFoxState(args.Pelling, args.Shots);
        }

        private void handleModelHitFirstStateUpdateEvent(GameModelUpdateEventArgs args)
        {
            _view.HitFirstCellState(args.Shots);
        }
        #endregion 

        public void Run()
        {
            _view.Show();
        }


        private GameModel _model;
        private GameView _view;
    }
}

