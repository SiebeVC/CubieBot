namespace GIPKubusProject
{
    partial class SavePattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavePattern));
            this.Drag = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatternName = new Layout.TextboxCus();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblPat = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.Drag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Drag
            // 
            this.Drag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.Drag.Controls.Add(this.pictureBox2);
            this.Drag.Dock = System.Windows.Forms.DockStyle.Top;
            this.Drag.Location = new System.Drawing.Point(0, 0);
            this.Drag.Name = "Drag";
            this.Drag.Size = new System.Drawing.Size(325, 25);
            this.Drag.TabIndex = 89;
            this.Drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.Drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.Drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(35, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(135, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 102;
            this.label1.Text = "Name";
            // 
            // txtPatternName
            // 
            this.txtPatternName.BackColor = System.Drawing.Color.White;
            this.txtPatternName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPatternName.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatternName.Location = new System.Drawing.Point(30, 68);
            this.txtPatternName.Name = "txtPatternName";
            this.txtPatternName.Size = new System.Drawing.Size(258, 40);
            this.txtPatternName.TabIndex = 101;
            this.txtPatternName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnSave.Location = new System.Drawing.Point(110, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "Enter";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblPat
            // 
            this.lblPat.AutoSize = true;
            this.lblPat.Location = new System.Drawing.Point(135, 143);
            this.lblPat.Name = "lblPat";
            this.lblPat.Size = new System.Drawing.Size(35, 13);
            this.lblPat.TabIndex = 104;
            this.lblPat.Text = "label2";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(94, 143);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 105;
            this.lblName.Text = "label3";
            // 
            // SavePattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 165);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPat);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatternName);
            this.Controls.Add(this.Drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SavePattern";
            this.Text = "SavePattern";
            this.Drag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Drag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private Layout.TextboxCus txtPatternName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblPat;
        private System.Windows.Forms.Label lblName;
    }
}