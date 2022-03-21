namespace GIPKubusProject
{
    partial class Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.Drag = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.patternsDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.patternsDataSet = new GIPKubusProject.Connecties.PatternsDataSet();
            this.LblAccountNaam = new System.Windows.Forms.Label();
            this.btnUsername = new System.Windows.Forms.Button();
            this.lblCreate = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.chkRememberCreate = new System.Windows.Forms.CheckBox();
            this.txtPassword = new Layout.TextboxCus();
            this.txtPasswordCreate = new Layout.TextboxCus();
            this.txtUsernameCreate = new Layout.TextboxCus();
            this.txtUsername = new Layout.TextboxCus();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Drag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternsDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternsDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.Drag.Size = new System.Drawing.Size(539, 25);
            this.Drag.TabIndex = 88;
            this.Drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseD_Event);
            this.Drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseM_Event);
            this.Drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseU_Event);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(140, 0);
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
            this.panel3.Location = new System.Drawing.Point(496, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 25);
            this.panel3.TabIndex = 0;
            this.panel3.Click += new System.EventHandler(this.Exit);
            // 
            // patternsDataSetBindingSource
            // 
            this.patternsDataSetBindingSource.DataSource = this.patternsDataSet;
            this.patternsDataSetBindingSource.Position = 0;
            // 
            // patternsDataSet
            // 
            this.patternsDataSet.DataSetName = "PatternsDataSet";
            this.patternsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblAccountNaam
            // 
            this.LblAccountNaam.AutoSize = true;
            this.LblAccountNaam.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAccountNaam.Location = new System.Drawing.Point(149, 45);
            this.LblAccountNaam.Name = "LblAccountNaam";
            this.LblAccountNaam.Size = new System.Drawing.Size(66, 33);
            this.LblAccountNaam.TabIndex = 92;
            this.LblAccountNaam.Text = "Log in";
            // 
            // btnUsername
            // 
            this.btnUsername.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsername.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnUsername.Location = new System.Drawing.Point(136, 216);
            this.btnUsername.Name = "btnUsername";
            this.btnUsername.Size = new System.Drawing.Size(98, 23);
            this.btnUsername.TabIndex = 93;
            this.btnUsername.Text = "Enter";
            this.btnUsername.UseVisualStyleBackColor = false;
            this.btnUsername.Click += new System.EventHandler(this.btnUsername_Click);
            // 
            // lblCreate
            // 
            this.lblCreate.AutoSize = true;
            this.lblCreate.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreate.Location = new System.Drawing.Point(81, 340);
            this.lblCreate.Name = "lblCreate";
            this.lblCreate.Size = new System.Drawing.Size(204, 33);
            this.lblCreate.TabIndex = 95;
            this.lblCreate.Text = "Create a new account";
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAccount.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnCreateAccount.Location = new System.Drawing.Point(136, 504);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(98, 23);
            this.btnCreateAccount.TabIndex = 96;
            this.btnCreateAccount.Text = "Create account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // lbUsers
            // 
            this.lbUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.lbUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsers.Font = new System.Drawing.Font("Bahnschrift Condensed", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsers.ForeColor = System.Drawing.Color.White;
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.ItemHeight = 29;
            this.lbUsers.Location = new System.Drawing.Point(0, 0);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(192, 545);
            this.lbUsers.TabIndex = 98;
            this.lbUsers.Click += new System.EventHandler(this.FillTextbox);
            this.lbUsers.DoubleClick += new System.EventHandler(this.Logindirect);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.lbUsers);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(347, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 545);
            this.panel1.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(146, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 100;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(148, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 101;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(148, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 18);
            this.label3.TabIndex = 103;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(148, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 102;
            this.label4.Text = "Username";
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.Location = new System.Drawing.Point(123, 245);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(125, 17);
            this.chkRemember.TabIndex = 104;
            this.chkRemember.Text = "Remember password";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // chkRememberCreate
            // 
            this.chkRememberCreate.AutoSize = true;
            this.chkRememberCreate.Location = new System.Drawing.Point(123, 533);
            this.chkRememberCreate.Name = "chkRememberCreate";
            this.chkRememberCreate.Size = new System.Drawing.Size(125, 17);
            this.chkRememberCreate.TabIndex = 105;
            this.chkRememberCreate.Text = "Remember password";
            this.chkRememberCreate.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(57, 170);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(258, 40);
            this.txtPassword.TabIndex = 92;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login);
            // 
            // txtPasswordCreate
            // 
            this.txtPasswordCreate.BackColor = System.Drawing.Color.White;
            this.txtPasswordCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordCreate.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordCreate.Location = new System.Drawing.Point(57, 458);
            this.txtPasswordCreate.Name = "txtPasswordCreate";
            this.txtPasswordCreate.Size = new System.Drawing.Size(258, 40);
            this.txtPasswordCreate.TabIndex = 95;
            this.txtPasswordCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPasswordCreate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateAccount);
            // 
            // txtUsernameCreate
            // 
            this.txtUsernameCreate.BackColor = System.Drawing.Color.White;
            this.txtUsernameCreate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsernameCreate.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsernameCreate.Location = new System.Drawing.Point(57, 394);
            this.txtUsernameCreate.Name = "txtUsernameCreate";
            this.txtUsernameCreate.Size = new System.Drawing.Size(258, 40);
            this.txtUsernameCreate.TabIndex = 94;
            this.txtUsernameCreate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsernameCreate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateAccount);
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(57, 106);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(258, 40);
            this.txtUsername.TabIndex = 91;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtUsername.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 278);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 570);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chkRememberCreate);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtPasswordCreate);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.lblCreate);
            this.Controls.Add(this.txtUsernameCreate);
            this.Controls.Add(this.btnUsername);
            this.Controls.Add(this.LblAccountNaam);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.Drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Account";
            this.Text = "Patterns";
            this.Drag.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternsDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternsDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Drag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource patternsDataSetBindingSource;
        private Connecties.PatternsDataSet patternsDataSet;
        private Layout.TextboxCus txtUsername;
        private System.Windows.Forms.Label LblAccountNaam;
        private System.Windows.Forms.Button btnUsername;
        private System.Windows.Forms.Label lblCreate;
        private Layout.TextboxCus txtUsernameCreate;
        private System.Windows.Forms.Button btnCreateAccount;
        private Layout.TextboxCus txtPasswordCreate;
        private Layout.TextboxCus txtPassword;
        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.CheckBox chkRememberCreate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}