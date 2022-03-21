using GIPKubusProject.ArduinoConnecties;
using GIPKubusProject.DBModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GIPKubusProject.csFiles;
using System.ComponentModel.Design;

namespace GIPKubusProject
{
    public partial class KubusSolverForm : System.Windows.Forms.Form
    {
        //Al de declaraties ↓ 
        #region Declaraties

        //Accounts & Xp systeem
        readonly User user = new User();

        readonly Kubus kubus = new Kubus();
        List<Koppel> lstKoppels = new List<Koppel>();


        int aantalMoves = 0;
        //Blauw, Groen, Wit, Geel, Rood, Oranje
        readonly byte[] kleurCountAr = { 0, 0, 0, 0, 0, 0 };
        string strScramble = "Scramble: ";
        readonly List<double> Time = new List<double>();



        //Arrays voor het selecteren van het verwijderen

        #endregion


        //Methodes die te maken hebben met het afsluiten en opstarten van de form
        #region Afhandelen opstarten en afsuiten

        public KubusSolverForm(string name)
        {
            InitializeComponent();

            // Juiste User gebruiken
            // + Controlleren ofdat er een account is da het laatst is aangemeld
            if (!string.IsNullOrWhiteSpace(name))
                user = new User(name);
            else
                ToonAccountScherm();

            //XPBar juist krijgen
            XpAanpassen();




            //this.MinimumSize = new Size(1650, 850);
            this.Text = "CubieBot";
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            btnBack.Enabled = true;
            menuIcon.Visible = false;

            lblUser.Text = "Username: " + user.Username;
            lblLevel.Text = "Level: " + user.Level;
            deletePattern2.Hide();
            deleteScramble1.Hide();

            if (!checkCubieBotConnect.Checked)
            {
                btnRunOnCubieBot.Enabled = false;
            }
        }

        /// <summary>
        /// Wanneer de form afsluit dan zal dit de poorten voor de zekerheid nog eens sluiten
        /// </summary>
        private void KubusSolverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Controle ofdat connectie 1 bestaat
            if (connectie1 != null)
            {
                connectie1.SerialPort.Close();
            }

            //Controle ofdat connectie 2 bestaat
            if (connectie2 != null)
            {
                connectie2.SerialPort.Close();
            }
        }

        public void KubusSolverForm_Load(object sender, EventArgs e)
        {
            ListMaker();

            Colorer(kubus.Blokjes);
            RefreshScramblesEnPatterns();
        }

        #endregion


        //Declaratie van al de blokjes 
        #region Blokjes + Lijst
        //(Dit is de volledige kubus)
        readonly Blokje GCorner1 = new Blokje("GCorner1", "FrontLeftUp", "FrontLeftUp"),
                GEdge2 = new Blokje("GEdge2", "FrontMiddleUp", "FrontMiddleUp"),
                GCorner3 = new Blokje("GCorner3", "FrontRightUp", "FrontRightUp"),
                GEdge4 = new Blokje("GEdge4", "FrontLeftMiddle", "FrontLeftMiddle"),
                GCenter = new Blokje("GCenter", "FrontPanel", "FrontPanel"),
                GEdge6 = new Blokje("GEdge6", "FrontRightMiddle", "FrontRightMiddle"),
                GCorner7 = new Blokje("GCorner7", "FrontLeftDown", "FrontLeftDown"),
                GEdge8 = new Blokje("GEdge8", "FrontMiddleDown", "FrontMiddleDown"),
                GCorner9 = new Blokje("GCorner9", "FrontRightDown", "FrontRightDown"),

                BCorner1 = new Blokje("BCorner1", "BackLeftUp", "BackLeftUp"),
                BEdge2 = new Blokje("BEdge2", "BackMiddleUp", "BackMiddleUp"),
                BCorner3 = new Blokje("BCorner3", "BackRightUp", "BackRightUp"),
                BEdge4 = new Blokje("BEdge4", "BackLeftMiddle", "BackLeftMiddle"),
                BCenter = new Blokje("BCenter", "BackPanel", "BackPanel"),
                BEdge6 = new Blokje("BEdge6", "BackRightMiddle", "BackRightMiddle"),
                BCorner7 = new Blokje("BCorner7", "BackLeftDown", "BackLeftDown"),
                BEdge8 = new Blokje("BEdge8", "BackMiddleDown", "BackMiddleDown"),
                BCorner9 = new Blokje("BCorner9", "BackRightDown", "BackRightDown"),

                WCorner1 = new Blokje("WCorner1", "UpLeftUp", "UpLeftUp"),
                WEdge2 = new Blokje("WEdge2", "UpMiddleUp", "UpMiddleUp"),
                WCorner3 = new Blokje("WCorner3", "UpRightUp", "UpRightUp"),
                WEdge4 = new Blokje("WEdge4", "UpLeftMiddle", "UpLeftMiddle"),
                WCenter = new Blokje("WCenter", "UpPanel", "UpPanel"),
                WEdge6 = new Blokje("WEdge6", "UpRightMiddle", "UpRightMiddle"),
                WCorner7 = new Blokje("WCorner7", "UpLeftDown", "UpLeftDown"),
                WEdge8 = new Blokje("WEdge8", "UpMiddleDown", "UpMiddleDown"),
                WCorner9 = new Blokje("WCorner9", "UpRightDown", "UpRightDown"),

                RCorner1 = new Blokje("RCorner1", "RightLeftUp", "RightLeftUp"),
                REdge2 = new Blokje("REdge2", "RightMiddleUp", "RightMiddleUp"),
                RCorner3 = new Blokje("RCorner3", "RightRightUp", "RightRightUp"),
                REdge4 = new Blokje("REdge4", "RightLeftMiddle", "RightLeftMiddle"),
                RCenter = new Blokje("RCenter", "RightPanel", "RightPanel"),
                REdge6 = new Blokje("REdge6", "RightRightMiddle", "RightRightMiddle"),
                RCorner7 = new Blokje("RCorner7", "RightLeftDown", "RightLeftDown"),
                REdge8 = new Blokje("REdge8", "RightMiddleDown", "RightMiddleDown"),
                RCorner9 = new Blokje("RCorner9", "RightRightDown", "RightRightDown"),

                YCorner1 = new Blokje("YCorner1", "DownLeftUp", "DownLeftUp"),
                YEdge2 = new Blokje("YEdge2", "DownMiddleUp", "DownMiddleUp"),
                YCorner3 = new Blokje("YCorner3", "DownRightUp", "DownRightUp"),
                YEdge4 = new Blokje("YEdge4", "DownLeftMiddle", "DownLeftMiddle"),
                YCenter = new Blokje("YCenter", "DownPanel", "DownPanel"),
                YEdge6 = new Blokje("YEdge6", "DownRightMiddle", "DownRightMiddle"),
                YCorner7 = new Blokje("YCorner7", "DownLeftDown", "DownLeftDown"),
                YEdge8 = new Blokje("YEdge8", "DownMiddleDown", "DownMiddleDown"),
                YCorner9 = new Blokje("YCorner9", "DownRightDown", "DownRightDown"),

                OCorner1 = new Blokje("OCorner1", "LeftLeftUp", "LeftLeftUp"),
                OEdge2 = new Blokje("OEdge2", "LeftMiddleUp", "LeftMiddleUp"),
                OCorner3 = new Blokje("OCorner3", "LeftRightUp", "LeftRightUp"),
                OEdge4 = new Blokje("OEdge4", "LeftLeftMiddle", "LeftLeftMiddle"),
                OCenter = new Blokje("OCenter", "LeftPanel", "LeftPanel"),
                OEdge6 = new Blokje("OEdge6", "LeftRightMiddle", "LeftRightMiddle"),
                OCorner7 = new Blokje("OCorner7", "LeftLeftDown", "LeftLeftDown"),
                OEdge8 = new Blokje("OEdge8", "LeftMiddleDown", "LeftMiddleDown"),
                OCorner9 = new Blokje("OCorner9", "LeftRightDown", "LeftRightDown");

        #endregion


        //Steekt al de blokjes in de lijst
        #region Lijst maker
        public void ListMaker()
        {
            kubus.Blokjes.Add(GCorner1);
            kubus.Blokjes.Add(GEdge2);
            kubus.Blokjes.Add(GCorner3);
            kubus.Blokjes.Add(GEdge4);
            kubus.Blokjes.Add(GCenter);
            kubus.Blokjes.Add(GEdge6);
            kubus.Blokjes.Add(GCorner7);
            kubus.Blokjes.Add(GEdge8);
            kubus.Blokjes.Add(GCorner9);
            kubus.Blokjes.Add(BCorner1);
            kubus.Blokjes.Add(BEdge2);
            kubus.Blokjes.Add(BCorner3);
            kubus.Blokjes.Add(BEdge4);
            kubus.Blokjes.Add(BCenter);
            kubus.Blokjes.Add(BEdge6);
            kubus.Blokjes.Add(BCorner7);
            kubus.Blokjes.Add(BEdge8);
            kubus.Blokjes.Add(BCorner9);
            kubus.Blokjes.Add(WCorner1);
            kubus.Blokjes.Add(WEdge2);
            kubus.Blokjes.Add(WCorner3);
            kubus.Blokjes.Add(WEdge4);
            kubus.Blokjes.Add(WCenter);
            kubus.Blokjes.Add(WEdge6);
            kubus.Blokjes.Add(WCorner7);
            kubus.Blokjes.Add(WEdge8);
            kubus.Blokjes.Add(WCorner9);
            kubus.Blokjes.Add(RCorner1);
            kubus.Blokjes.Add(REdge2);
            kubus.Blokjes.Add(RCorner3);
            kubus.Blokjes.Add(REdge4);
            kubus.Blokjes.Add(RCenter);
            kubus.Blokjes.Add(REdge6);
            kubus.Blokjes.Add(RCorner7);
            kubus.Blokjes.Add(REdge8);
            kubus.Blokjes.Add(RCorner9);
            kubus.Blokjes.Add(YCorner1);
            kubus.Blokjes.Add(YEdge2);
            kubus.Blokjes.Add(YCorner3);
            kubus.Blokjes.Add(YEdge4);
            kubus.Blokjes.Add(YCenter);
            kubus.Blokjes.Add(YEdge6);
            kubus.Blokjes.Add(YCorner7);
            kubus.Blokjes.Add(YEdge8);
            kubus.Blokjes.Add(YCorner9);
            kubus.Blokjes.Add(OCorner1);
            kubus.Blokjes.Add(OEdge2);
            kubus.Blokjes.Add(OCorner3);
            kubus.Blokjes.Add(OEdge4);
            kubus.Blokjes.Add(OCenter);
            kubus.Blokjes.Add(OEdge6);
            kubus.Blokjes.Add(OCorner7);
            kubus.Blokjes.Add(OEdge8);
            kubus.Blokjes.Add(OCorner9);

            foreach (var item in kubus.Blokjes)
            {
                lstKoppels = Koppel.Initial(lstKoppels, item.OorspronkelijkAdres, item.KleurBlokje);
            }
        }

        #endregion


        //Methodes in verband met het opslaan/ verwijderen/tonen van scrambles
        #region Scrambles en paterns

        //Al de methodes die te makan hebben met de Scrambles lijst
        #region Scrambles
        bool DeleteSelectedScramble = false;
        readonly List<Solve> lstTeVerwijderenSolves = new List<Solve>();

        private void DeleteScramble_Click(object sender, EventArgs e)
        {

            if (DeleteSelectedScramble == false)
            {
                DeleteSelectedScramble = true;
                deleteScramble.Hide();
                deleteScramble1.Show();
            }
            else
            {
                DeleteSelectedScramble = false;
                deleteScramble.Show();
                deleteScramble1.Hide();

                foreach (Solve item in lstTeVerwijderenSolves)
                {
                    DatabaseMethods.DatabaseActions("DELETE FROM tblSolves WHERE Id = " + item.Id + ";");
                }

                RefreshScramblesEnPatterns();
            }
        }

        private async void ExeScramble(object sender, EventArgs e)
        {
            try
            {
                if (lbScrambles.SelectedItem != null)
                {

                    if (DeleteSelectedScramble)
                    {
                        string scramble = lbScrambles.SelectedItem.ToString();
                        int index = scramble.IndexOf("Sec");
                        scramble = scramble.Substring(index + 4).Replace("'", "P");

                        Solve solf = user.Solves.Find(p => p.Scramble == scramble);

                        //Wanneer het item al in de lijst staat verwijder het dan uit de lijst
                        if (lstTeVerwijderenSolves.Find(s => solf != null && s.Id == solf.Id) == null)
                        {
                            lstTeVerwijderenSolves.Add(solf);
                        }
                        else
                        {
                            lstTeVerwijderenSolves.Remove(solf);
                        }
                    }
                    else
                    {
                        if (lbScrambles.SelectedItem != null)
                        {
                            //Resetten voor het uitvoeren van de scramble
                            ResetBlokjesCube();
                            ResetLayout();

                            string uitvoeren = lbScrambles.SelectedItem.ToString().Substring(7);
                            string[] arrstr = uitvoeren.Split(' ');

                            lblScramble.Text = "Scramble: " + uitvoeren.Substring(4);
                            await TinaTurner(arrstr);
                            ColorConfirmer();
                        }
                    }
                }
            }
            catch (Exception)
            {
                ToonError();
            }
        }

        #endregion

        //Al de methodes dat te maken hebben met paterns
        #region Paterns

        bool DeleteSelected = false;
        readonly List<Pattern> lstteVerwijderenPatterns = new List<Pattern>();

        /// <summary>
        /// Wanneer er op de "+" word geklikt
        /// </summary>
        private async void SavePatternPic_Click(object sender, EventArgs e)
        {
            SavePat();
            await UseDelay(200);
            RefreshScramblesEnPatterns();
        }

        /// <summary>
        /// Opslaan van een patroon
        /// </summary>
        public void SavePat()
        {
            string Pattern = "";

            List<Panel> panels = new List<Panel>() { FrontLeftUp, FrontMiddleUp, FrontRightUp, FrontLeftMiddle, FrontRightMiddle, FrontLeftDown, FrontMiddleDown, FrontRightDown, RightLeftUp, RightMiddleUp, RightRightUp, RightLeftMiddle, RightRightMiddle, RightLeftDown, RightMiddleDown, RightRightDown, LeftLeftUp, LeftMiddleUp, LeftRightUp, LeftLeftMiddle, LeftRightMiddle, LeftLeftDown, LeftMiddleDown, LeftRightDown, BackLeftUp, BackMiddleUp, BackRightUp, BackLeftMiddle, BackRightMiddle, BackLeftDown, BackMiddleDown, BackRightDown, UpLeftUp, UpMiddleUp, UpRightUp, UpLeftMiddle, UpRightMiddle, UpLeftDown, UpMiddleDown, UpRightDown, DownLeftUp, DownMiddleUp, DownRightUp, DownLeftMiddle, DownRightMiddle, DownLeftDown, DownMiddleDown, DownRightDown };


            foreach (var item in panels)
            {
                string color = item.BackColor.ToString();
                color = color.Replace("Color [", "").Replace("]", "");
                if (color == "A=255, R=240, G=78, B=0") { Pattern += "O "; }
                if (color == "A=255, R=33, G=96, B=112") { Pattern += "B "; }
                if (color == "White") { Pattern += "W "; }
                if (color == "A=255, R=173, G=19, B=19") { Pattern += "R "; }
                if (color == "Yellow") { Pattern += "Y "; }
                if (color == "A=255, R=11, G=238, B=50") { Pattern += "G "; }
            }

            SavePattern savePattern = new SavePattern(Pattern, user.Username);
            savePattern.Show();
        }

        /// <summary>
        /// Refresh paterns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowPattern_Click(object sender, EventArgs e)
        {
            RefreshScramblesEnPatterns();
        }

        private void DeletePattern_Click(object sender, EventArgs e)
        {
            if (DeleteSelected == false)
            {
                DeleteSelected = true;
                deletePattern.Hide();
                deletePattern2.Show();
            }
            else
            {
                DeleteSelected = false;
                deletePattern.Show();
                deletePattern2.Hide();

                foreach (Pattern item in lstteVerwijderenPatterns)
                {
                    DatabaseMethods.DatabaseActions("DELETE FROM tblPatterns WHERE Id = " + item.Id + ";");
                }

                RefreshScramblesEnPatterns();
            }
        }

        private void ShowPattern(object sender, EventArgs e)
        {
            if (DeleteSelected == true)
            {
                string patternNaam = lbShowPatterns.SelectedItem.ToString().Trim();

                Pattern pat = user.Patterns.Find(p => p.Naam == patternNaam);

                if (pat != null)
                {
                    if (lstteVerwijderenPatterns.Find(p => p.Id == pat.Id) == null)
                    {
                        lstteVerwijderenPatterns.Add(pat);
                    }
                    else
                    {
                        lstteVerwijderenPatterns.Remove(pat);
                    }
                }
            }
            else
            {
                try
                {
                    if (lbShowPatterns.SelectedItem != null)
                    {

                        List<Panel> panels = new List<Panel>() { FrontLeftUp, FrontMiddleUp, FrontRightUp, FrontLeftMiddle, FrontRightMiddle, FrontLeftDown, FrontMiddleDown, FrontRightDown, RightLeftUp, RightMiddleUp, RightRightUp, RightLeftMiddle, RightRightMiddle, RightLeftDown, RightMiddleDown, RightRightDown, LeftLeftUp, LeftMiddleUp, LeftRightUp, LeftLeftMiddle, LeftRightMiddle, LeftLeftDown, LeftMiddleDown, LeftRightDown, BackLeftUp, BackMiddleUp, BackRightUp, BackLeftMiddle, BackRightMiddle, BackLeftDown, BackMiddleDown, BackRightDown, UpLeftUp, UpMiddleUp, UpRightUp, UpLeftMiddle, UpRightMiddle, UpLeftDown, UpMiddleDown, UpRightDown, DownLeftUp, DownMiddleUp, DownRightUp, DownLeftMiddle, DownRightMiddle, DownLeftDown, DownMiddleDown, DownRightDown };

                        Pattern pattern = user.Patterns.Find(p => p.Naam == lbShowPatterns.SelectedItem.ToString().TrimStart());
                        string[] patArr = pattern.Patroon.Split(' ');

                        int y = 0;
                        foreach (var item in panels)
                        {
                            Color color = Color.White;

                            if (patArr[y] == "W") { color = Color.White; }
                            if (patArr[y] == "Y") { color = Color.Yellow; }
                            if (patArr[y] == "G") { color = Color.FromArgb(11, 238, 50); }
                            if (patArr[y] == "B") { color = Color.FromArgb(33, 96, 112); }
                            if (patArr[y] == "R") { color = Color.FromArgb(173, 19, 19); }
                            if (patArr[y] == "O") { color = Color.FromArgb(240, 78, 0); }

                            item.BackColor = color;
                            y++;

                            ColorConfirmer();
                        }
                    }
                }
                catch (Exception)
                {
                    ToonError();
                }
            }
        }

        #endregion

        //Hulp functies
        #region Over

        /// <summary>
        /// Refreshed de lijst met paterns & scrambles
        /// </summary>
        public void RefreshScramblesEnPatterns()
        {
            user.Patterns = Pattern.GetPatternsVanUser(user);
            user.Solves = Solve.GetSolvesVanUser(user);

            lbShowPatterns.Items.Clear();

            foreach (var item in user.Patterns)
            {
                lbShowPatterns.Items.Add("    " + item.Naam);
            }

            lbScrambles.Items.Clear();

            foreach (var item in user.Solves)
            {
                lbScrambles.Items.Add("    " + item.Tijd + " Sec" + " " + item.Scramble.Replace("P", "'"));
            }
        }

        #endregion

        #endregion


        //Methodes in verband met accounts
        #region Accounts

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            ToonAccountScherm();
        }

        private async void ToonAccountScherm()
        {
            Account ac = new Account();
            ac.Show();
            await UseDelay(50);
            this.Hide();
        }

        #endregion


        //Methodes in verband met grafieken
        #region Grafieken

        private void BtnGraph_Click(object sender, EventArgs e)
        {
            Graph graph = new Graph(Time.ToArray(), user);
            graph.Show();
        }

        #endregion


        //Regelen van de layout
        #region Layout
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


        private void MenuIcon_Click(object sender, EventArgs e)
        {
            panel5.Width = 365;
            panel4.Width = 229;
            menuIcon.Visible = false;
            closeIcon.Visible = true;
            this.Width = 1449;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            pictureBox2.Location = new Point(509, 0);
        }

        private void CloseIcon_Click(object sender, EventArgs e)
        {
            panel5.Width = 0;
            panel4.Width = 0;
            menuIcon.Visible = true;
            closeIcon.Visible = false;

            this.Width = 854;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            pictureBox2.Location = new Point(400, 0);
        }

        private void ChangeColour_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(44, 43, 60);
        }

        private void ChangeColour_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.FromArgb(44, 43, 65);
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

        private void Exit_Click(object sender, EventArgs e)
        {
            DatabaseMethods.DatabaseActions("UPDATE tblLast SET Username = '" + user.Username + "', LVL = '" + user.Level + "', Xp = '" + user.Experience + "';");

            Application.Exit();
        }

        #endregion


        //Lost de kubus op
        #region btnSolve_Click dit lost de rubik op
        Locking myLock = new Locking("Solver");
        private async void BtnSolve_ClickAsync(object sender, EventArgs e)
        {
            //Slot voor extra controle dat de methode niet te snal gaat
            //Maakt een nieuw slot aan met de naam Solver, die geen keyholder heeft en open is



            //resetten van vars
            aantalMoves = 0; //Zodat het moves count klopt
            arduinoMoveString = ""; //Zodat de CubieBot niet te veel moves doet
            txtAlgoritmeShow.Text = "";
            strUitvoeringCode.Clear();
            lblTijd.Text = "0,00";
            double tijdVoorInDb;
            Stappenuitvoeren.Clear();
            CollectionList.Clear();

            startSolve = DateTime.Now;
            Timer.Start();

            List<string> uitvoeren = new List<string>();


            //Hieronder vind je de methodes voor het kruis te maken

            for (byte stap = 1; stap <= 14; stap++)
            {
                do
                {
                    //Kruis
                    if (stap == 1)
                    {
                        myLock.Lock("MaakKruisGeelGroen");
                        uitvoeren = Algoritme.MaakKruisGeelGroen(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());

                        AddItemsToList(uitvoeren, true);

                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";

                        myLock.UnLock("MaakKruisGeelGroen");
                    }
                    else if (stap == 2)
                    {
                        myLock.Lock("MaakKruisGeelOranje");
                        uitvoeren = Algoritme.MaakKruisGeelOranje(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);


                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";

                        myLock.UnLock("MaakKruisGeelOranje");
                    }
                    else if (stap == 3)
                    {
                        myLock.Lock("MaakKruisGeelRood");
                        uitvoeren = Algoritme.MaakKruisGeelRood(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);

                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";

                        myLock.UnLock("MaakKruisGeelRood");
                    }
                    else if (stap == 4)
                    {
                        myLock.Lock("MaakKruisGeelBlauw");
                        uitvoeren = Algoritme.MaakKruisGeelBlauw(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());

                        AddItemsToList(uitvoeren, true);
                        uitvoeren.Clear();
                        uitvoeren = CollectionList;

                        AddItemsToList(uitvoeren);
                        CollectionList.Clear();


                        myLock.UnLock("MaakKruisGeelBlauw");
                    }
                    //Onderste vlak
                    else if (stap == 5)
                    {
                        uitvoeren.Clear();
                        if (FrontMiddleDown.BackColor != Color.FromArgb(11, 238, 50))
                        {
                            myLock.Lock("DOWN");

                            uitvoeren.Add("D");
                            await TinaTurner(uitvoeren.ToArray());
                            myLock.UnLock("DOWN");
                        }

                        if (FrontMiddleDown.BackColor != Color.FromArgb(11, 238, 50))
                        {
                            myLock.Lock("DOWN");
                            uitvoeren.Add("D");
                            await TinaTurner(uitvoeren.ToArray());
                            myLock.UnLock("DOWN");
                        }

                        if (FrontMiddleDown.BackColor != Color.FromArgb(11, 238, 50))
                        {
                            myLock.Lock("DOWN");
                            uitvoeren.Add("D");
                            await TinaTurner(uitvoeren.ToArray());
                            myLock.UnLock("DOWN");
                        }
                        AddItemsToList(uitvoeren, true);
                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";

                        List<Blokje> filterblokjes = kubus.Blokjes.FindAll(x => x.OorspronkelijkAdres.StartsWith("Down") && (x.OorspronkelijkAdres.EndsWith("Up") || x.OorspronkelijkAdres.EndsWith("Down")) && !x.OorspronkelijkAdres.Contains("Middle"));
                        List<string> blokjes = new List<string> { "DownRightUp", "DownLeftUp", "DownLeftDown", "DownRightDown" };

                        foreach (var item in blokjes)
                        {
                            myLock.Lock("Corners");

                            Blokje blokje = kubus.Blokjes.Find(x => x.OorspronkelijkAdres == item);
                            string adresnu = blokje.AdresBlokje;

                            uitvoeren = Algoritme.MaakCorners(kubus.Blokjes, item).ToList();


                            uitvoeren.Add("D");
                            await TinaTurner(uitvoeren.ToArray());
                            AddItemsToList(uitvoeren, true);

                            myLock.UnLock("Corners");

                            await UseDelay(uitvoeren.Count * 30);

                            //Stappen.Add(MakeSteps(uitvoeren));
                            stappen = "";
                        }

                        int count = -1;

                        List<Panel> panels = new List<Panel>();
                        foreach (Panel p in this.Controls.OfType<Panel>())
                        {
                            if (p.BackColor == Color.Yellow || p.Name.StartsWith("Down"))
                            {
                                count++;
                            }
                        }

                        if (count != 9)
                        {
                            foreach (var item in blokjes)
                            {
                                myLock.Lock("Corners");

                                Blokje blokje = kubus.Blokjes.Find(x => x.OorspronkelijkAdres == item);
                                string adresnu = blokje.AdresBlokje;

                                uitvoeren = Algoritme.MaakCorners(kubus.Blokjes, item).ToList();


                                uitvoeren.Add("D");
                                await TinaTurner(uitvoeren.ToArray());
                                AddItemsToList(uitvoeren, true);

                                myLock.UnLock("Corners");

                                await UseDelay(uitvoeren.Count * 30);

                                //Stappen.Add(MakeSteps(uitvoeren));
                                stappen = "";
                            }
                        }

                        uitvoeren.Clear();
                        uitvoeren = CollectionList;
                        AddItemsToList(uitvoeren);
                        CollectionList.Clear();

                    }
                    //F2L

                    else if (stap == 6) //Stap Nog aangepast worden
                    {
                        myLock.Lock("MaakF2LBlauwRood");
                        uitvoeren = Algoritme.MaakF2LBlauwRood(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";
                        myLock.UnLock("MaakF2LBlauwRood");
                    }
                    else if (stap == 7)
                    {
                        myLock.Lock("MaakF2LGroenOranje");
                        uitvoeren = Algoritme.MaakF2LGroenOranje(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";
                        myLock.UnLock("MaakF2LGroenOranje");
                    }
                    else if (stap == 8)
                    {
                        myLock.Lock("MaakF2LGroenRood");
                        uitvoeren = Algoritme.MaakF2LGroenRood(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        //Stappen.Add(MakeSteps(uitvoeren));
                        AddItemsToList(uitvoeren, true);
                        stappen = "";
                        myLock.UnLock("MaakF2LGroenRood");
                    }
                    else if (stap == 9)
                    {
                        myLock.Lock("MaakF2LBlauwOranje");
                        uitvoeren = Algoritme.MaakF2LBlauwOranje(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        uitvoeren.Clear();
                        uitvoeren = CollectionList;
                        AddItemsToList(uitvoeren);
                        CollectionList.Clear();
                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";
                        myLock.UnLock("MaakF2LBlauwOranje");

                        //Controle F2L Opgelost...
                        //Het kwam voor dat de F2L niet juist was opgelost en dat deze daarna vast liep
                        myLock.Lock("Controle");
                        bool juist = true;

                        Blokje FrontRight, FrontLeft, BackRight, BackLeft;
                        FrontRight = kubus.Blokjes.Find(x => x.AdresBlokje == "FrontRightMiddle");
                        FrontLeft = kubus.Blokjes.Find(x => x.AdresBlokje == "FrontLeftMiddle");
                        BackRight = kubus.Blokjes.Find(x => x.AdresBlokje == "BackRightMiddle");
                        BackLeft = kubus.Blokjes.Find(x => x.AdresBlokje == "BackLeftMiddle");




                        if (FrontRight.KleurBlokje != Color.FromArgb(11, 238, 50) || FrontLeft.KleurBlokje != Color.FromArgb(11, 238, 50))
                        {
                            juist = false;
                        }
                        if (BackLeft.KleurBlokje != Color.FromArgb(33, 96, 112) && BackRight.KleurBlokje != Color.FromArgb(33, 96, 112))
                        {
                            juist = false;
                        }



                        if (!juist)
                        {
                            uitvoeren.Clear();
                            uitvoeren.Add("R");
                            await TinaTurner(uitvoeren.ToArray());
                            AddItemsToList(uitvoeren, true);
                            stap = 0;
                        }

                        myLock.UnLock("Controle");
                    }
                    //Wit Kruis
                    else if (stap == 10)
                    {
                        myLock.Lock("MaakWitKruis");
                        uitvoeren = Algoritme.MaakWitKruis(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        //Stappen.Add(MakeSteps(uitvoeren));
                        stappen = "";
                        myLock.UnLock("MaakWitKruis");
                    }
                    //Wit vlak afmaken
                    //Deze moet meerderemalen opgeroepen worden totdat het gemaakt is
                    else if (stap == 11)
                    {
                        myLock.Lock("MaakWitVlak");
                        byte escLoop = 0;
                        do
                        {
                            uitvoeren = Algoritme.MaakWitVlak(kubus.Blokjes).ToList();
                            await TinaTurner(uitvoeren.ToArray());
                            AddItemsToList(uitvoeren, true);
                            stappen = "";
                            //Stappen.Add(MakeSteps(uitvoeren));
                            //Controle
                            int hoeveel = kubus.Blokjes.Where(x => x.AdresBlokje.StartsWith("Up") && x.KleurBlokje == Color.White).Count();

                            //Wanneer het misloopt iets veranderen en dan lukt het wel
                            if (escLoop == 10)
                            {
                                uitvoeren.Clear();
                                uitvoeren.Add("R");
                                await TinaTurner(uitvoeren.ToArray());
                                AddItemsToList(uitvoeren, true);
                                //Stappen.Add(MakeSteps(uitvoeren));
                                stappen = "";
                                stap = 0;
                                myLock.UnLock("MaakWitVlak");
                            }
                            if (hoeveel == 9)
                            {
                                myLock.UnLock("MaakWitVlak");
                            }
                        } while (myLock.IsLocked);

                        uitvoeren.Clear();
                        uitvoeren = CollectionList;
                        AddItemsToList(uitvoeren);
                        CollectionList.Clear();
                    }
                    //Hoekjes van het wittevlak goeddraaien
                    else if (stap == 12)
                    {
                        myLock.Lock("MaakHoekjesWitVlak");
                        byte escLoop = 0;
                        do
                        {
                            uitvoeren = Algoritme.MaakHoekjesWitVlak(kubus.Blokjes).ToList();
                            await TinaTurner(uitvoeren.ToArray());
                            AddItemsToList(uitvoeren, true);


                            //Controle
                            bool groenJuist = kubus.Blokjes.Find(x => x.AdresBlokje == "FrontLeftUp").KleurBlokje == kubus.Blokjes.Find(x => x.AdresBlokje == "FrontRightUp").KleurBlokje;

                            bool roodJuist = kubus.Blokjes.Find(x => x.AdresBlokje == "RightLeftUp").KleurBlokje == kubus.Blokjes.Find(x => x.AdresBlokje == "RightRightUp").KleurBlokje;

                            bool oranjeJuist = kubus.Blokjes.Find(x => x.AdresBlokje == "LeftLeftUp").KleurBlokje == kubus.Blokjes.Find(x => x.AdresBlokje == "LeftRightUp").KleurBlokje;

                            bool blauwJuist = kubus.Blokjes.Find(x => x.AdresBlokje == "BackLeftUp").KleurBlokje == kubus.Blokjes.Find(x => x.AdresBlokje == "BackRightUp").KleurBlokje;

                            if ((groenJuist && roodJuist && oranjeJuist && blauwJuist))
                            {
                                myLock.UnLock("MaakHoekjesWitVlak");
                            }
                            if (escLoop == 10)
                            {
                                uitvoeren.Clear();
                                uitvoeren.Add("R");
                                await TinaTurner(uitvoeren.ToArray());
                                AddItemsToList(uitvoeren, true);
                                stap = 0;
                                myLock.UnLock("MaakHoekjesWitVlak");
                            }
                            escLoop++;
                        } while (myLock.IsLocked);
                    }
                    //PLL - Permutation Last Layer
                    else if (stap == 13)
                    {
                        myLock.Lock("TheEnd");
                        uitvoeren = Algoritme.TheEnd(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        stappen = "";
                        uitvoeren = Algoritme.TheEnd(kubus.Blokjes).ToList();
                        await TinaTurner(uitvoeren.ToArray());
                        AddItemsToList(uitvoeren, true);
                        myLock.UnLock("TheEnd");
                    }
                    //Laatse Stap
                    else if (stap == 14)
                    {
                        myLock.Lock("TurnToCorrectSide");
                        do
                        {
                            uitvoeren = Algoritme.TurnToCorrectSide(kubus.Blokjes).ToList();
                            await TinaTurner(uitvoeren.ToArray());
                            AddItemsToList(uitvoeren, true);


                            stappen = "";
                            Blokje BackMiddleUp = kubus.Blokjes.Find(x => x.AdresBlokje.Equals("BackMiddleUp"));
                            Blokje BackMiddleDown = kubus.Blokjes.Find(x => x.AdresBlokje.Equals("BackMiddleDown"));

                            if (BackMiddleUp.KleurBlokje == BackMiddleDown.KleurBlokje)
                            {
                                myLock.UnLock("TurnToCorrectSide");
                            }
                        } while (myLock.IsLocked);



                        uitvoeren.Clear();
                        uitvoeren = CollectionList;
                        AddItemsToList(uitvoeren);
                        CollectionList.Clear();

                    }
                } while (myLock.IsLocked);


                await UseDelay(uitvoeren.Count * 20);
            }

            //Timer stoppen
            Timer.Stop();
            tijdVoorInDb = (DateTime.Now - startSolve).Seconds;

            //Kubus is opgelost, extra xp
            PlusXp(XpPlus.KubusOpgelost);

            //IN DB TIJD STEKEN
            Solve solve = new Solve
            {
                Scramble = lblScramble.Text.Replace("'", "P").Substring(10),
                Tijd = tijdVoorInDb,
                User = user,
            };

            DatabaseMethods.DatabaseActions("INSERT INTO tblSolves (TM,Username,Scramble) VALUES(" + solve.Tijd + ", '" + solve.User.Username + "', '" + solve.Scramble + "')");
            Time.Add(tijdVoorInDb);

            RefreshScramblesEnPatterns();
        }



        List<string> Stappenuitvoeren = new List<string>();

        //BUFFERLIST
        List<string> CollectionList = new List<string>();
        public void AddItemsToList(List<string> uitv, bool meer = false, int stap = 0)
        {
            string alg = "";
            foreach (string item in uitv)
            {
                alg += item;
            }

            if (stap != 0)
            {
                Stappenuitvoeren.ToArray();
                Stappenuitvoeren[stap] = alg;
                Stappenuitvoeren.ToList();
            }
            else
            {
                if (meer)
                {
                    CollectionList.Add(alg);
                }
                else
                {

                    Stappenuitvoeren.Add(alg);
                }
            }
        }



        string stappen = "";
        public string MakeSteps(List<string> uitvoeren)
        {
            foreach (var item in uitvoeren)
            {
                stappen += item;
            }
            return stappen;
        }

        #endregion


        #region Resets 
        private void BtnReset_Click(object sender, EventArgs e)
        {
            myLock.UnLock(myLock.KeyHolder);
            aantalMoves = 0;
            lblAantalMoves.Text = aantalMoves.ToString();
            strScramble = "Scramble: ";
            lblScramble.Text = strScramble;
            ResetBlokjesCube();


            ResetLayout();
            RefreshScramblesEnPatterns();
        }

        private void btnTimerUser_Click(object sender, EventArgs e)
        {
            Forms.Timer timer = new Forms.Timer();
            timer.Show();
        }

        int whereInSolve = 0;
        int stap = 5;


        string welkeRichting = "";

        bool tests = true;
        private async void BigSteps_Click(object sender, EventArgs e)
        {




            PictureBox picbox = (PictureBox)sender;
            if (picbox.Name == "pbStepLeft")
            {
                if (welkeRichting == "Rechts")
                {

                }
                else
                {
                    stap--;
                }

                Stappenuitvoeren.ToArray();
                string[] Mvs = ToSeparateMoves(Stappenuitvoeren[stap]);
                Stappenuitvoeren.ToList();
                int count = 0;
                foreach (string item in Mvs)
                {
                    if (item.EndsWith("'"))
                    {
                        Mvs[count] = item.Replace("'", "");
                    }
                    else
                    {
                        Mvs[count] = item + "'";
                    }
                    count++;
                }

                lblScramble.Text = "";
                foreach (var item in Mvs)
                {
                    lblScramble.Text += item;
                }

                Mvs.ToList();

                Mvs = Mvs.Reverse().ToArray();

                await TinaTurner(Mvs.ToArray());

                AddItemsToList(Mvs.ToList(), false, stap);

                welkeRichting = "Links";

            }







            else if (picbox.Name == "pbStepRight")
            {
                if (welkeRichting == "Links")
                {

                }
                else
                {
                    stap++;
                }


                //stap = stap + 1;
                Stappenuitvoeren.ToArray();
                string[] Mvs = ToSeparateMoves(Stappenuitvoeren[stap]);
                Stappenuitvoeren.ToList();
                int count = 0;
                foreach (string item in Mvs)
                {
                    if (item.EndsWith("'"))
                    {
                        Mvs[count] = item.Replace("'", "");
                    }
                    else
                    {
                        Mvs[count] = item + "'";
                    }
                    count++;
                }

                lblScramble.Text = "";
                foreach (var item in Mvs)
                {
                    lblScramble.Text += item;
                }

                Mvs.ToList();

                Mvs = Mvs.Reverse().ToArray();

                await TinaTurner(Mvs.ToArray());

                AddItemsToList(Mvs.ToList(), false, stap);

                welkeRichting = "Rechts";
            }





        }


        private string[] ToSeparateMoves(string moves)
        {
            List<string> toMoves = new List<string>();
            List<string> toMovesFilter = new List<string>();



            foreach (var item in moves)
            {
                toMoves.Add(item.ToString());
            }

            toMoves.ToArray();
            int total = toMoves.Count();


            int counter = 0;
            foreach (var item in toMoves)
            {



                //if (counter == total)
                //{
                //    return toMovesFilter.ToArray();
                //}


                try
                {
                    if (item != "'")
                    {
                        if (toMoves[counter + 1] == "'")
                        {
                            string move = toMoves[counter] + "'";
                            toMovesFilter.Add(move);
                        }
                        else
                        {
                            toMovesFilter.Add(item);
                        }
                    }

                    counter++;
                }
                catch (Exception)
                {
                    if (toMoves.Last() == "'")
                    {
                        string last = toMovesFilter.ToArray().Last();
                        last = last + "'";
                        toMovesFilter[toMovesFilter.Count - 1] = last;
                    }

                    return toMovesFilter.ToArray();
                }

            }

            return toMovesFilter.ToArray();

        }


        private void ResetLayout()
        {
            lblTijd.Text = "0,00";
            lblScramble.Text = "Scramble: ";
            strUitvoeringCode.Clear();
            txtAlgoritmeShow.Text = "";
            lblMove.Text = "?";
        }


        /// <summary>
        /// Reset al de kleuren van de kubus.
        /// </summary>
        public void ResetBlokjesCube()
        {
            foreach (Panel pnl in Controls.OfType<Panel>())
            {
                if (pnl.Name.StartsWith("Front"))
                {
                    if (pnl.BackColor != Color.FromArgb(11, 238, 50)) { pnl.BackColor = Color.FromArgb(11, 238, 50); }
                }
                else if (pnl.Name.StartsWith("Back"))
                {
                    if (pnl.BackColor != Color.FromArgb(33, 96, 112)) { pnl.BackColor = Color.FromArgb(33, 96, 112); }
                }
                else if (pnl.Name.StartsWith("Left"))
                {
                    if (pnl.BackColor != Color.FromArgb(240, 78, 0)) { pnl.BackColor = Color.FromArgb(240, 78, 0); }
                }
                else if (pnl.Name.StartsWith("Right"))
                {
                    if (pnl.BackColor != Color.FromArgb(173, 19, 19)) { pnl.BackColor = Color.FromArgb(173, 19, 19); }
                }
                else if (pnl.Name.StartsWith("Up"))
                {
                    if (pnl.BackColor != Color.White) { pnl.BackColor = Color.White; }
                }
                else if (pnl.Name.StartsWith("Down"))
                {
                    if (pnl.BackColor != Color.Yellow) { pnl.BackColor = Color.Yellow; }
                }
            }

            ColorConfirmer();
        }
        #endregion


        //Alles voor het zelf inkleuren van de kubus
        #region Zelf kleuren van kubus

        //Maakt alles grijs als je op kleuren klikt
        #region Kleuren_Click Alles grijs maken

        bool blokjesKleuren = false;

        private void Kleuren_Click(object sender, EventArgs e)
        {
            Button send = (Button)sender;
            if (!blokjesKleuren && send.Name == "btnKleuren")
            {
                KlaarmakenVoorKleuren(true);
            }
            else if (blokjesKleuren && send.Name == "btnKleuren")
            {
                bool kleurenInOrde = true;

                byte geel = 0, wit = 0, groen = 0, blauw = 0, rood = 0, oranje = 0;
                foreach (Panel pnl in Controls.OfType<Panel>().Where(b => b.Name.StartsWith("Front") || b.Name.StartsWith("Back") || b.Name.StartsWith("Left")
                                                                        || b.Name.StartsWith("Right") || b.Name.StartsWith("Up") || b.Name.StartsWith("Down")))
                {
                    if (pnl.BackColor == Color.White)
                    {
                        wit++;
                    }
                    else if (pnl.BackColor == Color.Yellow)
                    {
                        geel++;
                    }
                    else if (pnl.BackColor == Color.FromArgb(11, 238, 50))
                    {
                        groen++;
                    }
                    else if (pnl.BackColor == Color.FromArgb(33, 96, 112))
                    {
                        blauw++;
                    }
                    else if (pnl.BackColor == Color.FromArgb(173, 19, 19))
                    {
                        rood++;
                    }
                    else if (pnl.BackColor == Color.FromArgb(240, 78, 0))
                    {
                        oranje++;
                    }
                }

                if ((geel + wit + groen + blauw + rood + oranje) != 54)
                {
                    kleurenInOrde = false;
                }

                if (kleurenInOrde)
                {
                    KlaarmakenVoorKleuren(false);
                    ColorConfirmer();
                }
                else
                {
                    ToonError("The colors are not collored correctly", false);
                }
            }
            else
            {
                KlaarmakenVoorKleuren(false, true);
            }
        }

        /// <summary>
        /// Als de user gaat kleuren begennen of stopt met kleuren
        /// </summary>
        /// <param name="gaatKleuren">True als die nog begint</param>
        private void KlaarmakenVoorKleuren(bool gaatKleuren, bool btnQuit = false)
        {
            //Blokjes Kleuren aanzetten
            blokjesKleuren = gaatKleuren;

            //btnQuit Tonen
            btnQuitKleuren.Visible = gaatKleuren;

            //Zichtbaar maken van kleuren
            KleurenBlauw.Visible = KleurenGeel.Visible = KleurenGroen.Visible = KleurenOranje.Visible = KleurenRood.Visible = kleurenWit.Visible = PkleurGeselecteerd.Visible = gaatKleuren;

            //Onzichtbaar maken van andere knoppen
            //Draaibuttons
            Right.Visible = RightPrime.Visible = Left.Visible = LeftPrime.Visible = Front.Visible = FrontPrime.Visible = Back.Visible = BackPrime.Visible = Up.Visible = UpPrime.Visible = Down.Visible
            = DownPrime.Visible = btnScramble.Visible = btnShowAlg.Visible = btnReset.Visible = btnBack.Visible = !gaatKleuren;

            //Knoppen andere kant
            btnScramble.Visible = btnShowAlg.Visible = btnReset.Visible = btnBack.Visible = btnMovesForm.Visible = btnSolve.Visible = btnSignOut.Visible =
                btnRunOnCubieBot.Visible = btnConInfo.Visible = checkCubieBotConnect.Visible = checkSwapCon.Visible = !gaatKleuren;

            if (gaatKleuren)
            {
                //ResetBlokjesCube();
                btnKleuren.Text = "ACCEPT";

                //Panelen Grijs maken
                foreach (Panel item in Controls.OfType<Panel>().Where(b => b.Name.StartsWith("Front") || b.Name.StartsWith("Back") || b.Name.StartsWith("Left")
                                                                        || b.Name.StartsWith("Right") || b.Name.StartsWith("Up") || b.Name.StartsWith("Down")))
                {
                    if (!item.Name.EndsWith("Panel"))
                    {
                        item.BackColor = Color.Gray;
                    }
                }
            }
            else
            {
                btnKleuren.Text = "COLOR";
                if (btnQuit)
                {
                    ResetBlokjesCube();
                }
                else
                    ColorConfirmer();
            }
        }

        #endregion


        //Kleur de blokjes als je er op klikt
        #region Kleuren op klik

        Color selectedColor = Color.Gray;

        //Dient voor het inkleuren van de blokjes
        private void KleurenOp_Click(object sender, EventArgs e)
        {
            Panel PSender = (Panel)sender;
            Color achterKleur = PSender.BackColor;
            //if statement → Controleertwelke kleur
            if (achterKleur == Color.White)
                kleurCountAr[2]--;
            if (achterKleur == Color.Yellow)
                kleurCountAr[3]--;
            if (achterKleur == Color.FromArgb(11, 238, 50))
                kleurCountAr[1]--;
            if (achterKleur == Color.FromArgb(33, 96, 112))
                kleurCountAr[0]--;
            if (achterKleur == Color.FromArgb(173, 19, 19))
                kleurCountAr[4]--;
            if (achterKleur == Color.FromArgb(240, 78, 0))
                kleurCountAr[5]--;

            if (blokjesKleuren)
            {
                if (selectedColor == Color.White)
                    kleurCountAr[2]++;
                if (selectedColor == Color.Yellow)
                    kleurCountAr[3]++;
                if (selectedColor == Color.FromArgb(11, 238, 50))
                    kleurCountAr[1]++;
                if (selectedColor == Color.FromArgb(33, 96, 112))
                    kleurCountAr[0]++;
                if (selectedColor == Color.FromArgb(173, 19, 19))
                    kleurCountAr[4]++;
                if (selectedColor == Color.FromArgb(240, 78, 0))
                    kleurCountAr[5]++;

                PSender.BackColor = selectedColor;

            }
        }

        private void KleurenPalet_Click(object sender, EventArgs e)
        {
            Panel thiss = (Panel)sender;
            selectedColor = thiss.BackColor;
            PkleurGeselecteerd.BackColor = thiss.BackColor;
        }
        #endregion

        #endregion


        //Tonen van algoritme in nieuwe form
        #region Tonen Algoritme + Het omdraaien van het algoritme

        public List<string> strUitvoeringCode = new List<string>();

        private void BtnShowAlg_Click(object sender, EventArgs e)
        {
            Button send = (Button)sender;
            string[] arrAlg = strUitvoeringCode.ToArray();

            if (send.Name == "btnBack")
            {
                string omgeAlg = "";

                foreach (string item in arrAlg)
                {
                    if (item.EndsWith("'"))
                    {
                        omgeAlg += item.Replace("'", "") + " → ";
                    }
                    else
                    {
                        omgeAlg += item + "' → ";
                    }
                }

                txtAlgoritmeShow.Text = omgeAlg.Substring(0, omgeAlg.Length - 3); // De laatste pijl verwijderen
            }
            else
            {
                string alg = "";

                foreach (string item in arrAlg)
                {
                    alg += item + " → ";
                }

                txtAlgoritmeShow.Text = alg.Substring(0, alg.Length - 3); // De laatste pijl verwijderen
            }
        }

        /// <summary>
        /// Ga een stap achteruit
        /// </summary>
        private void BtnStepBackwards_Click(object sender, EventArgs e)
        {
            if (strUitvoeringCode.Count() > 0)
            {
                string laatsteTeken = strUitvoeringCode[strUitvoeringCode.Count - 1], turnLaatsteTeken;

                if (!String.IsNullOrWhiteSpace(laatsteTeken))
                {
                    //Turn klaarmaken (want deze moet omgekeerd zijn)
                    if (laatsteTeken.Contains("'"))
                        turnLaatsteTeken = laatsteTeken.Replace("'", "");
                    else
                        turnLaatsteTeken = laatsteTeken + "'";

                    TurnSplitter(turnLaatsteTeken);
                    strUitvoeringCode.RemoveAt(strUitvoeringCode.Count - 1);

                    //txtShowAlgoritme aanpassen
                    if (strUitvoeringCode.Count() > 0) //Controlleren na verwijderen
                    {
                        //lblMove
                        string voorlaatsteTeken = strUitvoeringCode[strUitvoeringCode.Count - 1];
                        lblMove.Text = voorlaatsteTeken;

                        //txtShowAlg aanpassen
                        if (laatsteTeken.Contains("'"))
                        {
                            txtAlgoritmeShow.Text = txtAlgoritmeShow.Text.Substring(0, txtAlgoritmeShow.Text.Length - 5);
                            //U → F' → L'
                        }
                        else
                        {
                            txtAlgoritmeShow.Text = txtAlgoritmeShow.Text.Substring(0, txtAlgoritmeShow.Text.Length - 4);
                        }
                    }
                    else
                    {
                        //lblMove
                        lblMove.Text = "?";

                        if (laatsteTeken.Contains("'"))
                        {
                            txtAlgoritmeShow.Text = txtAlgoritmeShow.Text.Substring(0, txtAlgoritmeShow.Text.Length - 2);
                            //U → F' → L'
                        }
                        else
                        {
                            txtAlgoritmeShow.Text = txtAlgoritmeShow.Text.Substring(0, txtAlgoritmeShow.Text.Length - 1);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Voert de juiste turn uit
        /// </summary>
        /// <param name="turn"></param>
        private void TurnSplitter(string turn)
        {
            switch (turn)
            {
                case "U":
                    Colorer(Turns.U(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("u");
                    break;
                case "U'":
                    Colorer(Turns.U(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("i");
                    break;
                case "D":
                    Colorer(Turns.D(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("d");
                    break;
                case "D'":
                    Colorer(Turns.D(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("s");
                    break;
                case "R":
                    Colorer(Turns.R(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("r");
                    break;
                case "R'":
                    Colorer(Turns.R(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("t");
                    break;
                case "L":
                    Colorer(Turns.L(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("l");
                    break;
                case "L'":
                    Colorer(Turns.L(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("m");
                    break;
                case "F":
                    Colorer(Turns.F(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("f");
                    break;
                case "F'":
                    Colorer(Turns.F(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("g");
                    break;
                case "B":
                    Colorer(Turns.B(kubus.Blokjes, false));
                    OpmakenVoorHetGesprek("b");
                    break;
                case "B'":
                    Colorer(Turns.B(kubus.Blokjes, true));
                    OpmakenVoorHetGesprek("n");
                    break;
                default:
                    break;
            }
        }

        #endregion


        //Afhandelen van draaien
        #region Turns

        private void Up_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("U");
            OpmakenVoorHetGesprek("u");
            Colorer(kubus.TurnU());
        }

        private void UpPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("U'");
            OpmakenVoorHetGesprek("i");
            Colorer(kubus.TurnU(true));
        }

        private void Down_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("D");
            OpmakenVoorHetGesprek("d");
            Colorer(kubus.TurnD());
        }

        private void DownPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("D'");
            OpmakenVoorHetGesprek("s");
            Colorer(kubus.TurnD(true));
        }

        private void Front_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("F");
            OpmakenVoorHetGesprek("f");
            Colorer(kubus.TurnF());
        }

        private void FrontPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("F'");
            OpmakenVoorHetGesprek("g");
            Colorer(kubus.TurnF(true));
        }

        private void Right_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("R");
            OpmakenVoorHetGesprek("r");
            Colorer(kubus.TurnR());
        }

        private void RightPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("R'");
            OpmakenVoorHetGesprek("t");
            Colorer(kubus.TurnR(true));
        }

        private void Back_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("B");
            OpmakenVoorHetGesprek("b");
            Colorer(kubus.TurnB());
        }

        private void BackPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("B'");
            OpmakenVoorHetGesprek("n");
            Colorer(kubus.TurnB(true));
        }

        private void Left_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("L");
            OpmakenVoorHetGesprek("l");
            Colorer(kubus.TurnL());
        }

        private void LeftPrime_Click(object sender, EventArgs e)
        {
            AfhandelenTurnLayout("L'");
            OpmakenVoorHetGesprek("m");
            Colorer(kubus.TurnL(true));
        }

        /// <summary>
        /// Telt moves bij het totaal aantal moves.
        /// </summary>
        /// <param name="move">[Optioneel] Voor aan de arduino lijn toe te voegen</param>
        public void AddMove(string move = "")
        {
            if (!String.IsNullOrWhiteSpace(move))
            {
                arduinoMoveString += move + ",";
            }

            aantalMoves++;
            lblAantalMoves.Text = aantalMoves.ToString();
        }

        public void AfhandelenTurnLayout(string turn, bool isEnkeleTurn = true)
        {
            //Toevoegen aan lijst met turns
            strUitvoeringCode.Add(turn);
            if (!String.IsNullOrWhiteSpace(txtAlgoritmeShow.Text))
                txtAlgoritmeShow.Text += " → " + turn;
            else
                txtAlgoritmeShow.Text += turn;

            //Laatste move label
            lblMove.Text = turn;

            //Xp erbij
            if (isEnkeleTurn)
            {
                PlusXp(XpPlus.KnopGeklikt);
            }

            ////Move erbij toevoegen
            //AddMove();
        }

        #endregion


        //Kleuren van blokjes in de gegeven kleur
        #region Colorer

        /// <summary>
        /// Kleurt de kubus volgens de list
        /// </summary>
        /// <param name="lijstBlokjes">List volgens te kleuren</param>
        public void Colorer(List<Blokje> lijstBlokjes)
        {
            kubus.Blokjes = lijstBlokjes;

            //Colorer Nieuwe versie (Geen DRY)
            foreach (Panel pnl in Controls.OfType<Panel>())
            {
                //Zoeken ofdat het paneel bestaad in de blokjes
                Blokje bijhorendBlokje = kubus.Blokjes.Find(b => b.AdresBlokje == pnl.Name);

                //Kijken ofdat gevonden
                if (bijhorendBlokje != null)
                {
                    pnl.BackColor = bijhorendBlokje.KleurBlokje;
                }

            }
        }

        #endregion


        //Na ingekleurd controle van de kleuren
        #region ColorConfirmer

        /// <summary>
        /// Slaagt de kleuren op nadat ze ingekleurd zijn
        /// </summary>
        /// <param name="lijstBlokjes">Lijst van al de blokjes</param>
        private void ColorConfirmer()
        {
            //Haalt al de panelen op en controlleert ofdat dit panneel deel uit maakt van de kubus
            foreach (Panel pnl in Controls.OfType<Panel>())
            {
                //Kijken ofdat het deel uitmaakt van de kubus
                Blokje aanTePassenBlokje = kubus.Blokjes.Find(b => b.AdresBlokje == pnl.Name);

                //Als het niet null is is het deel
                if (aanTePassenBlokje != null && !pnl.Name.Contains("Panel"))
                {
                    //Zoekt de index voor daarna te overschrijven
                    int index = kubus.Blokjes.IndexOf(aanTePassenBlokje);

                    //Zet de kleur van het blokje op de kleur van de panel
                    aanTePassenBlokje.KleurBlokje = pnl.BackColor;

                    //Dit is het adres van het blokje
                    string adres = pnl.Name;

                    //Zoeken naar adres nu...
                    foreach (Koppel kop in lstKoppels)
                    {
                        if (kop.Kant1.OorspronkelijkAdres == pnl.Name || kop.Kant2.OorspronkelijkAdres == pnl.Name || (kop.Kant3 != null && kop.Kant3.OorspronkelijkAdres == pnl.Name))
                        {

                            //Gekoppelde pannels zoeken
                            Panel panel1 = Controls.OfType<Panel>().First(p => p.Name == kop.Kant1.OorspronkelijkAdres);
                            Panel panel2 = Controls.OfType<Panel>().First(p => p.Name == kop.Kant2.OorspronkelijkAdres);
                            Panel panel3 = Controls.OfType<Panel>().FirstOrDefault(p => kop.Kant3 != null && p.Name == kop.Kant3.OorspronkelijkAdres);


                            Koppel kopGezocht = lstKoppels.Find(k => (k.Kant1.KleurBlokje == panel1.BackColor || k.Kant2.KleurBlokje == panel1.BackColor || (k.Kant3 != null && k.Kant3.KleurBlokje == panel1.BackColor)) && (k.Kant1.KleurBlokje == panel2.BackColor || k.Kant2.KleurBlokje == panel2.BackColor || (k.Kant3 != null && k.Kant3.KleurBlokje == panel2.BackColor)) && ((k.Kant3 == null && panel3 == null) || (panel3 != null && (k.Kant1.KleurBlokje == panel3.BackColor || k.Kant2.KleurBlokje == panel3.BackColor || (k.Kant3 != null && k.Kant3.KleurBlokje == panel3.BackColor)))));

                            if (kopGezocht != null)
                            {
                                //Via kleuren afleiden waar het echt hoort
                                if (kopGezocht.Kant1.KleurBlokje == pnl.BackColor)
                                {
                                    aanTePassenBlokje.OorspronkelijkAdres = kopGezocht.Kant1.OorspronkelijkAdres;
                                }
                                else if (kopGezocht.Kant2.KleurBlokje == pnl.BackColor)
                                {
                                    aanTePassenBlokje.OorspronkelijkAdres = kopGezocht.Kant2.OorspronkelijkAdres;
                                }
                                else if (kopGezocht.Kant3 != null && kopGezocht.Kant3.KleurBlokje == pnl.BackColor)
                                {
                                    aanTePassenBlokje.OorspronkelijkAdres = kopGezocht.Kant3.OorspronkelijkAdres;
                                }
                            }
                        }
                    }






                    //if (koppel.Kant3 == null)
                    //{ //edge
                    //    Color[] arrColor = { koppel.Kant1.KleurBlokje, koppel.Kant2.KleurBlokje };

                    //    if (arrColor[0] == aanTePassenBlokje.KleurBlokje) //Zelfde blokje
                    //    {
                    //        aanTePassenBlokje.OorspronkelijkAdres = koppel.Kant1.OorspronkelijkAdres;
                    //    }
                    //    else if (arrColor[1] == aanTePassenBlokje.KleurBlokje)
                    //    {
                    //        aanTePassenBlokje.OorspronkelijkAdres = koppel.Kant2.OorspronkelijkAdres;
                    //    }
                    //}
                    //else
                    //{
                    //    Color[] arrColor = { koppel.Kant1.KleurBlokje, koppel.Kant2.KleurBlokje, koppel.Kant3.KleurBlokje };
                    //    if (koppel.Kant1.KleurBlokje == aanTePassenBlokje.KleurBlokje) //Zelfde blokje
                    //    {
                    //        aanTePassenBlokje.OorspronkelijkAdres = koppel.Kant1.OorspronkelijkAdres;
                    //    }
                    //    else if (koppel.Kant2.KleurBlokje == aanTePassenBlokje.KleurBlokje)
                    //    {
                    //        aanTePassenBlokje.OorspronkelijkAdres = koppel.Kant2.OorspronkelijkAdres;
                    //    }
                    //    else if (koppel.Kant3.KleurBlokje == aanTePassenBlokje.KleurBlokje)
                    //    {
                    //        aanTePassenBlokje.OorspronkelijkAdres = koppel.Kant3.OorspronkelijkAdres;
                    //    }
                    //}

                    //Overschrijft het vorige blokje
                    kubus.Blokjes[index] = aanTePassenBlokje;
                }

            }
        }

        #endregion


        //Aanmaken van random algoritme voor kubus door elkaar te doen
        #region Mengen

        private async void Scramble_Click(object sender, EventArgs e)
        {
            aantalMoves = 0;
            lblAantalMoves.Text = aantalMoves.ToString();
            btnScramble.Enabled = false;
            btnSolve.Enabled = false;
            strScramble = "Scramble: ";
            strUitvoeringCode.Clear();
            ResetBlokjesCube();

            arduinoMoveString = "";

            if (!byte.TryParse(txtLengteScramble.Text, out byte lengteScramble))
            {
                lengteScramble = 15;
                txtLengteScramble.Text = "15";
            }

            foreach (int getal in kubus.ScrambleGenerator(lengteScramble))
            {
                switch (getal)
                {
                    case 2:
                        Colorer(kubus.TurnU(true));
                        strScramble += "U' ";
                        strUitvoeringCode.Add("U'");
                        AddMove("i");
                        break;
                    case 3:
                        Colorer(kubus.TurnD());
                        strScramble += "D ";
                        strUitvoeringCode.Add("D");
                        AddMove("d");
                        break;
                    case 4:
                        Colorer(kubus.TurnD(true));
                        strScramble += "D' ";
                        strUitvoeringCode.Add("D'");
                        AddMove("s");
                        break;
                    case 5:
                        Colorer(kubus.TurnF());
                        strScramble += "F ";
                        strUitvoeringCode.Add("F");
                        AddMove("f");
                        break;
                    case 6:
                        Colorer(kubus.TurnF(true));
                        strScramble += "F' ";
                        strUitvoeringCode.Add("F'");
                        AddMove("g");
                        break;
                    case 7:
                        Colorer(kubus.TurnB());
                        strScramble += "B ";
                        strUitvoeringCode.Add("B");
                        AddMove("b");
                        break;
                    case 8:
                        Colorer(kubus.TurnB(true));
                        strScramble += "B' ";
                        strUitvoeringCode.Add("B'");
                        AddMove("n");
                        break;
                    case 9:
                        Colorer(kubus.TurnL());
                        strScramble += "L ";
                        strUitvoeringCode.Add("L");
                        AddMove("l");
                        break;
                    case 10:
                        Colorer(kubus.TurnL(true));
                        strScramble += "L' ";
                        strUitvoeringCode.Add("L'");
                        AddMove("m");
                        break;
                    case 11:
                        Colorer(kubus.TurnR());
                        strScramble += "R ";
                        strUitvoeringCode.Add("R");
                        AddMove("r");
                        break;
                    case 12:
                        Colorer(kubus.TurnR(true));
                        strScramble += "R' ";
                        strUitvoeringCode.Add("R'");
                        AddMove("t");
                        break;

                    default: //1
                        Colorer(kubus.TurnU());
                        strScramble += "U ";
                        strUitvoeringCode.Add("U");
                        AddMove("u");
                        break;
                }
                strScramble = ReplaceStringScramble(strScramble);
                lblScramble.Text = strScramble;
                await UseDelay(100);

            }
            ColorConfirmer();
            btnScramble.Enabled = true;
            btnBack.Enabled = true;
            btnSolve.Enabled = true;
        }

        #endregion


        //String van algoritme clearen van slechte waarden UU → U2
        #region ReplaceStringScramble

        //Replaced all de slechte codes van de scrambler
        public string ReplaceStringScramble(string scramble)
        {
            scramble = scramble
                //Replace Dubbel
                .Replace("U U", "U2").Replace("U'' U'' ", "U2").Replace("F F", "F2").Replace("F'' F'' ", "F2").Replace("D D ", "D2").Replace("D'' D'' ", "D2")
                .Replace("B B", "B2").Replace("B'' B'' ", "B2").Replace("L L", "L2").Replace("L'' L'' ", "L2").Replace("R R", "R2").Replace("R'' R'' ", "R2")
                //Replace Tegengestelde
                .Replace("B B''", "").Replace("B'' B", "").Replace("F'' F", "").Replace("F F'' ", "").Replace("U'' U", "").Replace("U U''", "").Replace("D'' D", "").Replace("D D''", "")
                .Replace("L'' L", "").Replace("L L''", "").Replace("R'' R", "").Replace("R R''", "").Replace("B2 B2", "").Replace("F2 F2", "").Replace("D2 D2 ", "")
                .Replace("U2 U2", "").Replace("L2 L2", "").Replace("R2 R2", "")
                //Replace Dubbe aangepast
                .Replace("U2 U'", "U").Replace("U2 U", "U'").Replace("D2 D", "D'").Replace("D2 D'", "D").Replace("R2 R", "R'").Replace("R2 R'", "R").Replace("L2 L", "L'")
                .Replace("L2 L'", "L''").Replace("F2 F", "F'").Replace("F2 F'", "F").Replace("B2 B", "B'").Replace("B2 B'", "B");
            return scramble;
        }


        #endregion


        //Deze gaat de algoritmen uitvoeren die hij krijgt van de class "algoritmen.cs"
        //Afhandelen van algoritmes
        #region Tina Turner

        async public Task TinaTurner(string[] teDraaien)
        {
            foreach (string item in teDraaien)
            {
                switch (item)
                {
                    case "U":
                        AddMove("u");
                        Colorer(kubus.TurnU());
                        AfhandelenTurnLayout("U", false);
                        break;

                    case "U'":
                        //U'f
                        AddMove("i");
                        Colorer(kubus.TurnU(true));
                        AfhandelenTurnLayout("U'", false);
                        break;

                    case "D":
                        AddMove("d");
                        Colorer(kubus.TurnD());
                        AfhandelenTurnLayout("D", false);
                        break;

                    case "D'":
                        AddMove("s");
                        Colorer(kubus.TurnD(true));
                        AfhandelenTurnLayout("D'", false);
                        break;

                    case "R":
                        AddMove("r");
                        Colorer(kubus.TurnR());
                        AfhandelenTurnLayout("R", false);
                        break;

                    case "R'":
                        AddMove("t");
                        Colorer(kubus.TurnR(true));
                        AfhandelenTurnLayout("R'", false);
                        break;

                    case "L":
                        AddMove("l");
                        Colorer(kubus.TurnL());
                        AfhandelenTurnLayout("L", false);
                        break;

                    case "L'":
                        AddMove("m");
                        Colorer(kubus.TurnL(true));
                        AfhandelenTurnLayout("L'", false);
                        break;

                    case "F":
                        AddMove("f");
                        Colorer(kubus.TurnF());
                        AfhandelenTurnLayout("F", false);
                        break;

                    case "F'":
                        AddMove("g");
                        Colorer(kubus.TurnF(true));
                        AfhandelenTurnLayout("F'", false);
                        break;

                    case "B":
                        AddMove("b");
                        Colorer(kubus.TurnB());
                        AfhandelenTurnLayout("B", false);
                        break;

                    case "B'":
                        AddMove("b'");
                        Colorer(kubus.TurnB(true));
                        AfhandelenTurnLayout("B'", false);
                        break;

                    default:
                        break;
                }

                await UseDelay(10);
            }
        }


        #endregion


        //Arduino Stuff
        #region Arduino

        /******* Begin Declaratie Arduino ***********/
        /* Worden gebruikt voor arduino*/
        CubieBotConnectie connectie1 = null;   //Dit is een van de connecties voor te verbinden met de Arduino
        CubieBotConnectie connectie2 = null;   //Dit is een van de connecties voor te verbinden met de Arduino
        List<CubieBotConnectie> vrijePoorten = new List<CubieBotConnectie>();

        /// <summary>
        /// Dit is de controle ofdat de CubieBot de volgende draai al mag doen.
        /// </summary>
        Locking ArduinoLock = new Locking("Arduino");

        /// <summary>
        /// In deze string worden al de moves gestoken zoddat ze daarna naar de Arduino kunnen gestuurd worden.
        /// Dit is een komma sepperated string
        /// </summary>
        string arduinoMoveString = "";
        /******** Einde Declaratie Arduino **********/


        private void CheckCubieBotConnect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkCubieBotConnect.Checked)
                {
                    ConnectCubieBot();
                }
                else
                {
                    btnRunOnCubieBot.Enabled = false;
                    connectie1 = null;
                    connectie2 = null;
                }
            }
            catch (Exception)
            {
                ToonError("Error with connection");
            }
        }

        /// <summary>
        /// Connecteerd het programma met de CubieBot
        /// </summary>
        /// <returns></returns>
        public bool ConnectCubieBot()
        {
            bool gelukt = false;
            connectie1 = null;
            connectie2 = null;

            try
            {
                vrijePoorten = CubieBotConnectie.PoortenBeschikbaar();

                //Controlleren ofdat er poorten vrij zijn
                if (vrijePoorten.Count > 0)
                {
                    //asignen aan connectie 1
                    foreach (CubieBotConnectie con in vrijePoorten.Where(p => !p.WordtGebruikt))
                    {
                        if (connectie1 == null)
                        {
                            connectie1 = con;
                        }
                    }

                    //Controle ofdat het gelukt is
                    if (connectie1 != null)
                    {
                        //Waarde veranderen als het gelukt is
                        vrijePoorten.Find(p => p.Naam == connectie1.Naam).WordtGebruikt = true;
                        connectie1.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceiver);
                    }

                    foreach (CubieBotConnectie con in vrijePoorten.Where(p => !p.WordtGebruikt))
                    {
                        if (connectie2 == null)
                        {
                            connectie2 = con;
                        }
                    }

                    //Controle ofdat het gelukt is
                    if (connectie2 != null)
                    {
                        vrijePoorten.Find(p => p.Naam == connectie2.Naam).WordtGebruikt = true;
                        connectie2.SerialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(DataReceiver);
                    }

                    //Controlleren op swap
                    if (checkSwapCon.Checked)
                    {
                        CubieBotConnectie swapvar = connectie2;
                        connectie2 = connectie1;
                        connectie1 = swapvar;
                    }

                    //Laatse Controle
                    if (connectie1 != null && connectie2 != null)
                    {
                        btnRunOnCubieBot.Enabled = true;
                        gelukt = true;
                    }
                    else if ((connectie1 != null && connectie2 == null) || (connectie1 == null && connectie2 != null))
                    {
                        gelukt = false;
                        checkCubieBotConnect.Checked = false;
                        ToonError("Please Connect the 2 wires, only one is connected");
                    }
                    else
                    {
                        gelukt = false;
                        checkCubieBotConnect.Checked = false;
                        ToonError("Connection failed");
                    }
                }
                else
                {
                    ToonError("Please connect the CubieBot");
                    checkCubieBotConnect.Checked = false;
                    return gelukt;
                }
            }
            catch (Exception)
            {
                ToonError("Connecting CubieBot failed... \nMaybe try again");
                return gelukt;
            }

            return gelukt;
        }

        /// <summary>
        /// Ophalen van data dat de arduino terugstuurd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataReceiver(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort myPort = (SerialPort)sender;

            string data = myPort.ReadExisting();
            if (data.Substring(data.Length - 3, 3) == "X\r\n")
                ArduinoLock.UnLock("MagTerug");
        }

        /// <summary>
        /// Event voor tonen van informatie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToonInformatieConnectie(object sender, EventArgs e)
        {
            ConnectieInformatie con = new ConnectieInformatie(connectie1, connectie2);
            con.Show();
        }

        /// <summary>
        /// Stuurt de bewegingen door naar de CubieBot zelf, Via de connecties
        /// </summary>
        /// <param name="arrMoves">array van al de stappen die moeten uitgevoerd worden</param>
        async public void PratenMetConnectie(string[] arrMoves)
        {
            if (connectie1 != null && connectie2 != null)
            {

                try
                {
                    //Openen van verbindingen
                    connectie1.SerialPort.Open();
                    connectie2.SerialPort.Open();
                    foreach (string turn in arrMoves)
                    {
                        if (turn == "f" || turn == "g" || turn == "b" || turn == "n" || turn == "l" || turn == "m")
                        {
                            //Connection1 wordt gebruikt voor het draaien van de voorste, achterste en linkse zijde
                            connectie1.SerialPort.Write(turn);
                            while (ArduinoLock.IsLocked) //Als de arduino niet mag draaien dan komt deze vast te zitten in de loop totdat deze antwoord en unlockdd
                            {
                                await UseDelay(50);
                            }
                            ArduinoLock.Lock("MagTerug");
                        }
                        else
                        {
                            //Connection 2 wordt gebruikt voor het draaien van de bovenste, onderste en rechste zijde
                            connectie2.SerialPort.Write(turn);
                            while (ArduinoLock.IsLocked)
                            {
                                await UseDelay(50);
                            }
                            ArduinoLock.Lock("MagTerug");
                        }
                    }
                }
                catch (Exception)
                {
                    ToonError("Problem with the turning of the CubieBot");
                }

                //Sluiten van verbindingen
                connectie1.SerialPort.Close();
                connectie2.SerialPort.Close();
            }
            else
                ToonError("The CubieBot is not properly connected");
        }

        /// <summary>
        /// Split een string op ',' zodat het met de Arduino kan praten
        /// </summary>
        /// <param name="str">Komma sepperated string voor de splitsen</param>
        public void OpmakenVoorHetGesprek(string str)
        {
            if (checkCubieBotConnect.Checked)
            {
                if (str.EndsWith(","))
                {
                    str = str.Substring(0, str.Length - 1);
                }

                string[] arrWoorden = str.ToLower().Split(',');
                PratenMetConnectie(arrWoorden);
            }
        }

        private void RunOnCubieBot_Click(object sender, EventArgs e)
        {
            if (checkCubieBotConnect.Checked)
            {
                if (!String.IsNullOrWhiteSpace(arduinoMoveString))
                {
                    OpmakenVoorHetGesprek(arduinoMoveString);
                }
            }
            else
            {
                ToonError("The CubieBot is not connected");
                btnRunOnCubieBot.Enabled = false;
            }
        }

        #endregion


        //Methodes in verband met levels
        #region Levels

        /// <summary>
        /// Controlleert het level van de persoon
        /// </summary>
        /// <param name="xp">Het aantal xp van de persoon</param>
        /// <returns>Een array van doubles [0]: level, [1]: xpOver, [2]: percentage van volgend level</returns>
        public double[] LevelControlleren(double xp)
        {
            double[] arrXPLVL = new double[3];
            double level, xpOver;
            double percentage;

            level = Math.Floor(Math.Pow(xp, 0.3333333333333333333333333));
            xpOver = (xp - Math.Pow(level, 3));
            percentage = Math.Round(xpOver / (Math.Pow(level + 1, 3) - Math.Pow(level, 3)) * 100, 2);

            arrXPLVL[0] = level;
            arrXPLVL[1] = xpOver;
            arrXPLVL[2] = percentage;

            return arrXPLVL;
        }

        /// <summary>
        /// Telt een bepaald aantal xp op bij hetgene dat de persoon al heeft.
        /// </summary>
        /// <param name="para">De case voor te bepalen hoeveel xp de persoon moet krijgen.</param>
        public void PlusXp(XpPlus para)
        {
            switch (para)
            {
                case XpPlus.KubusOpgelost:
                    if (checkCubieBotConnect.Checked)
                        user.Experience += 100;
                    else
                        user.Experience += 50;
                    break;
                case XpPlus.KnopGeklikt:
                    if (checkCubieBotConnect.Checked)
                        user.Experience += 2;
                    else
                        user.Experience += 1;
                    break;
                default:
                    break;
            }

            XpAanpassen();
        }

        /// <summary>
        /// Past de xp bar aan + level
        /// </summary>
        public void XpAanpassen()
        {
            double percentage, currentLevel;
            double[] arr = LevelControlleren(user.Experience);
            currentLevel = arr[0];
            percentage = arr[2];

            if (user.Level == currentLevel)
            {
                XPBarJuist(percentage);
            }
            else
            {
                user.Level = currentLevel;
                DatabaseMethods.DatabaseActions("UPDATE tblAccount" + " SET LVL = " + user.Level + " WHERE Username = '" + user.Username + "'");
                XPBarJuist(percentage);
            }

            DatabaseMethods.DatabaseActions("UPDATE tblAccount" + " SET xp = " + user.Experience + " WHERE Username = '" + user.Username + "'");
            lblLevel.Text = "Level: " + user.Level;
        }

        public void XPBarJuist(double percentage)
        {
            pnlLevelXP.Width = (int)Math.Round(lblXpbar.Width * (percentage / 100), 0);
        }

        #endregion


        // Deze region bevat al de methodes die nergens anders bijhoren
        // Maar wel vaak gebruikt worden
        #region Helpmethods

        /// <summary>
        /// Toont een errormelding op het scherm.
        /// </summary>
        /// <param name="error">Wat er in de errormelding moet staan [Niet verplicht]</param>
        private void ToonError(string error = "An error occurred", bool isError = true)
        {
            Errorbox er = new Errorbox(error, isError);
            er.Show();
        }

        /// <summary>
        /// Zorgt voor een delay tijdens het programma
        /// </summary>
        /// <param name="delay">De delay in miliseconden</param>
        async Task UseDelay(int delay)
        {
            await Task.Delay(delay);
        }

        private void Logo_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/dQw4w9WgXcQ");
        }

        /// <summary>
        /// Toont de handleiding opn het scherm. (extra form)
        /// </summary>
        private void BtnMovesForm_Click(object sender, EventArgs e)
        {
            MovesForm mf = new MovesForm();
            mf.Show();
        }

        DateTime startSolve = DateTime.Now;
        private void Timer_Tick(object sender, EventArgs e)
        {
            string tussentijd = Math.Round((DateTime.Now - startSolve).TotalSeconds, 2).ToString();
            lblTijd.Text = tussentijd;
        }
        #endregion
    }

    /// <summary>
    /// enum voor het bepalen van hoeveel xp de persoon moet krijgen
    /// </summary>
    public enum XpPlus
    {
        KubusOpgelost,
        KnopGeklikt,
    }
}