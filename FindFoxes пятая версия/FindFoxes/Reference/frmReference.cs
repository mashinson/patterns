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
    public partial class frmReference : Form, CommonFormInterface
    {
        public frmReference()
        {
            InitializeComponent();
            webBrowser1.Navigate(path + "/Manual.html");
        }
        /// <summary>
        /// If form is closed by user, hide it
        /// </summary>
        private void frmReference_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }            
        }

        /// <summary>
        /// Depending on node in treeView show different web-pages (Manual to game and rules of)
        /// </summary>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            name = treeView1.SelectedNode.Name;
            if (name == "Manual")
            {
                webBrowser1.Navigate(path + "/Manual.html");
            }
            if (name == "GameRules")
            {
                webBrowser1.Navigate(path + "/Rules.html");
            }
        }
        private string path = Application.StartupPath;
        private string name;
    }
}
