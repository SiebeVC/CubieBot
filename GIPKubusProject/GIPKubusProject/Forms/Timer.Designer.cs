namespace GIPKubusProject.Forms
{
    partial class Timer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Timer));
            this.Drag = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.starttimeruser = new System.Windows.Forms.Timer(this.components);
            this.lbltimeruser = new System.Windows.Forms.Label();
            this.lbSolves = new System.Windows.Forms.ListBox();
            this.btnTimerUser = new System.Windows.Forms.Button();
            this.lblScrambleTimer = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Drag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Drag
            // 
            this.Drag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.Drag.Controls.Add(this.pictureBox2);
            this.Drag.Controls.Add(this.panel3);
            this.Drag.Dock = System.Windows.Forms.DockStyle.Top;
            this.Drag.Location = new System.Drawing.Point(0, 0);
            this.Drag.Name = "Drag";
            this.Drag.Size = new System.Drawing.Size(511, 25);
            this.Drag.TabIndex = 89;
            this.Drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.Drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.Drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(139, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(468, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 25);
            this.panel3.TabIndex = 0;
            this.panel3.Click += new System.EventHandler(this.Exit_Click);
            // 
            // starttimeruser
            // 
            this.starttimeruser.Interval = 10;
            this.starttimeruser.Tick += new System.EventHandler(this.starttimeruser_Tick);
            // 
            // lbltimeruser
            // 
            this.lbltimeruser.AutoSize = true;
            this.lbltimeruser.BackColor = System.Drawing.Color.Transparent;
            this.lbltimeruser.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimeruser.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbltimeruser.Location = new System.Drawing.Point(95, 102);
            this.lbltimeruser.Name = "lbltimeruser";
            this.lbltimeruser.Size = new System.Drawing.Size(118, 55);
            this.lbltimeruser.TabIndex = 101;
            this.lbltimeruser.Text = "0.00";
            this.lbltimeruser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbSolves
            // 
            this.lbSolves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.lbSolves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSolves.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbSolves.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolves.ForeColor = System.Drawing.Color.White;
            this.lbSolves.FormattingEnabled = true;
            this.lbSolves.ItemHeight = 29;
            this.lbSolves.Location = new System.Drawing.Point(332, 25);
            this.lbSolves.Name = "lbSolves";
            this.lbSolves.Size = new System.Drawing.Size(179, 265);
            this.lbSolves.TabIndex = 103;
            // 
            // btnTimerUser
            // 
            this.btnTimerUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(80)))));
            this.btnTimerUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTimerUser.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.btnTimerUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimerUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTimerUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimerUser.Location = new System.Drawing.Point(0, 241);
            this.btnTimerUser.Name = "btnTimerUser";
            this.btnTimerUser.Size = new System.Drawing.Size(332, 49);
            this.btnTimerUser.TabIndex = 104;
            this.btnTimerUser.Text = "Start";
            this.btnTimerUser.UseVisualStyleBackColor = false;
            this.btnTimerUser.Click += new System.EventHandler(this.StartTimer);
            // 
            // lblScrambleTimer
            // 
            this.lblScrambleTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScrambleTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScrambleTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblScrambleTimer.Location = new System.Drawing.Point(0, 0);
            this.lblScrambleTimer.Name = "lblScrambleTimer";
            this.lblScrambleTimer.Size = new System.Drawing.Size(332, 38);
            this.lblScrambleTimer.TabIndex = 105;
            this.lblScrambleTimer.Text = "label1";
            this.lblScrambleTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblScrambleTimer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 38);
            this.panel1.TabIndex = 106;
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(511, 290);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTimerUser);
            this.Controls.Add(this.lbSolves);
            this.Controls.Add(this.lbltimeruser);
            this.Controls.Add(this.Drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Timer";
            this.Text = "Timer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartTimer);
            this.Drag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Drag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Timer starttimeruser;
        private System.Windows.Forms.Label lbltimeruser;
        private System.Windows.Forms.ListBox lbSolves;
        private System.Windows.Forms.Button btnTimerUser;
        private System.Windows.Forms.Label lblScrambleTimer;
        private System.Windows.Forms.Panel panel1;
    }
}