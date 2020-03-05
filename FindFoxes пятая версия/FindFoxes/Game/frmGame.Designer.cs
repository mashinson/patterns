namespace FindFoxes
{
    partial class frmGame
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGame));
            this.pnButtonSpace = new System.Windows.Forms.Panel();
            this.pbTime = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.pbCountFoxes = new System.Windows.Forms.PictureBox();
            this.pbCountAttemps = new System.Windows.Forms.PictureBox();
            this.lblFoxes = new System.Windows.Forms.Label();
            this.lblShots = new System.Windows.Forms.Label();
            this.pbReference = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountFoxes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountAttemps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pnButtonSpace
            // 
            this.pnButtonSpace.Location = new System.Drawing.Point(33, 70);
            this.pnButtonSpace.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pnButtonSpace.Name = "pnButtonSpace";
            this.pnButtonSpace.Size = new System.Drawing.Size(458, 484);
            this.pnButtonSpace.TabIndex = 2;
            this.pnButtonSpace.Visible = false;
            // 
            // pbTime
            // 
            this.pbTime.BackColor = System.Drawing.Color.Transparent;
            this.pbTime.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbTime.BackgroundImage")));
            this.pbTime.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbTime.Location = new System.Drawing.Point(559, 84);
            this.pbTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbTime.Name = "pbTime";
            this.pbTime.Size = new System.Drawing.Size(111, 103);
            this.pbTime.TabIndex = 5;
            this.pbTime.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(562, 190);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(36, 39);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "_";
            // 
            // pbCountFoxes
            // 
            this.pbCountFoxes.BackColor = System.Drawing.Color.Transparent;
            this.pbCountFoxes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCountFoxes.BackgroundImage")));
            this.pbCountFoxes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCountFoxes.Location = new System.Drawing.Point(559, 245);
            this.pbCountFoxes.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbCountFoxes.Name = "pbCountFoxes";
            this.pbCountFoxes.Size = new System.Drawing.Size(111, 113);
            this.pbCountFoxes.TabIndex = 8;
            this.pbCountFoxes.TabStop = false;
            // 
            // pbCountAttemps
            // 
            this.pbCountAttemps.BackColor = System.Drawing.Color.Transparent;
            this.pbCountAttemps.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbCountAttemps.BackgroundImage")));
            this.pbCountAttemps.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbCountAttemps.Location = new System.Drawing.Point(567, 415);
            this.pbCountAttemps.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbCountAttemps.Name = "pbCountAttemps";
            this.pbCountAttemps.Size = new System.Drawing.Size(95, 90);
            this.pbCountAttemps.TabIndex = 9;
            this.pbCountAttemps.TabStop = false;
            // 
            // lblFoxes
            // 
            this.lblFoxes.AutoSize = true;
            this.lblFoxes.BackColor = System.Drawing.Color.Transparent;
            this.lblFoxes.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFoxes.Location = new System.Drawing.Point(596, 360);
            this.lblFoxes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFoxes.Name = "lblFoxes";
            this.lblFoxes.Size = new System.Drawing.Size(36, 39);
            this.lblFoxes.TabIndex = 10;
            this.lblFoxes.Text = "_";
            // 
            // lblShots
            // 
            this.lblShots.AutoSize = true;
            this.lblShots.BackColor = System.Drawing.Color.Transparent;
            this.lblShots.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblShots.Location = new System.Drawing.Point(596, 508);
            this.lblShots.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShots.Name = "lblShots";
            this.lblShots.Size = new System.Drawing.Size(36, 39);
            this.lblShots.TabIndex = 11;
            this.lblShots.Text = "_";
            // 
            // pbReference
            // 
            this.pbReference.BackColor = System.Drawing.Color.Transparent;
            this.pbReference.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbReference.BackgroundImage")));
            this.pbReference.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbReference.Location = new System.Drawing.Point(683, 1);
            this.pbReference.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbReference.Name = "pbReference";
            this.pbReference.Size = new System.Drawing.Size(118, 114);
            this.pbReference.TabIndex = 12;
            this.pbReference.TabStop = false;
            this.pbReference.Click += new System.EventHandler(this.pbReference_Click);
            // 
            // pbExit
            // 
            this.pbExit.BackColor = System.Drawing.Color.Transparent;
            this.pbExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbExit.BackgroundImage")));
            this.pbExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbExit.Location = new System.Drawing.Point(702, 506);
            this.pbExit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(99, 100);
            this.pbExit.TabIndex = 13;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SpringGreen;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 618);
            this.ControlBox = false;
            this.Controls.Add(this.pbExit);
            this.Controls.Add(this.pbReference);
            this.Controls.Add(this.lblShots);
            this.Controls.Add(this.lblFoxes);
            this.Controls.Add(this.pbCountAttemps);
            this.Controls.Add(this.pbCountFoxes);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pbTime);
            this.Controls.Add(this.pnButtonSpace);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountFoxes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCountAttemps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnButtonSpace;
        private System.Windows.Forms.PictureBox pbTime;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.PictureBox pbCountFoxes;
        private System.Windows.Forms.PictureBox pbCountAttemps;
        private System.Windows.Forms.Label lblFoxes;
        private System.Windows.Forms.Label lblShots;
        private System.Windows.Forms.PictureBox pbReference;
        private System.Windows.Forms.PictureBox pbExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
    }
}

