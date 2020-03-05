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
    public partial class frmMenu : Form, CommonFormInterface
    {
      
        public frmMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Exit Application
        /// </summary>
        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Show Form Reference
        /// </summary>
        private void btReference_Click(object sender, EventArgs e)
        {
            Program.controller.RunForm(GameForms.Reference);
        }
        /// <summary>
        /// Start Game
        /// </summary>
        private void btTimeGame_Click(object sender, EventArgs e)
        {
            Hide();
            Program.controller.RunForm(GameForms.SetInfo);

        }


    }
}
