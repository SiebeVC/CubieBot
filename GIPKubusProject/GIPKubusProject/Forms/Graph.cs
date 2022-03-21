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
using GIPKubusProject.DBModels;

namespace GIPKubusProject
{
    public partial class Graph : Form
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

        public Graph(double[] times, User user)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            ToevoegenChart(times, 0);

            List<double> tms = new List<double>();
            foreach (var item in user.Solves)
            {
                tms.Add(item.Tijd);
            }

            if (tms.Count > 0)
            {

                double get = 0;
                int x = 0;
                for (int i = 0; i < tms.Count(); i++)
                {
                    get += int.Parse(tms[x].ToString());
                    x++;
                }

                get /= tms.Count();
                get = Math.Round(get, 2);

                label8.Text += " " + tms.Max().ToString() + " Sec";
                lblMinOverall.Text += " " + tms.Min().ToString() + " Sec";
                lblAvOverall.Text += " " + get.ToString() + " Sec";

                ToevoegenChart(tms.ToArray(), 1);
            }
            else
            {
                ToonError("No solves found", false);
            }
        }

        bool mousedown;
        private Point offset;
        private void MouseU_Event(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void MouseM_Event(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }

        private void MouseD_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void ToevoegenChart(double[] times, int a)
        {
            int x = 0;
            if (a == 0)
            {
                double totaal = 0;
                for (int i = 0; i < times.Count(); i++)
                {
                    chrtTime.Series["Time"].Points.AddXY("", times[x]);
                    totaal += times[x];
                    x++;
                }

                if (times.Count() != 0)
                {
                    totaal /= times.Count();

                    lblMaxNow.Text += " " + times.Max();
                    lblMinNow.Text += " " + times.Min();
                    lblAvNow.Text += " " + totaal;
                }

            }
            if (a == 1)
            {
                for (int i = 0; i < times.Count(); i++)
                {
                    chrtOverall.Series["Time"].Points.AddXY("", times[x]);
                    x++;
                }
            }

        }

        private void ToonError(string error, bool isError = true)
        {
            Errorbox er = new Errorbox(error, isError);
            er.Show();
        }
    }
}
