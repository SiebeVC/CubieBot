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
    public partial class Account : Form
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

        public Account()
        {
            InitializeComponent();
            BackColor = Color.Snow;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            txtPassword.PasswordChar = '•';
            txtPasswordCreate.PasswordChar = '•';

            string SQL = "select (Username) from [tblAccount]";
            string[] waardes = DatabaseMethods.DatabaseRead(SQL);

            foreach (var item in waardes)
            {
                lbUsers.Items.Add(item);
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
            this.Hide();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPasswordCreate.Text) || !String.IsNullOrWhiteSpace(txtUsernameCreate.Text))
            {
                lbUsers.Items.Add(txtUsernameCreate.Text);

                string SQl = "INSERT INTO tblAccount (Username, PW, LoginLocked) VALUES('" + txtUsernameCreate.Text + "', '" + txtPasswordCreate.Text + "', " + chkRememberCreate.Checked + ")";
                byte i = (byte)DatabaseMethods.DatabaseActions(SQl);

                //Controle
                if (i == 1)
                {
                    ToonError("Your account '" + txtUsernameCreate.Text + "' has been created.", false);
                    txtUsernameCreate.Text = "";
                    txtPasswordCreate.Text = "";
                }
                else
                {
                    ToonError("An error occured while creating your account");
                }
            }
            else
            {
                ToonError("Please enter a Username and a password first.");
            }
        }

        private void btnUsername_Click(object sender, EventArgs e)
        {
            //D
            bool flag = false;
            string[] waardes;

            //Ophalen van waardes
            waardes = DatabaseMethods.DatabaseRead("select [Username],[PW],[LoginLocked] from [tblAccount] WHERE Username = '" + txtUsername.Text + "';");

            //Controle ofdat wachtwoord hetzelfde is

            if (waardes.Length > 0)
            {
                if (waardes[0] == txtUsername.Text && waardes[1] == txtPassword.Text)
                {
                    flag = true;
                }
            }

            //Controle ofdat check moet veranderd worden
            if (flag == true)
            {
                if (bool.Parse(waardes[2]) != chkRemember.Checked)
                {
                    DatabaseMethods.DatabaseActions("UPDATE tblAccount SET LoginLocked = " + chkRemember.Checked + " WHERE Username = '" + txtUsername.Text + "';");
                }
                this.Hide();

                KubusSolverForm kubusSolverForm = new KubusSolverForm(txtUsername.Text);

                kubusSolverForm.Show();
            }
            else
            {
                string[] namen = DatabaseMethods.DatabaseRead("Select Username FROM tblAccount;");
                string[] wwVanNaam = DatabaseMethods.DatabaseRead("Select PW FROM tblAccount WHERE Username = '" + txtUsername.Text + "';");
                bool wwJuist;
                bool naamJuist = wwJuist = false;

                //controle op naam
                foreach (var item in namen)
                {
                    if (item == txtUsername.Text)
                    {
                        naamJuist = true;
                        break;
                    }
                    else
                        naamJuist = false;
                }

                //controle op wachtwoord
                if (naamJuist)
                {
                    if (wwVanNaam.Length > 0)
                    {
                        if (txtPassword.Text == wwVanNaam[0])
                        {
                            wwJuist = true;
                        }
                        else
                        {
                            wwJuist = false;
                        }
                    }
                }

                if (!naamJuist)
                {
                    ToonError("Username not found");
                }
                else if (naamJuist && !wwJuist)
                {
                    ToonError("Password is not correct");
                }
                //ToonError("Unable to login to your account");
            }
        }

        private void Login(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtUsername.Focused == true)
                {
                    txtPassword.Focus();
                }
                else
                {
                    btnUsername.PerformClick();
                }
            }
        }

        private void CreateAccount(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (txtUsernameCreate.Focused == true)
                {
                    txtPasswordCreate.Focus();
                }
                else
                {
                    btnCreateAccount.PerformClick();
                }
            }
        }

        private void FillTextbox(object sender, EventArgs e)
        {
            Fill();
        }

        private void Logindirect(object sender, EventArgs e)
        {
            Fill();
            btnUsername.PerformClick();
        }

        private void Fill()
        {
            if (lbUsers.SelectedItem != null)
            {
                //D
                txtUsername.Text = "";
                txtPassword.Text = "";
                string user = lbUsers.SelectedItem.ToString();

                //Ophalen van gegevens
                string[] waardes = DatabaseMethods.DatabaseRead("select [Username],[PW],[LoginLocked] from [tblAccount] where Username = '" + user + "'");

                txtUsername.Text = waardes[0];
                chkRemember.Checked = bool.Parse(waardes[2]);

                //Controle ofdat wachtwoord moet worden opgeslagen
                if (chkRemember.Checked)
                {
                    txtPassword.Text = waardes[1];
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
