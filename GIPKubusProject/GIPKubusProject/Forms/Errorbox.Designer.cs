namespace GIPKubusProject
{
    partial class Errorbox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Errorbox));
            this.Drag = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOkey = new System.Windows.Forms.Button();
            this.Drag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.Drag.Size = new System.Drawing.Size(451, 25);
            this.Drag.TabIndex = 90;
            this.Drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.Drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.Drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(100, 0);
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
            this.panel3.Location = new System.Drawing.Point(408, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 25);
            this.panel3.TabIndex = 0;
            this.panel3.Click += new System.EventHandler(this.Exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 23);
            this.label1.TabIndex = 91;
            this.label1.Text = "ERROR: ";
            // 
            // btnOkey
            // 
            this.btnOkey.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOkey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnOkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOkey.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnOkey.Location = new System.Drawing.Point(343, 67);
            this.btnOkey.Name = "btnOkey";
            this.btnOkey.Size = new System.Drawing.Size(98, 23);
            this.btnOkey.TabIndex = 95;
            this.btnOkey.Text = "Ok";
            this.btnOkey.UseVisualStyleBackColor = false;
            this.btnOkey.Click += new System.EventHandler(this.BtnOkey_Click);
            // 
            // Errorbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 98);
            this.Controls.Add(this.btnOkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Errorbox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Errorbox";
            this.Drag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Drag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOkey;
    }
}