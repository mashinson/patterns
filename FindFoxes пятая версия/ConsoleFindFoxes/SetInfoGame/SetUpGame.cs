using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindFoxes;
namespace ConsoleFindFoxes
{
    public class SetUpGame : frmSetGameInterface
    {
        const int MIN_SIZE_FIELD = 2;
        const int MAX_SIZE_FIELD = 10;

        public void SetView(SetGameView view)
        {
            _view = view;
        }

        public void Show()
        {
            GameSetUp();
        }


        public void GameSetUp()
        {
            ChooseLevelOfTheGame();
            ChooseSizeofTheOlayingField();
            Console.Clear();

            _view.sizeUpdated(size, lev);
            Program.controller.RunForm(GameForms.Game);
        }

        /// <summary>
        /// Choose size of the field in the game
        /// </summary>
        private void ChooseSizeofTheOlayingField()
        {
            bool ch = true;
            bool bl = true;
            string s = "";

            while (ch)
            {
                s = "";
                Console.Clear();
                Console.Write("Введите размер таблички (не меньше 2 и не больше 10): ");
                Console.WriteLine();
                s = Console.ReadLine();
                bl = Int32.TryParse(s, out size);
                if (bl == false || size < MIN_SIZE_FIELD || size > MAX_SIZE_FIELD)
                {
                    Console.Clear();
                    Console.WriteLine("Введите правильный размер табличики!!!");
                    Console.ReadLine();
                }
                else
                {
                    ch = false;
                }
            }
           
        }

        /// <summary>
        /// Choose level of the Game
        /// </summary>
        private void ChooseLevelOfTheGame()
        {
            bool ch = true;
            bool bl = true;
            string s = "";
            int level = 0;
            while (ch)
            {
                Console.Clear();
                Console.Write("Введите номер уровня игры: Тренировка(1), Легкий(2), Средний(3), Сложный(4)");               
                Console.WriteLine();
                s = Console.ReadLine();
                bl = Int32.TryParse(s, out level);
                if (bl == false || level < 1 || level > 4)
                {
                    Console.Clear();
                    Console.WriteLine("Введите номер уровня игры !!!");
                    Console.ReadLine();
                }
                else
                {
                    ch = false;
                    switch (level)
                    {
                        case 1:
                            lev = Levels.Training;
                            break;
                        case 2:
                            lev = Levels.Easy;
                            break;
                        case 3:
                            lev = Levels.Medium;
                            break;
                        case 4:
                            lev = Levels.Hard;
                            break;
                    }
                }

            }
        }

        private Levels lev = Levels.Easy;
        private int size = 0;
        private SetGameView _view;
     
    }
}
