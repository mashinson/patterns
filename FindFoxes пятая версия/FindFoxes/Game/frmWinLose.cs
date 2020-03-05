using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFoxes
{
    public partial class frmWinLose : Form, CommonFormInterface
    {
    
        public frmWinLose(GameState state)
        {
            InitializeComponent();
            WinOrLose(state);
        }

        /// <summary>
        /// Go to menu
        /// </summary>
        private void btExitMenu_Click(object sender, EventArgs e)
        {
            Hide();
            Program.controller.RunForm(GameForms.Menu);
        }

        /// <summary>
        /// Run new Game
        /// </summary>
        private void btOK_Click(object sender, EventArgs e)
        {
            Hide();
            Program.controller.RunForm(GameForms.SetInfo);
        }

        /// <summary>
        /// Select by GameState what information display on form
        /// </summary>
        /// <param name="gs">state of game (lose or win game)</param>
        public void WinOrLose(GameState gs)
        {
            switch (gs)
            {               
                case GameState.Win:
                    pbFox.BackgroundImage = WinFox;
                    lblWinLose.Text = "Вы выграли!";
                    break;
                case GameState.Lose:
                    pbFox.BackgroundImage = LoseFox;
                    lblWinLose.Text = "Вы проиграли!";
                    break;
            }

        }

        private Image WinFox = new Bitmap("pictures/FoxWin.png");
        private Image LoseFox = new Bitmap("pictures/LoseFox.png");

    }
}
