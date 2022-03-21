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

namespace GIPKubusProject
{
    public partial class ConnectieInformatie : Form
    {
        readonly CubieBotConnectie connectie1, connectie2;

        public ConnectieInformatie(CubieBotConnectie con1, CubieBotConnectie con2)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            txtBoxCon1.BackColor = Color.FromArgb(76, 75, 105);
            txtBoxCon2.BackColor = Color.FromArgb(76, 75, 105);
            lblUitleg.BackColor = Color.FromArgb(76, 75, 105);
            txtBoxCon1.TabStop = false;
            txtBoxCon2.TabStop = false;
            lblUitleg.TabStop = false;
            lblUitleg.Text = "Check if connection 1 has the lowest portname. If it does not. Then click on the button 'Swap Connections'. This will swap the connections.";

            connectie1 = con1;
            connectie2 = con2;

            FixData();
        }

        //Eigen Methodes || Geen layout
        private void FixData()
        {
            if (connectie1 != null)
            {
                txtBoxCon1.Text = 
               ReplaceNieuweLijn(
               $"Name: {connectie1.Naam} \nPortname: {connectie1.COM}\nBaudrate: {connectie1.SerialPort.BaudRate}");
            }
            else
            {
                txtBoxCon1.Text = "Not Connected";
                txtBoxCon1.ForeColor = Color.Red;
            }

            if (connectie2 != null)
            {
                txtBoxCon2.Text =
               ReplaceNieuweLijn(
               $"Name: {connectie2.Naam} \nPortname: {connectie2.COM}\nBaudrate: {connectie2.SerialPort.BaudRate}");
            }
            else
            {
                txtBoxCon2.Text = "Not Connected";
                txtBoxCon2.ForeColor = Color.Red;
            }
        }


        private string ReplaceNieuweLijn(string needToRerplace )
        {
            return needToRerplace.Replace("\n", Environment.NewLine);
        }

        //Layout
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

        private void BtnOkey_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}
