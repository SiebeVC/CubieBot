using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xpbar
{
    public partial class Form1 : Form
    {
        int levelcounter = 0;
        double snelheid = 30;
        public Form1()
        {
            InitializeComponent();
            
            label1.Text = "Level: " + levelcounter;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                xpbar.Width = xpbar.Width + (int)snelheid;
                if (xpbar.Width > panel1.Width)
                {
                    xpbar.Width = 0;
                    label1.Text = "Level: "+levelcounter++.ToString();
                    snelheid = Math.Pow(snelheid, 1.01);
                }
            }
        }
    }
}
