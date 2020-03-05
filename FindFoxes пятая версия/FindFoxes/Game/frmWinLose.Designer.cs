namespace FindFoxes
{
    partial class frmWinLose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWinLose));
            this.btOK = new System.Windows.Forms.Button();
            this.btExitMenu = new System.Windows.Forms.Button();
            this.lblWinLose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbFox)).BeginInit();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btOK.BackgroundImage")));
            this.btOK.Location = new System.Drawing.Point(4, 207);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(130, 39);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "Да";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btExitMenu
            // 
            this.btExitMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btExitMenu.BackgroundImage")));
            this.btExitMenu.Location = new System.Drawing.Point(328, 212);
            this.btExitMenu.Name = "btExitMenu";
            this.btExitMenu.Size = new System.Drawing.Size(130, 39);
            this.btExitMenu.TabIndex = 1;
            this.btExitMenu.Text = "Нет";
            this.btExitMenu.UseVisualStyleBackColor = true;
            this.btExitMenu.Click += new System.EventHandler(this.btExitMenu_Click);
            // 
            // lblWinLose
            // 
            this.lblWinLose.AutoSize = true;
            this.lblWinLose.BackColor = System.Drawing.Color.Transparent;
            this.lblWinLose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWinLose.Location = new System.Drawing.Point(121, 37);
            this.lblWinLose.Name = "lblWinLose";
            this.lblWinLose.Size = new System.Drawing.Size(29, 31);
            this.lblWinLose.TabIndex = 2;
            this.lblWinLose.Text = "_";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(66, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Вы хотите начать новую игру?";
            // 
            // pbFox
            // 
            this.pbFox.BackColor = System.Drawing.Color.Transparent;
            this.pbFox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFox.Location = new System.Drawing.Point(336, 280);
            this.pbFox.Name = "pbFox";
            this.pbFox.Size = new System.Drawing.Size(152, 127);
            this.pbFox.TabIndex = 4;
            this.pbFox.TabStop = false;
            // 
            // frmWinLose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(472, 407);
            this.ControlBox = false;
            this.Controls.Add(this.pbFox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWinLose);
            this.Controls.Add(this.btExitMenu);
            this.Controls.Add(this.btOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmWinLose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbFox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btExitMenu;
        private System.Windows.Forms.Label lblWinLose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbFox;
    }
}