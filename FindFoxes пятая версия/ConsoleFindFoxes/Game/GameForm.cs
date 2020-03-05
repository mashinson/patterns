using System;
using FindFoxes;


namespace ConsoleFindFoxes
{
   public class GameForm
    {
        public const int START_ROW = 3;
        private int _sizeOfTable;

        public GameForm(int Size)
        {
            _sizeOfTable = Size;
        }

        /// <summary>
        /// Move cursor by table depending of UserAction 
        /// </summary>
        /// <param name="cursorX">target cell coordinate by horizontals</param>
        /// <param name="cursorY">target cell coordinate in the vertical</param>
        public void CursorPosition(int cursorX, int cursorY)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2 - _sizeOfTable * 2) + 2 + 4 * cursorX, START_ROW + cursorY * 2);
        }

        /// <summary>
        /// Formula сonverts ordinary coordinates in view coordinates
        /// </summary>
        /// <param name="row">target cell coordinate by horizontals</param>
        /// <param name="column">target cell coordinate in the vertical</param>
        private void SetTableCursorPosition(int row, int column)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2 - _sizeOfTable * 2) + 1 + 4 * column, START_ROW + row * 2);
        }

        /// <summary>
        /// Draw a table 
        /// </summary>
        /// <param name="tb">Program table</param>
        public void DrawField(string[,] findFoxes)
        {
            //Console.ResetColor();
            int currentRow = START_ROW; // line which is drawn now

            //С помощью метода SetCursorPosition указывается, где должна начаться следующая операция записи в окно консоли.
            //Если заданная позиция курсора находится вне области, которая в данный момент видима в окне консоли, начало координат этого окна автоматически изменяется, чтобы курсор стал видимым.
            Console.SetCursorPosition(Console.WindowWidth / 2 - _sizeOfTable * 2, currentRow - 1);

            //Draw the "zero" line by horizontals
            for (int k = 0; k < _sizeOfTable; k++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            //Draw table
            for (int i = 0; i < _sizeOfTable; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - _sizeOfTable * 2, currentRow);
                currentRow++;

                // Draw the edge of the table in the vertical
                Console.Write("|");
                for (int j = 0; j < _sizeOfTable; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(findFoxes[j, i]);
                   
                    Console.ResetColor();
                    Console.Write("|");

                }

                Console.SetCursorPosition(Console.WindowWidth / 2 - _sizeOfTable * 2, currentRow);
                currentRow++;

                //Draw the edge of the table by horizontals
                for (int k = 0; k < _sizeOfTable; k++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");

            }
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// View the peeling of the point
        /// </summary>
        /// <param name="targetRow">target cell coordinate by horizontals</param>
        /// <param name="targetColumn">target cell coordinate in the vertical</param>
        public void Peleng( string[,] findFoxes, int CursorY, int CursorX)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < _sizeOfTable; i++)
            {
                SetTableCursorPosition(CursorX, i);
                Console.Write(findFoxes[i, CursorX]);              

            }

            for (int i = 0; i < _sizeOfTable; i++)
            {
                SetTableCursorPosition(i, CursorY);
                Console.Write(findFoxes[CursorY, i]);             
            }

            Console.BackgroundColor = ConsoleColor.Red;
            SetTableCursorPosition(CursorX, CursorY);
            Console.Write(findFoxes[CursorY, CursorX]);
       

            Console.ResetColor();
        }

       


    }
}
