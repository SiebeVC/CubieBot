using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GIPKubusProject
{

    public class Turns
    {

        /// <summary>
        /// Draaien van de bovenste zijde
        /// </summary>
        /// <param name="isPrime">True indien met de klok meedraaien</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> U(List<Blokje> lstBlokjes, bool isPrime)
        {
            //Al de draaiende blokjes van de U laag
            #region Input

            //WIT
            Blokje WCorner1 = lstBlokjes.Find(x => x.AdresBlokje == "UpLeftUp");
            int WCorner1i = lstBlokjes.IndexOf(WCorner1);
            Blokje WEdge2 = lstBlokjes.Find(x => x.AdresBlokje == "UpMiddleUp");
            int WEdge2i = lstBlokjes.IndexOf(WEdge2);
            Blokje WCorner3 = lstBlokjes.Find(x => x.AdresBlokje == "UpRightUp");
            int WCorner3i = lstBlokjes.IndexOf(WCorner3);
            Blokje WEdge4 = lstBlokjes.Find(x => x.AdresBlokje == "UpLeftMiddle");
            int WEdge4i = lstBlokjes.IndexOf(WEdge4);
            Blokje WEdge6 = lstBlokjes.Find(x => x.AdresBlokje == "UpRightMiddle");
            int WEdge6i = lstBlokjes.IndexOf(WEdge6);
            Blokje WCorner7 = lstBlokjes.Find(x => x.AdresBlokje == "UpLeftDown");
            int WCorner7i = lstBlokjes.IndexOf(WCorner7);
            Blokje WEdge8 = lstBlokjes.Find(x => x.AdresBlokje == "UpMiddleDown");
            int WEdge8i = lstBlokjes.IndexOf(WEdge8);
            Blokje WCorner9 = lstBlokjes.Find(x => x.AdresBlokje == "UpRightDown");
            int WCorner9i = lstBlokjes.IndexOf(WCorner9);


            //BLAUW
            Blokje BCorner1 = lstBlokjes.Find(x => x.AdresBlokje == "BackLeftUp");
            int BCorner1i = lstBlokjes.IndexOf(BCorner1);
            Blokje BEdge2 = lstBlokjes.Find(x => x.AdresBlokje == "BackMiddleUp");
            int BEdge2i = lstBlokjes.IndexOf(BEdge2);
            Blokje BCorner3 = lstBlokjes.Find(x => x.AdresBlokje == "BackRightUp");
            int BCorner3i = lstBlokjes.IndexOf(BCorner3);


            //ROOD
            Blokje RCorner1 = lstBlokjes.Find(x => x.AdresBlokje == "RightLeftUp");
            int RCorner1i = lstBlokjes.IndexOf(RCorner1);
            Blokje REdge2 = lstBlokjes.Find(x => x.AdresBlokje == "RightMiddleUp");
            int REdge2i = lstBlokjes.IndexOf(REdge2);
            Blokje RCorner3 = lstBlokjes.Find(x => x.AdresBlokje == "RightRightUp");
            int RCorner3i = lstBlokjes.IndexOf(RCorner3);


            //GROEN
            Blokje GEdge2 = lstBlokjes.Find(x => x.AdresBlokje == "FrontMiddleUp");
            int GEdge2i = lstBlokjes.IndexOf(GEdge2);
            Blokje GCorner3 = lstBlokjes.Find(x => x.AdresBlokje == "FrontRightUp");
            int GCorner3i = lstBlokjes.IndexOf(GCorner3);
            Blokje GCorner1 = lstBlokjes.Find(x => x.AdresBlokje == "FrontLeftUp");
            int GCorner1i = lstBlokjes.IndexOf(GCorner1);


            //ORANJE
            Blokje OCorner1 = lstBlokjes.Find(x => x.AdresBlokje == "LeftLeftUp");
            int OCorner1i = lstBlokjes.IndexOf(OCorner1);
            Blokje OEdge2 = lstBlokjes.Find(x => x.AdresBlokje == "LeftMiddleUp");
            int OEdge2i = lstBlokjes.IndexOf(OEdge2);
            Blokje OCorner3 = lstBlokjes.Find(x => x.AdresBlokje == "LeftRightUp");
            int OCorner3i = lstBlokjes.IndexOf(OCorner3);

            #endregion


            if (!isPrime)
            {
                //Met de klok mee
                #region Processing U
                //Wit vlak draaien
                //Corners
                string onthoudWCorner = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = onthoudWCorner;

                string onthoud1 = RCorner1.AdresBlokje;
                string onthoud3 = RCorner3.AdresBlokje;


                //Zijkant
                RCorner1.AdresBlokje = GCorner1.AdresBlokje;
                RCorner3.AdresBlokje = GCorner3.AdresBlokje;

                GCorner1.AdresBlokje = OCorner1.AdresBlokje;
                GCorner3.AdresBlokje = OCorner3.AdresBlokje;

                OCorner1.AdresBlokje = BCorner1.AdresBlokje;
                OCorner3.AdresBlokje = BCorner3.AdresBlokje;

                BCorner1.AdresBlokje = onthoud1;
                BCorner3.AdresBlokje = onthoud3;


                //Edges
                string onthoudWEdge = WEdge2.AdresBlokje;
                WEdge2.AdresBlokje = WEdge6.AdresBlokje;
                WEdge6.AdresBlokje = WEdge8.AdresBlokje;
                WEdge8.AdresBlokje = WEdge4.AdresBlokje;
                WEdge4.AdresBlokje = onthoudWEdge;

                //Edges zijkant
                string onthoud2 = REdge2.AdresBlokje;
                REdge2.AdresBlokje = GEdge2.AdresBlokje;
                GEdge2.AdresBlokje = OEdge2.AdresBlokje;
                OEdge2.AdresBlokje = BEdge2.AdresBlokje;
                BEdge2.AdresBlokje = onthoud2;
                #endregion
            }
            else
            {
                //Tegen de klok in
                #region Processing U'

                //WIT VLAK DRAAIEN
                //Corners
                string onthoud = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = onthoud;

                //Edges

                onthoud = WEdge2.AdresBlokje;
                WEdge2.AdresBlokje = WEdge4.AdresBlokje;
                WEdge4.AdresBlokje = WEdge8.AdresBlokje;
                WEdge8.AdresBlokje = WEdge6.AdresBlokje;
                WEdge6.AdresBlokje = onthoud;

                //ZIJKANTEN
                //Corner 1
                onthoud = GCorner1.AdresBlokje;
                GCorner1.AdresBlokje = RCorner1.AdresBlokje;
                RCorner1.AdresBlokje = BCorner1.AdresBlokje;
                BCorner1.AdresBlokje = OCorner1.AdresBlokje;
                OCorner1.AdresBlokje = onthoud;

                //Corner 3
                onthoud = GCorner3.AdresBlokje;
                GCorner3.AdresBlokje = RCorner3.AdresBlokje;
                RCorner3.AdresBlokje = BCorner3.AdresBlokje;
                BCorner3.AdresBlokje = OCorner3.AdresBlokje;
                OCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = GEdge2.AdresBlokje;
                GEdge2.AdresBlokje = REdge2.AdresBlokje;
                REdge2.AdresBlokje = BEdge2.AdresBlokje;
                BEdge2.AdresBlokje = OEdge2.AdresBlokje;
                OEdge2.AdresBlokje = onthoud;
                #endregion
            }
            //Maken van lijst voor de output
            #region Lijst Maken

            //List aanpassen
            lstBlokjes[WCorner1i] = WCorner1;
            lstBlokjes[WEdge2i] = WEdge2;
            lstBlokjes[WCorner3i] = WCorner3;
            lstBlokjes[WEdge4i] = WEdge4;
            lstBlokjes[WEdge6i] = WEdge6;
            lstBlokjes[WCorner7i] = WCorner7;
            lstBlokjes[WEdge8i] = WEdge8;
            lstBlokjes[WCorner9i] = WCorner9;
            lstBlokjes[BCorner1i] = BCorner1;
            lstBlokjes[BEdge2i] = BEdge2;
            lstBlokjes[BCorner3i] = BCorner3;
            lstBlokjes[RCorner1i] = RCorner1;
            lstBlokjes[REdge2i] = REdge2;
            lstBlokjes[RCorner3i] = RCorner3;
            lstBlokjes[GCorner1i] = GCorner1;
            lstBlokjes[GEdge2i] = GEdge2;
            lstBlokjes[GCorner3i] = GCorner3;
            lstBlokjes[OCorner1i] = OCorner1;
            lstBlokjes[OEdge2i] = OEdge2;
            lstBlokjes[OCorner3i] = OCorner3;
            #endregion

            //Output
            return lstBlokjes;
        }

        /// <summary>
        /// Draaien van de onderste zijde 
        /// </summary>
        /// <param name="lstBlokjes"></param>
        /// <param name="isPrime">True indien met de klok meedraaien</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> D(List<Blokje> lstBlokjes, bool isPrime)
        {
            //Al de draaiende blokjes van de D laag
            #region Input

            //Yellow Back
            Blokje YCorner1 = lstBlokjes.Find(z => z.AdresBlokje == "DownLeftUp");
            int YCorner1i = lstBlokjes.IndexOf(YCorner1);
            Blokje YEdge2 = lstBlokjes.Find(z => z.AdresBlokje == "DownMiddleUp");
            int YEdge2i = lstBlokjes.IndexOf(YEdge2);
            Blokje YCorner3 = lstBlokjes.Find(z => z.AdresBlokje == "DownRightUp");
            int YCorner3i = lstBlokjes.IndexOf(YCorner3);
            Blokje YEdge4 = lstBlokjes.Find(z => z.AdresBlokje == "DownLeftMiddle");
            int YEdge4i = lstBlokjes.IndexOf(YEdge4);
            Blokje YEdge6 = lstBlokjes.Find(z => z.AdresBlokje == "DownRightMiddle");
            int YEdge6i = lstBlokjes.IndexOf(YEdge6);
            Blokje YCorner7 = lstBlokjes.Find(z => z.AdresBlokje == "DownLeftDown");
            int YCorner7i = lstBlokjes.IndexOf(YCorner7);
            Blokje YEdge8 = lstBlokjes.Find(z => z.AdresBlokje == "DownMiddleDown");
            int YEdge8i = lstBlokjes.IndexOf(YEdge8);
            Blokje YCorner9 = lstBlokjes.Find(z => z.AdresBlokje == "DownRightDown");
            int YCorner9i = lstBlokjes.IndexOf(YCorner9);

            //Zijkanten
            //Green - Front
            Blokje GCorner7 = lstBlokjes.Find(z => z.AdresBlokje == "FrontLeftDown");
            int GCorner7i = lstBlokjes.IndexOf(GCorner7);
            Blokje GEdge8 = lstBlokjes.Find(z => z.AdresBlokje == "FrontMiddleDown");
            int GEdge8i = lstBlokjes.IndexOf(GEdge8);
            Blokje GCorner9 = lstBlokjes.Find(z => z.AdresBlokje == "FrontRightDown");
            int GCorner9i = lstBlokjes.IndexOf(GCorner9);

            //Red - Right
            Blokje RCorner7 = lstBlokjes.Find(z => z.AdresBlokje == "RightLeftDown");
            int RCorner7i = lstBlokjes.IndexOf(RCorner7);
            Blokje REdge8 = lstBlokjes.Find(z => z.AdresBlokje == "RightMiddleDown");
            int REdge8i = lstBlokjes.IndexOf(REdge8);
            Blokje RCorner9 = lstBlokjes.Find(z => z.AdresBlokje == "RightRightDown");
            int RCorner9i = lstBlokjes.IndexOf(RCorner9);

            //Blue - back
            Blokje BCorner7 = lstBlokjes.Find(z => z.AdresBlokje == "BackLeftDown");
            int BCorner7i = lstBlokjes.IndexOf(BCorner7);
            Blokje BEdge8 = lstBlokjes.Find(z => z.AdresBlokje == "BackMiddleDown");
            int BEdge8i = lstBlokjes.IndexOf(BEdge8);
            Blokje BCorner9 = lstBlokjes.Find(z => z.AdresBlokje == "BackRightDown");
            int BCorner9i = lstBlokjes.IndexOf(BCorner9);

            //Orange - Left
            Blokje OCorner7 = lstBlokjes.Find(z => z.AdresBlokje == "LeftLeftDown");
            int OCorner7i = lstBlokjes.IndexOf(OCorner7);
            Blokje OEdge8 = lstBlokjes.Find(z => z.AdresBlokje == "LeftMiddleDown");
            int OEdge8i = lstBlokjes.IndexOf(OEdge8);
            Blokje OCorner9 = lstBlokjes.Find(z => z.AdresBlokje == "LeftRightDown");
            int OCorner9i = lstBlokjes.IndexOf(OCorner9);

            #endregion

            if (!isPrime)
            {
                //Met de klok mee
                #region Processing D

                //Geel vlak draaien
                //Corners
                string onthoud = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = onthoud; //Waarde BCorner9 veranderd hier??

                //Edge
                onthoud = YEdge2.AdresBlokje;
                YEdge2.AdresBlokje = YEdge6.AdresBlokje;
                YEdge6.AdresBlokje = YEdge8.AdresBlokje;
                YEdge8.AdresBlokje = YEdge4.AdresBlokje;
                YEdge4.AdresBlokje = onthoud; // waarde BEdge veranderd hier??

                //Zijkanten
                //Corner links
                onthoud = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = onthoud;

                //Corner rechts
                onthoud = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = onthoud;

                //Edge
                onthoud = REdge8.AdresBlokje;
                REdge8.AdresBlokje = BEdge8.AdresBlokje;
                BEdge8.AdresBlokje = OEdge8.AdresBlokje;
                OEdge8.AdresBlokje = GEdge8.AdresBlokje;
                GEdge8.AdresBlokje = onthoud;
                #endregion
            }
            else
            {
                //Tegen de klok in
                #region Processing D'

                //Geel vlak draaien
                //Corners
                string onthoud = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = onthoud;

                //Edges
                onthoud = YEdge2.AdresBlokje;
                YEdge2.AdresBlokje = YEdge4.AdresBlokje;
                YEdge4.AdresBlokje = YEdge8.AdresBlokje;
                YEdge8.AdresBlokje = YEdge6.AdresBlokje;
                YEdge6.AdresBlokje = onthoud;

                //Zijkanten
                //Corner Rechts
                onthoud = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = onthoud;

                //Corner Links
                onthoud = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = onthoud;

                //Edges
                onthoud = GEdge8.AdresBlokje;
                GEdge8.AdresBlokje = OEdge8.AdresBlokje;
                OEdge8.AdresBlokje = BEdge8.AdresBlokje;
                BEdge8.AdresBlokje = REdge8.AdresBlokje;
                REdge8.AdresBlokje = onthoud;

                #endregion
            }

            //Maken van lijst voor de output
            #region List Maken

            lstBlokjes[YCorner1i] = YCorner1;
            lstBlokjes[YEdge2i] = YEdge2;
            lstBlokjes[YCorner3i] = YCorner3;
            lstBlokjes[YEdge4i] = YEdge4;
            lstBlokjes[YEdge6i] = YEdge6;
            lstBlokjes[YCorner7i] = YCorner7;
            lstBlokjes[YEdge8i] = YEdge8;
            lstBlokjes[YCorner9i] = YCorner9;
            lstBlokjes[OCorner7i] = OCorner7;
            lstBlokjes[OEdge8i] = OEdge8;
            lstBlokjes[OCorner9i] = OCorner9;
            lstBlokjes[RCorner7i] = RCorner7;
            lstBlokjes[REdge8i] = REdge8;
            lstBlokjes[RCorner9i] = RCorner9;
            lstBlokjes[GCorner7i] = GCorner7;
            lstBlokjes[GEdge8i] = GEdge8;
            lstBlokjes[GCorner9i] = GCorner9;
            lstBlokjes[BCorner7i] = BCorner7;
            lstBlokjes[BEdge8i] = BEdge8;
            lstBlokjes[BCorner9i] = BCorner9;

            #endregion

            return lstBlokjes;
        }

        /// <summary>
        /// Draaien van de voorste zijde
        /// </summary>
        /// <param name="lstBlokjes">lijst met blokjes</param>
        /// <param name="isPrime">Indien tegen de klok draaien 'true'</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> F(List<Blokje> lstBlokjes, bool isPrime)
        {
            //Al de draaiende blokjes vand de F laag
            #region Input

            //Front Vlak - GREEN
            Blokje GCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "FrontLeftUp");
            int GCorner1i = lstBlokjes.IndexOf(GCorner1);
            Blokje GEdge2 = lstBlokjes.Find(b => b.AdresBlokje == "FrontMiddleUp");
            int GEdge2i = lstBlokjes.IndexOf(GEdge2);
            Blokje GCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "FrontRightUp");
            int GCorner3i = lstBlokjes.IndexOf(GCorner3);
            Blokje GEdge4 = lstBlokjes.Find(b => b.AdresBlokje == "FrontLeftMiddle");
            int GEdge4i = lstBlokjes.IndexOf(GEdge4);
            Blokje GEdge6 = lstBlokjes.Find(b => b.AdresBlokje == "FrontRightMiddle");
            int GEdge6i = lstBlokjes.IndexOf(GEdge6);
            Blokje GCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "FrontLeftDown");
            int GCorner7i = lstBlokjes.IndexOf(GCorner7);
            Blokje GEdge8 = lstBlokjes.Find(b => b.AdresBlokje == "FrontMiddleDown");
            int GEdge8i = lstBlokjes.IndexOf(GEdge8);
            Blokje GCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "FrontRightDown");
            int GCorner9i = lstBlokjes.IndexOf(GCorner9);

            //WHITE
            Blokje WCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "UpLeftDown");
            int WCorner7i = lstBlokjes.IndexOf(WCorner7);
            Blokje WEdge8 = lstBlokjes.Find(b => b.AdresBlokje == "UpMiddleDown");
            int WEdge8i = lstBlokjes.IndexOf(WEdge8);
            Blokje WCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "UpRightDown");
            int WCorner9i = lstBlokjes.IndexOf(WCorner9);

            //RED
            Blokje RCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "RightLeftUp");
            int RCorner1i = lstBlokjes.IndexOf(RCorner1);
            Blokje REdge4 = lstBlokjes.Find(b => b.AdresBlokje == "RightLeftMiddle");
            int REdge4i = lstBlokjes.IndexOf(REdge4);
            Blokje RCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "RightLeftDown");
            int RCorner7i = lstBlokjes.IndexOf(RCorner7);

            //YELLOW
            Blokje YCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "DownLeftUp");
            int YCorner1i = lstBlokjes.IndexOf(YCorner1);
            Blokje YEdge2 = lstBlokjes.Find(b => b.AdresBlokje == "DownMiddleUp");
            int YEdge2i = lstBlokjes.IndexOf(YEdge2);
            Blokje YCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "DownRightUp");
            int YCorner3i = lstBlokjes.IndexOf(YCorner3);

            //ORANGE
            Blokje OCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "LeftRightUp");
            int OCorner3i = lstBlokjes.IndexOf(OCorner3);
            Blokje OEdge6 = lstBlokjes.Find(b => b.AdresBlokje == "LeftRightMiddle");
            int OEdge6i = lstBlokjes.IndexOf(OEdge6);
            Blokje OCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "LeftRightDown");
            int OCorner9i = lstBlokjes.IndexOf(OCorner9);

            #endregion

            if (!isPrime)
            {
                //Met de klok mee
                #region Processing F
                //Groen Vlak draaien
                //Corners - GREEN
                string onthoud = GCorner1.AdresBlokje;
                GCorner1.AdresBlokje = GCorner3.AdresBlokje;
                GCorner3.AdresBlokje = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = onthoud;

                //Edges - GREEN
                onthoud = GEdge2.AdresBlokje;
                GEdge2.AdresBlokje = GEdge6.AdresBlokje;
                GEdge6.AdresBlokje = GEdge8.AdresBlokje;
                GEdge8.AdresBlokje = GEdge4.AdresBlokje;
                GEdge4.AdresBlokje = onthoud;

                //Zijkanten
                //Corner links 
                onthoud = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = RCorner1.AdresBlokje;
                RCorner1.AdresBlokje = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = onthoud;

                //Corner Rechts
                onthoud = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = OCorner3.AdresBlokje;
                OCorner3.AdresBlokje = onthoud;

                //Edges
                onthoud = WEdge8.AdresBlokje;
                WEdge8.AdresBlokje = REdge4.AdresBlokje;
                REdge4.AdresBlokje = YEdge2.AdresBlokje;
                YEdge2.AdresBlokje = OEdge6.AdresBlokje;
                OEdge6.AdresBlokje = onthoud;

                #endregion
            }
            else
            {
                //Tegen de klok in
                #region Processing F'
                //Groen Vlak draaien
                //Corners
                string onthoud = GCorner1.AdresBlokje;
                GCorner1.AdresBlokje = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = GCorner3.AdresBlokje;
                GCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = GEdge2.AdresBlokje;
                GEdge2.AdresBlokje = GEdge4.AdresBlokje;
                GEdge4.AdresBlokje = GEdge8.AdresBlokje;
                GEdge8.AdresBlokje = GEdge6.AdresBlokje;
                GEdge6.AdresBlokje = onthoud;

                //Zijkanten
                //Corner Links
                onthoud = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = OCorner3.AdresBlokje;
                OCorner3.AdresBlokje = onthoud;

                //Corner Rechts
                onthoud = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = RCorner1.AdresBlokje;
                RCorner1.AdresBlokje = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = onthoud;

                //Edges
                onthoud = YEdge2.AdresBlokje;
                YEdge2.AdresBlokje = REdge4.AdresBlokje;
                REdge4.AdresBlokje = WEdge8.AdresBlokje;
                WEdge8.AdresBlokje = OEdge6.AdresBlokje;
                OEdge6.AdresBlokje = onthoud;

                #endregion
            }

            //Maken van lijst voor de output
            #region List Maken

            lstBlokjes[GCorner1i] = GCorner1;
            lstBlokjes[GEdge2i] = GEdge2;
            lstBlokjes[GCorner3i] = GCorner3;
            lstBlokjes[GEdge4i] = GEdge4;
            lstBlokjes[GEdge6i] = GEdge6;
            lstBlokjes[GCorner7i] = GCorner7;
            lstBlokjes[GEdge8i] = GEdge8;
            lstBlokjes[GCorner9i] = GCorner9;
            lstBlokjes[WCorner7i] = WCorner7;
            lstBlokjes[WEdge8i] = WEdge8;
            lstBlokjes[WCorner9i] = WCorner9;
            lstBlokjes[RCorner1i] = RCorner1;
            lstBlokjes[REdge4i] = REdge4;
            lstBlokjes[RCorner7i] = RCorner7;
            lstBlokjes[YCorner1i] = YCorner1;
            lstBlokjes[YEdge2i] = YEdge2;
            lstBlokjes[YCorner3i] = YCorner3;
            lstBlokjes[OCorner3i] = OCorner3;
            lstBlokjes[OEdge6i] = OEdge6;
            lstBlokjes[OCorner9i] = OCorner9;

            #endregion

            //Output
            return lstBlokjes;
        }

        /// <summary>
        /// Draaien van de rechterzijde
        /// </summary>
        /// <param name="lstBlokjes">Lijst met blokjes</param>
        /// <param name="isPrime">True indie tegen de klok draaien</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> R(List<Blokje> lstBlokjes, bool isPrime)
        {
            #region Input

            //Rood - RECHTS
            Blokje RCorner1 = lstBlokjes.Find(r => r.AdresBlokje == "RightLeftUp");
            int RCorner1i = lstBlokjes.IndexOf(RCorner1);
            Blokje REdge2 = lstBlokjes.Find(r => r.AdresBlokje == "RightMiddleUp");
            int REdge2i = lstBlokjes.IndexOf(REdge2);
            Blokje RCorner3 = lstBlokjes.Find(r => r.AdresBlokje == "RightRightUp");
            int RCorner3i = lstBlokjes.IndexOf(RCorner3);
            Blokje REdge4 = lstBlokjes.Find(r => r.AdresBlokje == "RightLeftMiddle");
            int REdge4i = lstBlokjes.IndexOf(REdge4);
            Blokje REdge6 = lstBlokjes.Find(r => r.AdresBlokje == "RightRightMiddle");
            int REdge6i = lstBlokjes.IndexOf(REdge6);
            Blokje RCorner7 = lstBlokjes.Find(r => r.AdresBlokje == "RightLeftDown");
            int RCorner7i = lstBlokjes.IndexOf(RCorner7);
            Blokje REdge8 = lstBlokjes.Find(r => r.AdresBlokje == "RightMiddleDown");
            int REdge8i = lstBlokjes.IndexOf(REdge8);
            Blokje RCorner9 = lstBlokjes.Find(r => r.AdresBlokje == "RightRightDown");
            int RCorner9i = lstBlokjes.IndexOf(RCorner9);

            //Wit - UP
            Blokje WCorner3 = lstBlokjes.Find(r => r.AdresBlokje == "UpRightUp");
            int WCorner3i = lstBlokjes.IndexOf(WCorner3);
            Blokje WEdge6 = lstBlokjes.Find(r => r.AdresBlokje == "UpRightMiddle");
            int WEdge6i = lstBlokjes.IndexOf(WEdge6);
            Blokje WCorner9 = lstBlokjes.Find(r => r.AdresBlokje == "UpRightDown");
            int WCorner9i = lstBlokjes.IndexOf(WCorner9);

            //Blue - BACK
            Blokje BCorner1 = lstBlokjes.Find(r => r.AdresBlokje == "BackLeftUp");
            int BCorner1i = lstBlokjes.IndexOf(BCorner1);
            Blokje BEdge4 = lstBlokjes.Find(r => r.AdresBlokje == "BackLeftMiddle");
            int BEdge4i = lstBlokjes.IndexOf(BEdge4);
            Blokje BCorner7 = lstBlokjes.Find(r => r.AdresBlokje == "BackLeftDown");
            int BCorner7i = lstBlokjes.IndexOf(BCorner7);

            //Yellow - DOWN
            Blokje YCorner3 = lstBlokjes.Find(r => r.AdresBlokje == "DownRightUp");
            int YCorner3i = lstBlokjes.IndexOf(YCorner3);
            Blokje YEdge6 = lstBlokjes.Find(r => r.AdresBlokje == "DownRightMiddle");
            int YEdge6i = lstBlokjes.IndexOf(YEdge6);
            Blokje YCorner9 = lstBlokjes.Find(r => r.AdresBlokje == "DownRightDown");
            int YCorner9i = lstBlokjes.IndexOf(YCorner9);

            //Green - FRONT
            Blokje GCorner3 = lstBlokjes.Find(r => r.AdresBlokje == "FrontRightUp");
            int GCorner3i = lstBlokjes.IndexOf(GCorner3);
            Blokje GEdge6 = lstBlokjes.Find(r => r.AdresBlokje == "FrontRightMiddle");
            int GEdge6i = lstBlokjes.IndexOf(GEdge6);
            Blokje GCorner9 = lstBlokjes.Find(r => r.AdresBlokje == "FrontRightDown");
            int GCorner9i = lstBlokjes.IndexOf(GCorner9);

            #endregion

            if (!isPrime)
            {
                //Draaien met de klok mee
                #region Processing R

                //Rood vlak draaien
                //Corners
                string onthoud = RCorner1.AdresBlokje;
                RCorner1.AdresBlokje = RCorner3.AdresBlokje;
                RCorner3.AdresBlokje = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = onthoud;

                //Edges
                onthoud = REdge2.AdresBlokje;
                REdge2.AdresBlokje = REdge6.AdresBlokje;
                REdge6.AdresBlokje = REdge8.AdresBlokje;
                REdge8.AdresBlokje = REdge4.AdresBlokje;
                REdge4.AdresBlokje = onthoud;

                //Zijkanten
                //Corner Boven
                onthoud = GCorner3.AdresBlokje;
                GCorner3.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = onthoud;

                //Corner Onder
                onthoud = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = BCorner1.AdresBlokje;
                BCorner1.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = onthoud;

                //Edges
                onthoud = GEdge6.AdresBlokje;
                GEdge6.AdresBlokje = WEdge6.AdresBlokje;
                WEdge6.AdresBlokje = BEdge4.AdresBlokje;
                BEdge4.AdresBlokje = YEdge6.AdresBlokje;
                YEdge6.AdresBlokje = onthoud;

                #endregion
            }
            else
            {
                //Draaien tegen de klok in
                #region Processing R'

                //Rood vlak draaien
                //Corners
                string onthoud = RCorner1.AdresBlokje;
                RCorner1.AdresBlokje = RCorner7.AdresBlokje;
                RCorner7.AdresBlokje = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = RCorner3.AdresBlokje;
                RCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = REdge2.AdresBlokje;
                REdge2.AdresBlokje = REdge4.AdresBlokje;
                REdge4.AdresBlokje = REdge8.AdresBlokje;
                REdge8.AdresBlokje = REdge6.AdresBlokje;
                REdge6.AdresBlokje = onthoud;

                //Zijkant
                //Corner Boven
                onthoud = GCorner3.AdresBlokje;
                GCorner3.AdresBlokje = YCorner3.AdresBlokje;
                YCorner3.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = onthoud;

                //Corner onder
                onthoud = GCorner9.AdresBlokje;
                GCorner9.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = BCorner1.AdresBlokje;
                BCorner1.AdresBlokje = WCorner9.AdresBlokje;
                WCorner9.AdresBlokje = onthoud;

                //Edge
                onthoud = GEdge6.AdresBlokje;
                GEdge6.AdresBlokje = YEdge6.AdresBlokje;
                YEdge6.AdresBlokje = BEdge4.AdresBlokje;
                BEdge4.AdresBlokje = WEdge6.AdresBlokje;
                WEdge6.AdresBlokje = onthoud;

                #endregion
            }

            #region Lijst Maken

            lstBlokjes[RCorner1i] = RCorner1;
            lstBlokjes[REdge2i] = REdge2;
            lstBlokjes[RCorner3i] = RCorner3;
            lstBlokjes[REdge4i] = REdge4;
            lstBlokjes[REdge6i] = REdge6;
            lstBlokjes[RCorner7i] = RCorner7;
            lstBlokjes[REdge8i] = REdge8;
            lstBlokjes[RCorner9i] = RCorner9;
            lstBlokjes[WCorner3i] = WCorner3;
            lstBlokjes[WEdge6i] = WEdge6;
            lstBlokjes[WCorner9i] = WCorner9;
            lstBlokjes[BCorner1i] = BCorner1;
            lstBlokjes[BEdge4i] = BEdge4;
            lstBlokjes[BCorner7i] = BCorner7;
            lstBlokjes[YCorner3i] = YCorner3;
            lstBlokjes[YEdge6i] = YEdge6;
            lstBlokjes[YCorner9i] = YCorner9;
            lstBlokjes[GCorner3i] = GCorner3;
            lstBlokjes[GEdge6i] = GEdge6;
            lstBlokjes[GCorner9i] = GCorner9;

            #endregion

            return lstBlokjes;
        }

        /// <summary>
        /// Draaien van de achterste laag
        /// </summary>
        /// <param name="lstBlokjes">Lijst let blokjes</param>
        /// <param name="isPrime">True indien draaien tegen de klok</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> B(List<Blokje> lstBlokjes, bool isPrime)
        {
            #region Input
            //Blue - BACK
            Blokje BCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "BackLeftUp");
            int BCorner1i = lstBlokjes.IndexOf(BCorner1);
            Blokje BEdge2 = lstBlokjes.Find(b => b.AdresBlokje == "BackMiddleUp");
            int BEdge2i = lstBlokjes.IndexOf(BEdge2);
            Blokje BCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "BackRightUp");
            int BCorner3i = lstBlokjes.IndexOf(BCorner3);
            Blokje BEdge4 = lstBlokjes.Find(b => b.AdresBlokje == "BackLeftMiddle");
            int BEdge4i = lstBlokjes.IndexOf(BEdge4);
            Blokje BEdge6 = lstBlokjes.Find(b => b.AdresBlokje == "BackRightMiddle");
            int BEdge6i = lstBlokjes.IndexOf(BEdge6);
            Blokje BCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "BackLeftDown");
            int BCorner7i = lstBlokjes.IndexOf(BCorner7);
            Blokje BEdge8 = lstBlokjes.Find(b => b.AdresBlokje == "BackMiddleDown");
            int BEdge8i = lstBlokjes.IndexOf(BEdge8);
            Blokje BCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "BackRightDown");
            int BCorner9i = lstBlokjes.IndexOf(BCorner9);

            //White - UP
            Blokje WCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "UpLeftUp");
            int WCorner1i = lstBlokjes.IndexOf(WCorner1);
            Blokje WEdge2 = lstBlokjes.Find(b => b.AdresBlokje == "UpMiddleUp");
            int WEdge2i = lstBlokjes.IndexOf(WEdge2);
            Blokje WCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "UpRightUp");
            int WCorner3i = lstBlokjes.IndexOf(WCorner3);

            //Red - RIGHT
            Blokje RCorner3 = lstBlokjes.Find(b => b.AdresBlokje == "RightRightUp");
            int RCorner3i = lstBlokjes.IndexOf(RCorner3);
            Blokje REdge6 = lstBlokjes.Find(b => b.AdresBlokje == "RightRightMiddle");
            int REdge6i = lstBlokjes.IndexOf(REdge6);
            Blokje RCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "RightRightDown");
            int RCorner9i = lstBlokjes.IndexOf(RCorner9);

            //Orange - LEFT
            Blokje OCorner1 = lstBlokjes.Find(b => b.AdresBlokje == "LeftLeftUp");
            int OCorner1i = lstBlokjes.IndexOf(OCorner1);
            Blokje OEdge4 = lstBlokjes.Find(b => b.AdresBlokje == "LeftLeftMiddle");
            int OEdge4i = lstBlokjes.IndexOf(OEdge4);
            Blokje OCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "LeftLeftDown");
            int OCorner7i = lstBlokjes.IndexOf(OCorner7);

            //Yellow - DOWN
            Blokje YCorner7 = lstBlokjes.Find(b => b.AdresBlokje == "DownLeftDown");
            int YCorner7i = lstBlokjes.IndexOf(YCorner7);
            Blokje YEdge8 = lstBlokjes.Find(b => b.AdresBlokje == "DownMiddleDown");
            int YEdge8i = lstBlokjes.IndexOf(YEdge8);
            Blokje YCorner9 = lstBlokjes.Find(b => b.AdresBlokje == "DownRightDown");
            int YCorner9i = lstBlokjes.IndexOf(YCorner9);

            #endregion

            if (!isPrime)
            {
                //Draaien met de klok mee
                #region Processing B
                //Blauw vlak draaien
                //Corners
                string onthoud = BCorner1.AdresBlokje;
                BCorner1.AdresBlokje = BCorner3.AdresBlokje;
                BCorner3.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = onthoud;

                //Edges
                onthoud = BEdge2.AdresBlokje;
                BEdge2.AdresBlokje = BEdge6.AdresBlokje;
                BEdge6.AdresBlokje = BEdge8.AdresBlokje;
                BEdge8.AdresBlokje = BEdge4.AdresBlokje;
                BEdge4.AdresBlokje = onthoud;

                //Zijkanten
                //Bovenste Corner
                onthoud = RCorner3.AdresBlokje;
                RCorner3.AdresBlokje = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = onthoud;

                //Onderste Corner
                onthoud = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = OCorner1.AdresBlokje;
                OCorner1.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = onthoud;

                //Edge
                onthoud = REdge6.AdresBlokje;
                REdge6.AdresBlokje = WEdge2.AdresBlokje;
                WEdge2.AdresBlokje = OEdge4.AdresBlokje;
                OEdge4.AdresBlokje = YEdge8.AdresBlokje;
                YEdge8.AdresBlokje = onthoud;

                #endregion
            }
            else
            {
                //Draaien tegen de klok
                #region Processing B'
                //Blauw vlak draaien
                //Corners
                string onthoud = BCorner1.AdresBlokje;
                BCorner1.AdresBlokje = BCorner7.AdresBlokje;
                BCorner7.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = BCorner3.AdresBlokje;
                BCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = BEdge2.AdresBlokje;
                BEdge2.AdresBlokje = BEdge4.AdresBlokje;
                BEdge4.AdresBlokje = BEdge8.AdresBlokje;
                BEdge8.AdresBlokje = BEdge6.AdresBlokje;
                BEdge6.AdresBlokje = onthoud;

                //Zijkanten
                //Corner boven
                onthoud = RCorner3.AdresBlokje;
                RCorner3.AdresBlokje = YCorner9.AdresBlokje;
                YCorner9.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = onthoud;

                //Corner onder
                onthoud = RCorner9.AdresBlokje;
                RCorner9.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = OCorner1.AdresBlokje;
                OCorner1.AdresBlokje = WCorner3.AdresBlokje;
                WCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = REdge6.AdresBlokje;
                REdge6.AdresBlokje = YEdge8.AdresBlokje;
                YEdge8.AdresBlokje = OEdge4.AdresBlokje;
                OEdge4.AdresBlokje = WEdge2.AdresBlokje;
                WEdge2.AdresBlokje = onthoud;
                #endregion
            }

            #region Lijst Maken

            lstBlokjes[BCorner1i] = BCorner1;
            lstBlokjes[BEdge2i] = BEdge2;
            lstBlokjes[BCorner3i] = BCorner3;
            lstBlokjes[BEdge4i] = BEdge4;
            lstBlokjes[BEdge6i] = BEdge6;
            lstBlokjes[BCorner7i] = BCorner7;
            lstBlokjes[BEdge8i] = BEdge8;
            lstBlokjes[BCorner9i] = BCorner9;
            lstBlokjes[WCorner1i] = WCorner1;
            lstBlokjes[WEdge2i] = WEdge2;
            lstBlokjes[WCorner3i] = WCorner3;
            lstBlokjes[RCorner3i] = RCorner3;
            lstBlokjes[REdge6i] = REdge6;
            lstBlokjes[RCorner9i] = RCorner9;
            lstBlokjes[OCorner1i] = OCorner1;
            lstBlokjes[OEdge4i] = OEdge4;
            lstBlokjes[OCorner7i] = OCorner7;
            lstBlokjes[YCorner7i] = YCorner7;
            lstBlokjes[YEdge8i] = YEdge8;
            lstBlokjes[YCorner9i] = YCorner9;

            #endregion

            return lstBlokjes;
        }

        /// <summary>
        /// Draaien van de linker laag
        /// </summary>
        /// <param name="lstBlokjes">Lijst van blokjes</param>
        /// <param name="isPrime">True indien tegen de klok draaien</param>
        /// <returns>Aangepaste lijst van blokjes</returns>
        public static List<Blokje> L(List<Blokje> lstBlokjes, bool isPrime)
        {
            #region Input
            //Orange - LEFT
            Blokje OCorner1 = lstBlokjes.Find(o => o.AdresBlokje == "LeftLeftUp");
            int OCorner1i = lstBlokjes.IndexOf(OCorner1);
            Blokje OEdge2 = lstBlokjes.Find(o => o.AdresBlokje == "LeftMiddleUp");
            int OEdge2i = lstBlokjes.IndexOf(OEdge2);
            Blokje OCorner3 = lstBlokjes.Find(o => o.AdresBlokje == "LeftRightUp");
            int OCorner3i = lstBlokjes.IndexOf(OCorner3);
            Blokje OEdge4 = lstBlokjes.Find(o => o.AdresBlokje == "LeftLeftMiddle");
            int OEdge4i = lstBlokjes.IndexOf(OEdge4);
            Blokje OEdge6 = lstBlokjes.Find(o => o.AdresBlokje == "LeftRightMiddle");
            int OEdge6i = lstBlokjes.IndexOf(OEdge6);
            Blokje OCorner7 = lstBlokjes.Find(o => o.AdresBlokje == "LeftLeftDown");
            int OCorner7i = lstBlokjes.IndexOf(OCorner7);
            Blokje OEdge8 = lstBlokjes.Find(o => o.AdresBlokje == "LeftMiddleDown");
            int OEdge8i = lstBlokjes.IndexOf(OEdge8);
            Blokje OCorner9 = lstBlokjes.Find(o => o.AdresBlokje == "LeftRightDown");
            int OCorner9i = lstBlokjes.IndexOf(OCorner9);

            //Yellow - DOWN
            Blokje YCorner1 = lstBlokjes.Find(o => o.AdresBlokje == "DownLeftUp");
            int YCorner1i = lstBlokjes.IndexOf(YCorner1);
            Blokje YEdge4 = lstBlokjes.Find(o => o.AdresBlokje == "DownLeftMiddle");
            int YEdge4i = lstBlokjes.IndexOf(YEdge4);
            Blokje YCorner7 = lstBlokjes.Find(o => o.AdresBlokje == "DownLeftDown");
            int YCorner7i = lstBlokjes.IndexOf(YCorner7);

            //Green - FRONT
            Blokje GCorner1 = lstBlokjes.Find(o => o.AdresBlokje == "FrontLeftUp");
            int GCorner1i = lstBlokjes.IndexOf(GCorner1);
            Blokje GEdge4 = lstBlokjes.Find(o => o.AdresBlokje == "FrontLeftMiddle");
            int GEdge4i = lstBlokjes.IndexOf(GEdge4);
            Blokje GCorner7 = lstBlokjes.Find(o => o.AdresBlokje == "FrontLeftDown");
            int GCorner7i = lstBlokjes.IndexOf(GCorner7);

            //White - UP
            Blokje WCorner1 = lstBlokjes.Find(o => o.AdresBlokje == "UpLeftUp");
            int WCorner1i = lstBlokjes.IndexOf(WCorner1);
            Blokje WEdge4 = lstBlokjes.Find(o => o.AdresBlokje == "UpLeftMiddle");
            int WEdge4i = lstBlokjes.IndexOf(WEdge4);
            Blokje WCorner7= lstBlokjes.Find(o => o.AdresBlokje == "UpLeftDown");
            int WCorner7i = lstBlokjes.IndexOf(WCorner7);

            //Blue - BACK
            Blokje BCorner3 = lstBlokjes.Find(o => o.AdresBlokje == "BackRightUp");
            int BCorner3i = lstBlokjes.IndexOf(BCorner3);
            Blokje BEdge6 = lstBlokjes.Find(o => o.AdresBlokje == "BackRightMiddle");
            int BEdge6i = lstBlokjes.IndexOf(BEdge6);
            Blokje BCorner9 = lstBlokjes.Find(o => o.AdresBlokje == "BackRightDown");
            int BCorner9i = lstBlokjes.IndexOf(BCorner9);

            #endregion

            if (!isPrime)
            {
                #region Processing L

                //Oranje vlak draaien
                //Corners
                string onthoud = OCorner1.AdresBlokje;
                OCorner1.AdresBlokje = OCorner3.AdresBlokje;
                OCorner3.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = onthoud;

                //Edges - OREEN
                onthoud = OEdge2.AdresBlokje;
                OEdge2.AdresBlokje = OEdge6.AdresBlokje;
                OEdge6.AdresBlokje = OEdge8.AdresBlokje;
                OEdge8.AdresBlokje = OEdge4.AdresBlokje;
                OEdge4.AdresBlokje = onthoud;

                //Zijkanten
                //Corners 1
                onthoud = GCorner1.AdresBlokje;
                GCorner1.AdresBlokje = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = onthoud;

                //Corners 3
                onthoud = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = BCorner3.AdresBlokje;
                BCorner3.AdresBlokje = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = onthoud;

                //Edge
                onthoud = GEdge4.AdresBlokje;
                GEdge4.AdresBlokje = YEdge4.AdresBlokje;
                YEdge4.AdresBlokje = BEdge6.AdresBlokje;
                BEdge6.AdresBlokje = WEdge4.AdresBlokje;
                WEdge4.AdresBlokje = onthoud;

                #endregion
            }
            else
            {
                #region Processing L'

                //Oranje vlak draaien
                //Corners
                string onthoud = OCorner1.AdresBlokje;
                OCorner1.AdresBlokje = OCorner7.AdresBlokje;
                OCorner7.AdresBlokje = OCorner9.AdresBlokje;
                OCorner9.AdresBlokje = OCorner3.AdresBlokje;
                OCorner3.AdresBlokje = onthoud;

                //Edge
                onthoud = OEdge2.AdresBlokje;
                OEdge2.AdresBlokje = OEdge4.AdresBlokje;
                OEdge4.AdresBlokje = OEdge8.AdresBlokje;
                OEdge8.AdresBlokje = OEdge6.AdresBlokje;
                OEdge6.AdresBlokje = onthoud;

                //Zijkanten
                //Corner 1
                onthoud = GCorner1.AdresBlokje;
                GCorner1.AdresBlokje = WCorner1.AdresBlokje;
                WCorner1.AdresBlokje = BCorner9.AdresBlokje;
                BCorner9.AdresBlokje = YCorner1.AdresBlokje;
                YCorner1.AdresBlokje = onthoud;

                //Corner 7
                onthoud = GCorner7.AdresBlokje;
                GCorner7.AdresBlokje = WCorner7.AdresBlokje;
                WCorner7.AdresBlokje = BCorner3.AdresBlokje;
                BCorner3.AdresBlokje = YCorner7.AdresBlokje;
                YCorner7.AdresBlokje = onthoud;

                //Edge
                onthoud = GEdge4.AdresBlokje;
                GEdge4.AdresBlokje = WEdge4.AdresBlokje;
                WEdge4.AdresBlokje = BEdge6.AdresBlokje;
                BEdge6.AdresBlokje = YEdge4.AdresBlokje;
                YEdge4.AdresBlokje = onthoud;

                #endregion
            }

            #region List Maken

            lstBlokjes[OCorner1i] = OCorner1;
            lstBlokjes[OEdge2i] = OEdge2;
            lstBlokjes[OCorner3i] = OCorner3;
            lstBlokjes[OEdge4i] = OEdge4;
            lstBlokjes[OEdge6i] = OEdge6;
            lstBlokjes[OCorner7i] = OCorner7;
            lstBlokjes[OEdge8i] = OEdge8;
            lstBlokjes[OCorner9i] = OCorner9;
            lstBlokjes[YCorner1i] = YCorner1;
            lstBlokjes[YEdge4i] = YEdge4;
            lstBlokjes[YCorner7i] = YCorner7;
            lstBlokjes[GCorner1i] = GCorner1;
            lstBlokjes[GEdge4i] = GEdge4;
            lstBlokjes[GCorner7i] = GCorner7;
            lstBlokjes[WCorner1i] = WCorner1;
            lstBlokjes[WEdge4i] = WEdge4;
            lstBlokjes[WCorner7i] = WCorner7;
            lstBlokjes[BCorner3i] = BCorner3;
            lstBlokjes[BEdge6i] = BEdge6;
            lstBlokjes[BCorner9i] = BCorner9;

            #endregion

            return lstBlokjes;
        }
    }
}