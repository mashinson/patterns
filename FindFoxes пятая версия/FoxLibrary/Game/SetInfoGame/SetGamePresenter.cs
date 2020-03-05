using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    public class SetGamePresenter: BasePresenter
    {

        public SetGamePresenter(SetGameView view, GameModel model)
        {
            _view = view;
            _model = model;
             //This event works when player has chosen size and level for game
            _view.SizeUpdateEvent += handleBeginEvent;
        }

        /// <summary>
        /// Send info about size and level to the GameModel
        /// </summary>
        public void handleBeginEvent(GameBeginEventArgs args)
        {
            _model.setField(args.Size, args.Level);
        }
        public void Run()
        {
            _view.Show();
        }

        private SetGameView _view;
        private GameModel _model;
    }
}
