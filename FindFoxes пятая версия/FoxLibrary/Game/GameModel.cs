using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    public class GameModel
    {
        #region Events
        //This event works when the playField is Initialized, also in GamePresenter on this event 
        //signed the method handleGameCreatedEvent
        public event UpdateInfo<GameBeginEventArgs> PlayingFieldCreatedEvent;

        //This event works when player lose/win game, in GamePresenter on this event 
        //signed the method handleModelWinLoseUpdateEvent
        public event UpdateInfo<GameModelUpdateEventArgs> WinLoseGameEvent;

        //This event works when player has found a fox, in GamePresenter on this event 
        //signed the method handleModelHitFoxUpdateEvent
        public event UpdateInfo<GameModelUpdateEventArgs> HitFoxEvent;

        //This event works when player hasn`t found a fox, in GamePresenter on this event 
        //signed the method handleModelMissFoxUpdateEvent
        public event UpdateInfo<GameModelUpdateEventArgs> MissFoxEvent;

        //This event works when player hot in the first cell, in GamePresenter on this event 
        //signed the method handleModelHitFirstStateUpdateEvent
        public event UpdateInfo<GameModelUpdateEventArgs> HitFirstCellEvent;
        #endregion

        /// <summary>
        ///  SetGamePresenter send info about size and level of the game to the PlayingFiled(logic of game),
        ///  also this method called PlayingFieldCreatedEvent on which in GamePresenter signed handleGameCreatedEvent
        /// </summary>
        /// <param name="size">size of playingfild that the player has chosen</param>
        /// <param name="level">level of game that the player has chosen</param>
        public void setField(int size, Levels level)
        {
            _gameField = new PlayingField(size, this, level);
            PlayingFieldCreatedEvent(new GameBeginEventArgs(_gameField.FieldSize, _gameField.Data.leftFoxes, _gameField.Data.shots, _gameField.Level));
        }

        /// <summary>
        /// info from GamePresenter about coordinates of the selected cell sends PlayingField
        /// </summary>
        /// </summary>
        /// <param name="x">Coordinate of the selected cell horizontally</param>
        /// <param name="y">Coordinate of the selected cell vertically</param>
        public void updateField(int x, int y)
        {
            _gameField.EnterFox(x, y);
        }

        /// <summary>
        /// These method called from logic of game, As an answer to his shot at cell of playingfiled
        /// </summary>
        #region InfoOfGame
        public void WinLoseGame(GameData data)
        {
            WinLoseGameEvent(new GameModelUpdateEventArgs(data));
        }
        public void HitFox(GameData data)
        {
            HitFoxEvent(new GameModelUpdateEventArgs(data));
        }
        public void MissFox(GameData data)
        {
            MissFoxEvent(new GameModelUpdateEventArgs(data));
        }
        public void HitFirstCell(GameData data)
        {
            HitFirstCellEvent(new GameModelUpdateEventArgs(data));
        }
        #endregion

        private PlayingField _gameField; //logic of the game;
    }
}

