using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;

namespace GIPKubusProject
{
    public partial class Solves : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Solves(string username)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            string[] waardes = DatabaseMethods.DatabaseRead("select Scramble, TM from [tblSolves] where Username = '" + username + "'");

            //lijstaanvullen
            for (int i = 0; i < waardes.Length; i += 2)
            {
                lbSolves.Items.Add("       " + waardes[i-1].Replace("P", "'") + "       " + waardes[i].ToString() + " Sec");
            }
        }


        bool mousedown;
        private Point offset;
        private void mouseU_Event(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void mouseM_Event(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void mouseD_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Hide(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SelectScramble(object sender, EventArgs e)
        {
            
            
        }
    }
}
