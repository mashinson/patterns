using System.IO;
using FindFoxes;

namespace ConsoleFindFoxes
{
    class Program
    {

        public static string strMenu = "";
        public static string strWin = "";
        public static string strReference = "";
        public static string strExit = "";
        public static FindFoxes.ApplicationController controller;

        static void Main(string[] args)
        {
            strMenu = loadResources("MenuFox.txt");
            strWin = loadResources("Win.txt");
            strReference = loadResources("Reference.txt");
            strExit = loadResources("ExitGame.txt");

            controller = new ApplicationController();
            GameModel gm = new GameModel();
            controller.Add(GameForms.Menu, new CommonPresenter(new ProgramMenuControl(strMenu, new ProgramMenu(), new MenuForm())));
            controller.Add(GameForms.Reference, new CommonPresenter(new ReferenceProgram(strReference)));
            controller.Add(GameForms.SetInfo, new SetGamePresenter(new SetGameView(new SetUpGame()), gm));
            controller.Add(GameForms.Game, new GamePresenter(new GameView(new GameProgramControl(strExit)), gm));
            controller.Add(GameForms.Win, new CommonPresenter(new WinLoseGame(strWin, GameState.Win)));
            controller.Add(GameForms.Lose, new CommonPresenter(new WinLoseGame(strWin, GameState.Lose)));

            Program.controller.RunForm(GameForms.Menu);
        }

        /// <summary>
        /// Load different files
        /// </summary>
        /// <param name="fileName">name of file and it's path</param>
        /// <returns>a string s that contains information from a file</returns>
        public static string loadResources(string fileName)
        {
            string s = "";
            StreamReader reader = new StreamReader(fileName);
            try
            {
                do
                {
                    s += reader.ReadLine() + "\n";
                }
                while (reader.Peek() != -1);
            }

            catch
            {
                s = "Error!";
            }

            finally
            {
                reader.Close();
            }
            return s;
        }


    }
}
