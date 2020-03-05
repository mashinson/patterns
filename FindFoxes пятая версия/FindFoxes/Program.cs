using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFoxes
{
    static class Program
    {
        static public ApplicationController controller;
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            controller = new ApplicationController();
            GameModel gm = new GameModel();
            controller.Add(GameForms.Menu, new CommonPresenter(new frmMenu()));
            controller.Add(GameForms.Reference, new CommonPresenter(new frmReference()));
            controller.Add(GameForms.Win, new CommonPresenter(new frmWinLose(GameState.Win)));
            controller.Add(GameForms.Lose, new CommonPresenter(new frmWinLose(GameState.Lose)));
            controller.Add(GameForms.SetInfo, new SetGamePresenter(new SetGameView(new frmSetLevelGame()), gm));
            controller.Add(GameForms.Game, new GamePresenter(new GameView(new frmGame()), gm));

            controller.RunForm(GameForms.Menu);
            Application.Run();



        }

    }
}

