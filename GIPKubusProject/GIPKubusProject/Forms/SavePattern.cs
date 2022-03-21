using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIPKubusProject
{
    
    public partial class SavePattern : Form
    {
        DatabaseMethods databaseMethods = new DatabaseMethods();
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
        public SavePattern(string pattern, string name)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            lblPat.Text = pattern;
            lblPat.Hide();
            lblName.Text = name;
            lblName.Hide();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            DatabaseMethods.DatabaseActions("INSERT INTO tblPatterns(Pattern, Username, Name) VALUES('" + lblPat.Text + "', '"+ lblName.Text +"', '"+ txtPatternName.Text +"')");
            this.Hide();
        }
    }
}
