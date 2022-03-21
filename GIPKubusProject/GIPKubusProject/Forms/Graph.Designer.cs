namespace GIPKubusProject
{
    partial class Graph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Drag = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.chrtOverall = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblAvOverall = new System.Windows.Forms.Label();
            this.lblMinOverall = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chrtTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMinNow = new System.Windows.Forms.Label();
            this.lblAvNow = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.lblMaxNow = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Drag.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtOverall)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtTime)).BeginInit();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // Drag
            // 
            this.Drag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.Drag.Controls.Add(this.panel1);
            this.Drag.Controls.Add(this.pictureBox2);
            this.Drag.Controls.Add(this.panel3);
            this.Drag.Dock = System.Windows.Forms.DockStyle.Top;
            this.Drag.Location = new System.Drawing.Point(0, 0);
            this.Drag.Name = "Drag";
            this.Drag.Size = new System.Drawing.Size(1143, 25);
            this.Drag.TabIndex = 89;
            this.Drag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseD_Event);
            this.Drag.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseM_Event);
            this.Drag.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseU_Event);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 25);
            this.panel1.TabIndex = 96;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseD_Event);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseM_Event);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseU_Event);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(527, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 33);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 97;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseD_Event);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseM_Event);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseU_Event);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(170, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 33);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 88;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseD_Event);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseM_Event);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseU_Event);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1100, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(43, 25);
            this.panel3.TabIndex = 0;
            this.panel3.Click += new System.EventHandler(this.Exit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(254, 376);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 33);
            this.label1.TabIndex = 94;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(789, 673);
            this.panel2.TabIndex = 96;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.chrtOverall);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(789, 336);
            this.panel7.TabIndex = 105;
            // 
            // chrtOverall
            // 
            chartArea1.Name = "ChartArea1";
            this.chrtOverall.ChartAreas.Add(chartArea1);
            this.chrtOverall.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chrtOverall.Legends.Add(legend1);
            this.chrtOverall.Location = new System.Drawing.Point(0, 41);
            this.chrtOverall.Name = "chrtOverall";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Time";
            this.chrtOverall.Series.Add(series1);
            this.chrtOverall.Size = new System.Drawing.Size(789, 295);
            this.chrtOverall.TabIndex = 96;
            this.chrtOverall.Text = "chart1";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel13);
            this.panel9.Controls.Add(this.panel12);
            this.panel9.Controls.Add(this.panel11);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(788, 25);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(355, 673);
            this.panel9.TabIndex = 97;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(80)))));
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.label3);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(355, 41);
            this.panel10.TabIndex = 105;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(493, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "OVERALL";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.lblMinOverall);
            this.panel11.Controls.Add(this.lblAvOverall);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel11.Location = new System.Drawing.Point(0, 41);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(355, 295);
            this.panel11.TabIndex = 106;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(80)))));
            this.panel12.Controls.Add(this.label2);
            this.panel12.Controls.Add(this.label4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 336);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(355, 41);
            this.panel12.TabIndex = 107;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(515, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 103;
            this.label4.Text = "NOW";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel13.Location = new System.Drawing.Point(0, 377);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(355, 296);
            this.panel13.TabIndex = 107;
            // 
            // lblAvOverall
            // 
            this.lblAvOverall.AutoSize = true;
            this.lblAvOverall.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvOverall.Location = new System.Drawing.Point(7, 3);
            this.lblAvOverall.Name = "lblAvOverall";
            this.lblAvOverall.Size = new System.Drawing.Size(67, 18);
            this.lblAvOverall.TabIndex = 101;
            this.lblAvOverall.Text = "Average:";
            // 
            // lblMinOverall
            // 
            this.lblMinOverall.AutoSize = true;
            this.lblMinOverall.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinOverall.Location = new System.Drawing.Point(7, 31);
            this.lblMinOverall.Name = "lblMinOverall";
            this.lblMinOverall.Size = new System.Drawing.Size(35, 18);
            this.lblMinOverall.TabIndex = 102;
            this.lblMinOverall.Text = "Min:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 18);
            this.label8.TabIndex = 103;
            this.label8.Text = "Max:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(131, 11);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 102;
            this.label6.Text = "OVERALL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(155, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "NOW";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chrtTime);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 377);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(789, 296);
            this.panel4.TabIndex = 96;
            // 
            // chrtTime
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtTime.ChartAreas.Add(chartArea2);
            this.chrtTime.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrtTime.Legends.Add(legend2);
            this.chrtTime.Location = new System.Drawing.Point(0, 0);
            this.chrtTime.Name = "chrtTime";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.Name = "Time";
            this.chrtTime.Series.Add(series2);
            this.chrtTime.Size = new System.Drawing.Size(789, 296);
            this.chrtTime.TabIndex = 90;
            this.chrtTime.Text = "chart1";
            // 
            // lblMinNow
            // 
            this.lblMinNow.AutoSize = true;
            this.lblMinNow.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinNow.Location = new System.Drawing.Point(7, 31);
            this.lblMinNow.Name = "lblMinNow";
            this.lblMinNow.Size = new System.Drawing.Size(35, 18);
            this.lblMinNow.TabIndex = 102;
            this.lblMinNow.Text = "Min:";
            // 
            // lblAvNow
            // 
            this.lblAvNow.AutoSize = true;
            this.lblAvNow.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvNow.Location = new System.Drawing.Point(7, 3);
            this.lblAvNow.Name = "lblAvNow";
            this.lblAvNow.Size = new System.Drawing.Size(67, 18);
            this.lblAvNow.TabIndex = 101;
            this.lblAvNow.Text = "Average:";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel14.Controls.Add(this.lblMaxNow);
            this.panel14.Controls.Add(this.lblMinNow);
            this.panel14.Controls.Add(this.lblAvNow);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(355, 295);
            this.panel14.TabIndex = 107;
            // 
            // lblMaxNow
            // 
            this.lblMaxNow.AutoSize = true;
            this.lblMaxNow.Font = new System.Drawing.Font("Bahnschrift SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxNow.Location = new System.Drawing.Point(7, 60);
            this.lblMaxNow.Name = "lblMaxNow";
            this.lblMaxNow.Size = new System.Drawing.Size(39, 18);
            this.lblMaxNow.TabIndex = 103;
            this.lblMaxNow.Text = "Max:";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 336);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(789, 41);
            this.panel5.TabIndex = 97;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1143, 698);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Drag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Graph";
            this.Text = "Graph";
            this.Drag.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtOverall)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chrtTime)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Drag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtOverall;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblMinOverall;
        private System.Windows.Forms.Label lblAvOverall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtTime;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Label lblMaxNow;
        private System.Windows.Forms.Label lblMinNow;
        private System.Windows.Forms.Label lblAvNow;
    }
}