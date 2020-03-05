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
  
    public partial class frmSetLevelGame : Form, frmSetGameInterface
    {
        const int MIN_SIZE_FIELD = 2;
        const int MAX_SIZE_FIELD = 10;

     
        public frmSetLevelGame()
        {
            InitializeComponent();

        }

        public void SetView(SetGameView view)
        {
            _view = view;
        }

        /// <summary>
        /// Choose size of the field
        /// </summary>
        private bool AskSize()
        {
            bool ch = true;
            string input = "";
            input = txtSize.Text;
            bool bl = Int32.TryParse(input, out size);
            if (bl == false || size > MAX_SIZE_FIELD || size < MIN_SIZE_FIELD)
            {
                MessageBox.Show("Введите значение поля от 2 до 10");
                ch = false;
            }
            return ch;
        }

        /// <summary>
        /// Go to the Game if everything is OK
        /// </summary>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (AskSize())
            {
               
                _view.sizeUpdated(size, lev);
                Hide();
                gbSetSize.Visible = false;
                Program.controller.RunForm(GameForms.Game);
            }
          
        }

        #region Choose level of the game 

        private void pctHardLight_Click(object sender, EventArgs e)
        {
            lev = Levels.Hard;
            gbSetSize.Visible = true;
            pctGoNext.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            lev = Levels.Easy;
            gbSetSize.Visible = true;
            pctGoNextNoLight.Visible = true;
        }

        private void pctTraining_Click(object sender, EventArgs e)
        {
            lev = Levels.Training;
            gbSetSize.Visible = true;
            pctGoNextNoLight.Visible = true;

        }

        private void pctMedium_Click(object sender, EventArgs e)
        {
            lev = Levels.Medium;
            gbSetSize.Visible = true;
            pctGoNextNoLight.Visible = true;
        }
        #endregion


        #region ChooseLevelMouseEnter/MouseLeave

        private void pctHardLihgt_MouseLeave(object sender, EventArgs e)
        {
            pctHard.Visible = true;
            pctHardLight.Visible = false;
        }

        private void pctHardLihgt_MouseEnter(object sender, EventArgs e)
        {
            pctHard.Visible = false;
            pctHardLight.Visible = true;
        }

        private void pctMedium_MouseLeave(object sender, EventArgs e)
        {
            pctMediumNoLight.Visible = true;
            pctMedium.Visible = false;
        }

        private void pctMedium_MouseEnter(object sender, EventArgs e)
        {
            pctMediumNoLight.Visible = false;
            pctMedium.Visible = true;
        }

        private void pctEasy_MouseLeave(object sender, EventArgs e)
        {
            pctEasyNoLight.Visible = true;
            pctEasy.Visible = false;
        }

        private void pctEasy_MouseEnter(object sender, EventArgs e)
        {
            pctEasyNoLight.Visible = false;
            pctEasy.Visible = true;
        }

        private void pctTraining_MouseLeave(object sender, EventArgs e)
        {
            pctTrainingNoLight.Visible = true;
            pctTraining.Visible = false;
        }

        private void pctTraining_MouseEnter(object sender, EventArgs e)
        {
            pctTrainingNoLight.Visible = false;
            pctTraining.Visible = true;
        }

        private void pctGoNext_MouseLeave(object sender, EventArgs e)
        {
            pctGoNextNoLight.Visible = true;
            pctGoNext.Visible = false;
        }

        private void pctGoNext_MouseEnter(object sender, EventArgs e)
        {
            pctGoNextNoLight.Visible = false;
            pctGoNext.Visible = true;
        }

        #endregion 

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar < 58 && e.KeyChar > 47) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private Levels lev = Levels.Easy;
        private int size = 0;
        private SetGameView _view;

    }
}

