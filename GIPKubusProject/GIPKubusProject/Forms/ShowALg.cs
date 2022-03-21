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

namespace GIPKubusProject
{
    public partial class ShowAlg : Form
    {
        public ShowAlg(string algorithm)
        {
            InitializeComponent();
            string strAlgorithm = $"{Environment.NewLine}" + algorithm;
            //string[] algorithmArr = algorithm.ToArray();

            //foreach (var item in algorithmArr)
            //{
            //    strAlgorithm += algorithmArr[x].ToString() + " ";
            //    x++;
            //}


            lblAlg.Text += strAlgorithm;



            this.FormBorderStyle = FormBorderStyle.None;

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
            this.Close();
        }
    }
}
