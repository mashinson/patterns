using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFoxes
{
    /// <summary>
    /// Interface for  Game form 
    /// </summary>
    public interface frmGameInterface
    {
        void SetView(GameView view);
        void SetupGame(int size, int leftFoxes, int Shots, Levels level);
        void Show();
        void WinLose(GameState state);
        void HitCell(int leftFoxes, int shots);
        void MissFoxs(int pelling, int shots);
        void HitFirstCell(int shots);
    }
}
