using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIPKubusProject.ArduinoConnecties;
using GIPKubusProject.DBModels;
using System.IO.Ports;
using System.Threading;
using GIPKubusProject.csFiles;
using System.ComponentModel.Design;

namespace GIPKubusProject.Forms
{
    public partial class Timer : Form
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

        string tussentijd = "0";
        DateTime startSolve;
        readonly Kubus kubus = new Kubus();
        string strScramble = "";
        
        public Timer()
        {
            
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            lblScrambleTimer.Text = MakeScramble();
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

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartTimer(object sender, EventArgs e)
        {
            if (btnTimerUser.Text == "Start")
            {
                startSolve = DateTime.Now;
                starttimeruser.Start();
                btnTimerUser.Text = "Stop";
                lblScrambleTimer.Text = "";
            }
            else
            {
                starttimeruser.Stop();
                btnTimerUser.Text = "Start";
                lbSolves.Items.Add(tussentijd);
                lblScrambleTimer.Text = MakeScramble();
            }
            
        }

        private void starttimeruser_Tick(object sender, EventArgs e)
        {
            tussentijd = Math.Round((DateTime.Now - startSolve).TotalSeconds, 2).ToString();
            lbltimeruser.Text = tussentijd.ToString();
        }


        private string MakeScramble()
        {
            strScramble = "";
            foreach (int getal in kubus.ScrambleGenerator(15))
            {
                switch (getal)
                {
                    case 2:
                        strScramble += "U' ";
                        break;
                    case 3:
                        strScramble += "D ";
                        break;
                    case 4:
                        strScramble += "D' ";
                        break;
                    case 5:
                        strScramble += "F ";
                        break;
                    case 6:
                        strScramble += "F' ";
                        break;
                    case 7:
                        strScramble += "B ";
                        break;
                    case 8:
                        strScramble += "B' ";
                        break;
                    case 9:
                        strScramble += "L ";
                        break;
                    case 10:
                        strScramble += "L' ";
                        break;
                    case 11:
                        strScramble += "R ";
                        break;
                    case 12:
                        strScramble += "R' ";
                        break;
                    default: //1
                        strScramble += "U ";
                        break;
                }
            }
            return strScramble;
        }
    }
}
