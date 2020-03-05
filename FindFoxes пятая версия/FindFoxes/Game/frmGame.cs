using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindFoxes
{

    public partial class frmGame : Form, frmGameInterface
    {
        /// <summary>
        /// Set view
        /// </summary>
        /// <param name="view">View of this form</param>
        public frmGame()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pbReference, "Справка");
            toolTip1.SetToolTip(pbExit, "Выход в меню");
            toolTip1.SetToolTip(pbTime, "Сколько сталось времени");
            toolTip1.SetToolTip(pbCountFoxes, "Сколько лисичек прячутся");
            toolTip1.SetToolTip(pbCountAttemps, "Сколько осталось попыток");
            timer1.Interval = 1000;

        }

        /// <summary>
        /// Clean the plaing filed
        /// </summary>
        private void CleanButtons()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j].Click -= field_Click;
                    Controls.Remove(field[i, j]);
                    field[i, j].Dispose();
                }
            }
        }

        /// <summary>
        /// Set view
        /// </summary>
        /// <param name="view">Game view</param>
        public void SetView(GameView view)
        {
            _view = view;
        }

        /// <summary>
        /// Set playingfield ok form
        /// </summary>
        /// <param name="size">Size of the field</param>
        /// <param name="LeftFoxes">Sum of foxes</param>
        /// <param name="Shots">Count of shots</param>
        public void SetupGame(int size, int LeftFoxes, int Shots, Levels level)
        {
            if (field != null)
            {
                CleanButtons();
            }
            field = new MyButton[size, size];
            lblShots.Text = Convert.ToString(Shots);
            lblFoxes.Text = Convert.ToString(LeftFoxes);

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    MyButton newButton = new MyButton();
                    newButton.Location = new Point((j + 1) * 50, (i + 1) * 50);
                    newButton.Size = new Size(50, 50);
                    newButton.BackColor = Color.Azure;
                    newButton.PosX = i;
                    newButton.PosY = j;
                    newButton.Click += field_Click;
                    Controls.Add(newButton);
                    field[i, j] = newButton;
                }
            }
            field[0, 0].BackgroundImage = ninja;
            field[0, 0].BackgroundImageLayout = ImageLayout.Zoom;
            SetTime(size, level);
        }

        /// <summary>
        /// Set time depended on Game level and size of the field
        /// </summary>
        /// <param name="size">size of the field</param>
        /// <param name="level">Game level</param>
        private void SetTime(int size, Levels level)
        {
            switch (level)
            {
                case Levels.Easy:
                    time = new TimeSpan(0, size * 3 / 2, 0);
                    break;
                case Levels.Medium:
                    time = new TimeSpan(0, size, 0);
                    break;
                case Levels.Hard:
                    time = new TimeSpan(0, size / 2, 0);
                    break;
                case Levels.Training:
                    time = new TimeSpan(0, size * 4, 0);
                    break;
            }
        }


        /// <summary>
        /// I user click on of the buttons on playingfield 
        /// </summary>
        private void field_Click(object sender, EventArgs e)
        {
            timer1.Start();
            MyButton btnSender = sender as MyButton;
            if (btnSender != null)
            {
                lastPoint.X = btnSender.PosX;
                lastPoint.Y = btnSender.PosY;
                field[lastPoint.X, lastPoint.Y].Enabled = false;
                _view.ShotsFired(btnSender.PosX, btnSender.PosY);
            }
        }

        /// <summary>
        ///X, Y of last point
        /// </summary>
        public Point LastPoint
        {
            get
            {
                return lastPoint;
            }

        }


        /// <summary>
        /// If player win/lose teh game
        /// </summary>
        /// <param name="state"></param>
        public void WinLose(GameState state)
        {
            time = new TimeSpan(0, 0, 0);
            Hide();
            switch (state)
            {
                case GameState.Win:
                    Program.controller.RunForm(GameForms.Win);
                    break;
                case GameState.Lose:
                    Program.controller.RunForm(GameForms.Lose);
                    break;
            }

        }


        /// <summary>
        /// If user have found fox
        /// </summary>
        /// <param name="leftFoxs">sum of foxes that aren`t found</param>
        /// <param name="shots">sum of left shots</param>
        public void HitCell(int leftFoxs, int shots)
        {
            field[LastPoint.X, LastPoint.Y].BackgroundImage = fox;
            //field[LastPoint.X, LastPoint.Y].BackgroundImage = hedgehog;
            field[LastPoint.X, LastPoint.Y].BackgroundImageLayout = ImageLayout.Zoom;
            lblShots.Text = Convert.ToString(shots);
            lblFoxes.Text = Convert.ToString(leftFoxs);
        }


        /// <summary>
        /// If user haven`t find fox
        /// </summary>
        /// <param name="pelling">sum of foxes on pelling</param>
        /// <param name="shots">sum of left shots</param>
        public void MissFoxs(int pelling, int shots)
        {
            field[LastPoint.X, LastPoint.Y].Text = Convert.ToString(pelling);
            lblShots.Text = Convert.ToString(shots);
        }


        /// <summary>
        /// If player shot in first cell
        /// </summary>
        /// <param name="shots"></param>
        public void HitFirstCell(int shots)
        {
            MessageBox.Show("Здесь находитесь ВЫ. Введите другую клеточку");
        }

        /// <summary>
        /// Go to menu
        /// </summary>
        private void pbExit_Click(object sender, EventArgs e)
        {
            AskExit();
        }

        /// <summary>
        /// Ask if player really want not to finish game
        /// </summary>
        private void AskExit()
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Вы точно хотите выйти из игры?", "Выход", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                Hide();
                Program.controller.RunForm(GameForms.Menu);
            }
        }

        /// <summary>
        /// Go to reference and don`t close the game
        /// </summary>
        private void pbReference_Click(object sender, EventArgs e)
        {
            Program.controller.RunForm(GameForms.Reference);
        }


        /// <summary>
        /// Timer
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            time = time.Subtract(new TimeSpan(0, 0, 1));
            if (time == new TimeSpan(0, 0, 0))
            {
                timer1.Stop();
                Hide();
                Program.controller.RunForm(GameForms.Lose);
            }
            else
            {
                lblTime.Text = time.ToString();

            }

        }

        /// <summary>
        /// View of this form
        /// </summary>
       private GameView _view;

        /// <summary>
        /// Playing field on form
        /// </summary>
        private MyButton[,] field;

        private Image fox = new Bitmap("pictures/fox4.png");
        private Image ninja = new Bitmap("pictures/ninja.png");
        private Image hedgehog = new Bitmap("pictures/ежик.png");

        /// <summary>
        /// time of the game
        /// </summary>
        private TimeSpan time;
        private  Point lastPoint;
    }
}
