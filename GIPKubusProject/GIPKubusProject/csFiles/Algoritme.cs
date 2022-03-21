using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GIPKubusProject.Kleuren_blokjes;

using System.Drawing;

using GIPKubusProject;
using System.Security.Policy;
using System.Security;
using System.Diagnostics;

namespace GIPKubusProject
{
    public class Algoritme
    {
        //Het maken van het kruis
        #region Cross


        //Het kruis is geel omdat het anders ingewikeld word voor de adressen
        public static string[] MaakKruisGeelGroen(List<Blokje> blokjes)
        {
            //Declaratie
            //OutpurArray
            List<string> outputArray = new List<string>();
            //Blokje
            EdgesKleur geelGroen = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "joker"), blokjes.Find(x => x.OorspronkelijkAdres == "joker")); //test waarde indien niet gelukt

            //Input
            geelGroen = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "DownMiddleUp"), blokjes.Find(x => x.OorspronkelijkAdres == "FrontMiddleDown"));

            #region Processing

            //groenWit
            //CASE Beneden Goed gedraaid
            //if (geelGroen.BlokjeKleurEdge1.AdresBlokje == geelGroen.BlokjeKleurEdge1.OorspronkelijkAdres)/* → Doe niets*/
            //    outputArray.Add("D'");



            //DIT ZIJN DE EERSTE TWEE DAT ALTIJD BLEVEN HANGEN OMDAT DIT ALGORITME NIET JUIST IS (MSS OOK BIJ F2L).
            if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "FrontRightMiddle")
            {
                outputArray = AddMul(outputArray, "R", "U", "R'", "F", "F");
            }

            else if (geelGroen.BlokjeKleurEdge2.AdresBlokje == "FrontRightMiddle")
            {
                outputArray = AddMul(outputArray, "F");
            }

            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "DownRightMiddle")
                outputArray = AddMul(outputArray, "D'", "F", "D", "F'");




            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "LeftLeftMiddle")
                outputArray = AddMul(outputArray, "L", "L", "F'");




            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "DownMiddleDown")
                outputArray = AddMul(outputArray, "D", "D", "F", "D", "D", "F'");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "DownLeftMiddle")
                outputArray = AddMul(outputArray, "D", "F", "D'", "F'");

            //CASE beneden niet goed gedraaid
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "FrontMiddleDown")
                outputArray = AddMul(outputArray, "F", "F", "U'", "R'", "F", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "RightMiddleDown")
                outputArray = AddMul(outputArray, "R", "F", "R'");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "BackMiddleDown")
                outputArray = AddMul(outputArray, "B", "B", "U", "R'", "F", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "LeftMiddleDown")
                outputArray = AddMul(outputArray, "L'", "F'", "L");

            //CASE Boven Goed gedraaid → Naar boven gericht
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "UpMiddleDown")
                outputArray = AddMul(outputArray, "F", "F");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "UpRightMiddle")
                outputArray = AddMul(outputArray, "U", "F", "F");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "UpMiddleUp")
                outputArray = AddMul(outputArray, "U", "U", "F", "F");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "UpLeftMiddle")
                outputArray = AddMul(outputArray, "U'", "F", "F");


            //CASE Boven niet goed gedraaid
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "FrontMiddleUp")
                outputArray = AddMul(outputArray, "U'", "R'", "F", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "RightMiddleUp")
                outputArray = AddMul(outputArray, "R'", "F", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "BackMiddleUp")
                outputArray = AddMul(outputArray, "U", "R'", "F", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "LeftMiddleUp")
                outputArray = AddMul(outputArray, "L", "F'", "L'");


            //CASE Middelste laag

            //Groen en Rood
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "FrontRightMiddle")
                outputArray = AddMul(outputArray, "R", "U", "R'", "F", "F");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "RightLeftMiddle")
                outputArray = AddMul(outputArray, "F", "");


            //Groen en Oranje
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "FrontLeftMiddle")
                outputArray = AddMul(outputArray, "L'", "U'", "L", "F", "F");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "LeftRightMiddle")
                outputArray.Add("F'");


            //Blauw en Rood
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "RightRightMiddle")
                outputArray = AddMul(outputArray, "R", "R", "F", "R", "R");
            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "BackLeftMiddle")
                outputArray = AddMul(outputArray, "R'", "U", "R", "F", "F");

            //Blauw en Oranje

            else if (geelGroen.BlokjeKleurEdge1.AdresBlokje == "BackRightMiddle")
                outputArray = AddMul(outputArray, "L", "U'", "L'", "F", "F");
            #endregion


            //output
            //Lijst omzetten
            string[] arr = outputArray.ToArray();
            return arr;
        }

        public static string[] MaakKruisGeelOranje(List<Blokje> blokjes)
        {
            //Declaratie
            //OutpurArray
            List<string> outputArray = new List<string>();
            //Blokje
            EdgesKleur geelOranje = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "joker"), blokjes.Find(x => x.OorspronkelijkAdres == "joker")); //test waarde indien niet gelukt

            //Input
            geelOranje = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "DownLeftMiddle"), blokjes.Find(x => x.OorspronkelijkAdres == "LeftMiddleDown"));

            #region Processing

            //CASE Beneden Goed gedraaid
            if (geelOranje.BlokjeKleurEdge2.AdresBlokje == "RightMiddleDown")
                outputArray = AddMul(outputArray, "R", "R", "U", "U", "L", "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "BackMiddleDown")
                outputArray = AddMul(outputArray, "B'", "L'");



            //CASE beneden niet goed gedraaid
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "RightMiddleDown")
                outputArray = AddMul(outputArray, "R", "R", "U", "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge2.AdresBlokje == "BackMiddleDown")
                outputArray = AddMul(outputArray, "B", "B", "U'", "L", "L");
            else if (geelOranje.BlokjeKleurEdge2.AdresBlokje == "DownLeftMiddle")
                outputArray = AddMul(outputArray, "L", "L", "U'", "F'", "L", "F");

            //CASE Boven Goed gedraaid → Naar boven gericht
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "UpMiddleDown")
                outputArray = AddMul(outputArray, "U", "L", "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "UpRightMiddle")
                outputArray = AddMul(outputArray, "U", "U", "L", "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "UpMiddleUp")
                outputArray = AddMul(outputArray, "U'", "L", "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "UpLeftMiddle")
                outputArray = AddMul(outputArray, "L", "L");


            //CASE Boven niet goed gedraaid
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "FrontMiddleUp")
                outputArray = AddMul(outputArray, "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "RightMiddleUp")
                outputArray = AddMul(outputArray, "U", "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "BackMiddleUp")
                outputArray = AddMul(outputArray, "U", "U", "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "LeftMiddleUp")
                outputArray = AddMul(outputArray, "U'", "F'", "L", "F");


            //CASE Middelste laag

            //Groen en Rood
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "FrontRightMiddle")
                outputArray = AddMul(outputArray, "R", "U", "U", "R'", "L", "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "RightLeftMiddle")
                outputArray = AddMul(outputArray, "F'", "U", "F", "L", "L");

            //Groen en Oranje
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "FrontLeftMiddle")
                outputArray = AddMul(outputArray, "L");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "LeftRightMiddle")
                outputArray = AddMul(outputArray, "L'", "U'", "L", "F'", "L", "F");


            //Blauw en Rood
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "RightRightMiddle")
                outputArray = AddMul(outputArray, "R'", "U", "R", "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "BackLeftMiddle")
                outputArray = AddMul(outputArray, "B", "U", "U", "B'", "F'", "L", "F");

            //Blauw en Oranje
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "LeftLeftMiddle")
                outputArray = AddMul(outputArray, "L", "U'", "L'", "F'", "L", "F");
            else if (geelOranje.BlokjeKleurEdge1.AdresBlokje == "BackRightMiddle")
                outputArray = AddMul(outputArray, "L'");


            #endregion

            //Lijst omzetten
            string[] arr = outputArray.ToArray();
            return arr;
        }

        public static string[] MaakKruisGeelRood(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();

            EdgesKleur geelRood = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "joker"), blokjes.Find(x => x.OorspronkelijkAdres == "joker")); //test waarde indien niet gelukt

            geelRood = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "DownRightMiddle"), blokjes.Find(x => x.OorspronkelijkAdres == "RightMiddleDown"));



            #region Processing



            if (geelRood.BlokjeKleurEdge1.AdresBlokje == "DownRightMiddle")
                outputArray.Add("");

            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "LeftLeftMiddle")
                outputArray = AddMul(outputArray, "L", "U'", "L'", "F", "R'", "F'");

            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "DownMiddleDown")
                outputArray = AddMul(outputArray, "B", "B", "U", "R", "R");


            ////CASE beneden niet goed gedraaid

            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "RightMiddleDown")
                outputArray = AddMul(outputArray, "R", "R", "U", "F", "R'", "F'");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "BackMiddleDown")
                outputArray = AddMul(outputArray, "B", "B", "U", "U", "F", "R'", "F'");


            ////CASE Boven Goed gedraaid → Naar boven gericht
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "UpMiddleDown")
                outputArray = AddMul(outputArray, "U'", "R", "R");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "UpRightMiddle")
                outputArray = AddMul(outputArray, "R", "R");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "UpMiddleUp")
                outputArray = AddMul(outputArray, "U", "R", "R");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "UpLeftMiddle")
                outputArray = AddMul(outputArray, "U", "U", "R", "R");


            ////CASE Boven niet goed gedraaid
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "FrontMiddleUp")
                outputArray = AddMul(outputArray, "F", "R'", "F'");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "RightMiddleUp")
                outputArray = AddMul(outputArray, "U", "F", "R'", "F'");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "BackMiddleUp")
                outputArray = AddMul(outputArray, "U", "U", "F", "R'", "F'");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "LeftMiddleUp")
                outputArray = AddMul(outputArray, "U'", "F", "R'", "F'");


            ////CASE Middelste laag

            ////Groen en Rood
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "FrontRightMiddle")
                outputArray = AddMul(outputArray, "R'");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "RightLeftMiddle")
                outputArray = AddMul(outputArray, "R", "U", "R'", "F", "R'", "F'");

            ////Groen en Oranje
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "FrontLeftMiddle")
                outputArray = AddMul(outputArray, "L'", "U'", "U'", "L", "R", "R");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "LeftRightMiddle")
                outputArray = AddMul(outputArray, "L'", "U'", "L", "F", "R'", "F'");



            ////Blauw en Rood
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "RightRightMiddle")
                outputArray = AddMul(outputArray, "B", "U", "R", "R");
            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "BackLeftMiddle")
                outputArray = AddMul(outputArray, "R");

            ////Blauw en Oranje

            else if (geelRood.BlokjeKleurEdge1.AdresBlokje == "BackRightMiddle")
                outputArray = AddMul(outputArray, "L", "U", "L'", "U", "R", "R");


            #endregion



            string[] arr = outputArray.ToArray();
            return arr;
        }

        public static string[] MaakKruisGeelBlauw(List<Blokje> blokjes)
        {
            //Declaratie
            //OutpurArray
            List<string> outputArray = new List<string>();
            //Blokje
            EdgesKleur geelBlauw = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "joker"), blokjes.Find(x => x.OorspronkelijkAdres == "joker")); //test waarde indien niet gelukt

            //Input
            geelBlauw = new EdgesKleur(blokjes.Find(x => x.OorspronkelijkAdres == "DownMiddleDown"), blokjes.Find(x => x.OorspronkelijkAdres == "BackMiddleDown"));

            #region   processing

            //Beneden goed gedraaid → geel Onder
            //Bestaat nimeer wegens alles gevuld

            //Beneden niet goed gedraaid → Geel zijkant
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "BackMiddleDown")
                outputArray = AddMul(outputArray, "B", "B", "U", "R", "B'", "R'");

            //Boven goed gedraaid (Geel vanboven)
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "UpMiddleUp")
                outputArray = AddMul(outputArray, "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "UpRightMiddle")
                outputArray = AddMul(outputArray, "U'", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "UpMiddleDown")
                outputArray = AddMul(outputArray, "U", "U", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "UpLeftMiddle")
                outputArray = AddMul(outputArray, "U", "B", "B");


            //Niet goed gedraaid
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "BackMiddleUp")
                outputArray = AddMul(outputArray, "U'", "L'", "B", "L");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "RightMiddleUp")
                outputArray = AddMul(outputArray, "U'", "U'", "L'", "B", "L");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "FrontMiddleUp")
                outputArray = AddMul(outputArray, "U", "L'", "B", "L");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "LeftMiddleUp")
                outputArray = AddMul(outputArray, "L'", "B", "L");


            //Boven: Niet goed gedraaid
            //Zijkanten 
            //Blauw rood
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "BackLeftMiddle")
                outputArray = AddMul(outputArray, "R'", "U'", "R", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "RightRightMiddle")
                outputArray = AddMul(outputArray, "B'");

            //Rood Groen
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "RightLeftMiddle")
                outputArray = AddMul(outputArray, "F'", "U'", "F", "U'", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "FrontRightMiddle")
                outputArray = AddMul(outputArray, "R", "U'", "R'", "B", "B");

            //Oranje Groen
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "FrontLeftMiddle")
                outputArray = AddMul(outputArray, "L'", "U", "L", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "LeftRightMiddle")
                outputArray = AddMul(outputArray, "F", "U", "U", "F'", "B", "B");

            //Blauw oranje
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "BackRightMiddle")
                outputArray = AddMul(outputArray, "L", "U", "L'", "B", "B");
            if (geelBlauw.BlokjeKleurEdge1.AdresBlokje == "LeftLeftMiddle")
                outputArray = AddMul(outputArray, "B");

            #endregion

            //Output
            return outputArray.ToArray();
        }




        #endregion

        //Het vervoledigen van het vak
        #region Hoekjes kruis


        public static string[] MaakCorners(List<Blokje> blokjes, string waar)
        {
            int itest = 0;
            foreach (var item in blokjes)
            {
                if (item.OorspronkelijkAdres == "DownRightUp")
                {
                    itest++;
                }
            }


            List<string> outputArray = new List<string>();
            Blokje geel = blokjes.Find(b => b.OorspronkelijkAdres == waar);


            //Standaarden
            if ("UpRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }
            else if ("FrontRightUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "R'", "F", "R", "F'");
            }
            else if ("RightLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "F", "R'", "F'", "R");
            }


            //UP
            //Kan ook gecontrolleerd worden met 1 blokje, dat is minder code
            else if ("UpRightUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }
            else if ("UpLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U'", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }
            else if ("UpLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "U", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }


            //FRONT

            else if ("FrontLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U'", "F", "R'", "F'", "R");
            }
            else if ("FrontRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U", "R", "U'", "R'");
            }
            else if ("FrontLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "L'", "U'", "L", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }


            //RIGHT
            else if ("RightRightUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "R'", "F", "R", "F'");
            }


            else if ("RightRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B", "U", "B'", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }
            else if ("RightLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "R", "U", "R'", "U'", "F", "R'", "F'", "R");
            }



            //LEFT
            else if ("LeftRightUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U'", "R'", "F", "R", "F'");
            }


            else if ("LeftRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "L'", "U'", "L", "R'", "F", "R", "F'");
            }

            else if ("LeftLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "U", "F", "R'", "F'", "R");
            }
            else if ("LeftLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B'", "U'", "B", "U'", "R", "U", "U", "R'", "U'", "R", "U", "R'");
            }



            //Down
            else if ("DownLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "L'", "U", "L", "F", "R'", "F'", "R");
            }
            else if ("DownLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B'", "U'", "B", "U'", "F", "R'", "F'", "R"); //TEST
            }

            else if ("DownRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B", "U", "B'", "R'", "F", "R", "F'");
            }


            //Back
            else if ("BackLeftUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "F", "R'", "F'", "R");
            }
            else if ("BackRightUp" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "U", "U", "R'", "F", "R", "F'");
            }
            else if ("BackRightDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B'", "U'", "B", "U'", "R'", "F", "R", "F'"); //NU
            }
            else if ("BackLeftDown" == geel.AdresBlokje)
            {
                outputArray = AddMul(outputArray, "B", "U", "B'", "U", "F", "R'", "F'", "R");
            }



            string[] arr = outputArray.ToArray();
            return arr;
        }




        #endregion

        //De eerste rijen
        #region F2L

        public static string[] MaakF2LBlauwRood(List<Blokje> blokjes)
        {
            //Input
            List<string> outputArray = new List<string>();
            Blokje blauw = blokjes.Find(b => b.OorspronkelijkAdres == "BackLeftMiddle");
            Blokje rood = blokjes.Find(b => b.OorspronkelijkAdres == "RightRightMiddle");
            bool moetGoedzettenBlauw = false, moetGoedzettenRood = false; //Boolean voor in 1 keer korten

            //Bovenste laag goed gedraaid (blauw vanvoor)
            if (blauw.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "R'", "U", "R", "U", "B", "U'", "B'");
            }
            else if (blauw.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "R'", "U", "R", "U", "B", "U'", "B'");
            }
            else if (blauw.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "R'", "U", "R", "U", "B", "U'", "B'");
            }
            else if (blauw.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R'", "U", "R", "U", "B", "U'", "B'");
            }

            //Bovenste laag rood vanvoor
            else if (rood.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "B", "U'", "B'", "U'", "R'", "U", "R");
            }
            else if (rood.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "B", "U'", "B'", "U'", "R'", "U", "R");
            }
            else if (rood.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "B", "U'", "B'", "U'", "R'", "U", "R");
            }
            else if (rood.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "B", "U'", "B'", "U'", "R'", "U", "R");
            }

            //Omgekeerd in eigen gat
            else if (blauw.AdresBlokje.Equals("RightRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "B", "U'", "B'", "U'", "R'", "U", "R", "U");
                moetGoedzettenRood = true;
            }

            //In Groen Rood
            else if (blauw.AdresBlokje.Equals("RightLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F", "U'");
                moetGoedzettenBlauw = true;
            }
            else if (rood.AdresBlokje.Equals("RightLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F", "U", "U");
                moetGoedzettenRood = true;
            }

            //In Groen Oranje
            else if (blauw.AdresBlokje.Equals("LeftRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "F", "U'", "F'", "U'", "L'", "U", "L", "U");
                moetGoedzettenRood = true;
            }
            else if (rood.AdresBlokje.Equals("LeftRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "F", "U'", "F'", "U'", "L'", "U", "L", "U", "U");
                moetGoedzettenBlauw = true;
            }

            //In Blauw Oranje
            else if (blauw.AdresBlokje.Equals("LeftLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U", "L'", "U'", "B'", "U'", "B", "U");
                moetGoedzettenBlauw = true;
            }
            else if (rood.AdresBlokje.Equals("LeftLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U", "L'", "U'", "B'", "U'", "B");
                moetGoedzettenRood = true;
            }

            //Corrigeren nadat het uit het vakje is gehaald
            if (moetGoedzettenRood)
            {
                outputArray = AddMul(outputArray, "B", "U'", "B'", "U'", "R'", "U", "R");
            }

            if (moetGoedzettenBlauw)
            {
                outputArray = AddMul(outputArray, "R'", "U", "R", "U", "B", "U'", "B'");

            }

            return outputArray.ToArray();
        }

        public static string[] MaakF2LGroenOranje(List<Blokje> blokjes)
        {
            //D
            List<string> outputArray = new List<string>();
            bool moetOranjeAfwerken = false, moetGroenAfwerken = false;

            Blokje groen = blokjes.Find(x => x.OorspronkelijkAdres == "FrontLeftMiddle");
            Blokje oranje = blokjes.Find(x => x.OorspronkelijkAdres == "LeftRightMiddle");


            //Bovenste vlak groen vanvoor
            if (groen.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "L'", "U", "L", "U", "F", "U'", "F'");
            }
            else if (groen.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "U'", "L'", "U", "L", "U", "F", "U'", "F'");
            }
            else if (groen.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "L'", "U", "L", "U", "F", "U'", "F'");
            }
            else if (groen.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L'", "U", "L", "U", "F", "U'", "F'");
            }

            //Bovenste Vlak oranje vanvoor
            else if (oranje.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "F", "U'", "F'", "U'", "L'", "U", "L");
            }
            else if (oranje.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "F", "U'", "F'", "U'", "L'", "U", "L");
            }
            else if (oranje.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "F", "U'", "F'", "U'", "L'", "U", "L");
            }
            else if (oranje.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "F", "U'", "F'", "U'", "L'", "U", "L");
            }

            //Al in de zijkanten
            //Omgekeerd in eigen
            else if (groen.AdresBlokje.Equals("LeftRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "F", "U", "F'", "U'", "L'", "U", "L", "U", "U");
                moetOranjeAfwerken = true;
            }

            //In blauw Oranje
            else if (groen.AdresBlokje.Equals("BackRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U'", "L'", "U'", "B'", "U", "B", "U");
                moetOranjeAfwerken = true;
            }
            else if (oranje.AdresBlokje.Equals("BackRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U'", "L'", "U'", "B'", "U", "B");
                moetGroenAfwerken = true;
            }

            //In Rood Groen
            else if (groen.AdresBlokje.Equals("FrontRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F", "U'");
                moetOranjeAfwerken = true;
            }
            else if (oranje.AdresBlokje.Equals("FrontRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F", "U", "U");
            }


            //Vooraleer dit uitvoeren boven eigenkleur zetten
            if (moetGroenAfwerken)
            {
                outputArray = AddMul(outputArray, "U'", "L'", "U", "L", "U", "F", "U'", "F'");
            }
            if (moetOranjeAfwerken)
            {
                outputArray = AddMul(outputArray, "U", "F", "U'", "F'", "U'", "L'", "U", "L");
            }



            return outputArray.ToArray();
        }

        public static string[] MaakF2LGroenRood(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();
            bool moetGroenAfwerken = false, moetRoodAfwerken = false;

            Blokje groen = blokjes.Find(x => x.OorspronkelijkAdres.Equals("FrontRightMiddle", StringComparison.OrdinalIgnoreCase));
            Blokje rood = blokjes.Find(x => x.OorspronkelijkAdres.Equals("RightLeftMiddle", StringComparison.OrdinalIgnoreCase));


            //Bovenste Vlak Groen vanvoor
            if (groen.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "R", "U'", "R'", "U'", "F'", "U", "F");
            }
            else if (groen.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "R", "U'", "R'", "U'", "F'", "U", "F");
            }
            else if (groen.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "R", "U'", "R'", "U'", "F'", "U", "F");
            }
            else if (groen.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F");
            }

            //Bovenste vlak rood vanvoor
            else if (rood.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "U'", "F'", "U'", "F", "U", "R", "U", "R'");
            }
            else if (rood.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "F'", "U'", "F", "U", "R", "U", "R'");
            }
            else if (rood.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "F'", "U'", "F", "U", "R", "U", "R'");
            }
            else if (rood.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "F'", "U'", "F", "U", "R", "U", "R'");
            }

            //In andere vakjes
            //Omgekeerd in eigen vakje
            else if (groen.AdresBlokje.Equals("RightLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "R", "U'", "R'", "U'", "F'", "U", "F", "U", "U");
                moetGroenAfwerken = true;
            }

            //Tussen Blauw en oranje
            else if (groen.AdresBlokje.Equals("LeftLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U", "L'", "U'", "B'", "U'", "B");
                moetGroenAfwerken = true;
            }
            else if (rood.AdresBlokje.Equals("LeftLeftMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U", "L'", "U'", "B'", "U'", "B", "U'");
                moetRoodAfwerken = true;
            }


            //Vooraleer dit oplossen, boven zelfde kleur zetten
            if (moetGroenAfwerken)
            {
                outputArray = AddMul(outputArray, "U", "R", "U'", "R'", "U'", "F'", "U", "F");
            }
            if (moetRoodAfwerken)
            {
                outputArray = AddMul(outputArray, "U'", "F'", "U'", "F", "U", "R", "U", "R'");
            }


            return outputArray.ToArray();
        }

        public static string[] MaakF2LBlauwOranje(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();
            bool moetOranjeAfwerken = false;

            Blokje blauw = blokjes.Find(b => b.OorspronkelijkAdres.Equals("BackRightMiddle", StringComparison.OrdinalIgnoreCase));
            Blokje oranje = blokjes.Find(b => b.OorspronkelijkAdres.Equals("LeftLeftMiddle", StringComparison.OrdinalIgnoreCase));

            //Bovenste Vlak blauw vanvoor
            if (blauw.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "L", "U'", "L'", "U'", "B'", "U", "B");
            }
            else if (blauw.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "L", "U'", "L'", "U'", "B'", "U", "B");
            }
            else if (blauw.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "L", "U'", "L'", "U'", "B'", "U", "B");
            }
            else if (blauw.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "L", "U'", "L'", "U'", "B'", "U", "B");
            }

            //Bovenste Vlak Oranje vanvoor
            else if (oranje.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "U", "B'", "U", "B", "U", "L", "U'", "L'");
            }
            else if (oranje.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U", "B'", "U", "B", "U", "L", "U'", "L'");
            }
            else if (oranje.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "B'", "U", "B", "U", "L", "U'", "L'");
            }
            else if (oranje.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "U'", "B'", "U", "B", "U", "L", "U'", "L'");
            }

            //In andere blokjes
            //Omgekeerd in eigen - Nog de enige over
            else if (oranje.AdresBlokje.Equals("BackRightMiddle", StringComparison.OrdinalIgnoreCase))
            {
                outputArray = AddMul(outputArray, "B'", "U", "B", "U", "L", "U'", "L'", "U", "U");
                moetOranjeAfwerken = true;
            }

            if (moetOranjeAfwerken)
            {
                outputArray = AddMul(outputArray, "U'", "B'", "U", "B", "U", "L", "U'", "L'");
            }

            return outputArray.ToArray();
        }



        #endregion

        //Bovenste vlak kruis
        #region Wit kruis (In plaats van het gele kruis)
        public static string[] MaakWitKruis(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();

            Blokje UpLeftMiddle = blokjes.Find(o => o.AdresBlokje.Equals("UpLeftMiddle", StringComparison.OrdinalIgnoreCase));
            Blokje UpRightMiddle = blokjes.Find(o => o.AdresBlokje.Equals("UpRightMiddle", StringComparison.OrdinalIgnoreCase));
            Blokje UpMiddleUp = blokjes.Find(o => o.AdresBlokje.Equals("UpMiddleUp", StringComparison.OrdinalIgnoreCase));
            Blokje UpMiddleDown = blokjes.Find(o => o.AdresBlokje.Equals("UpMiddleDown", StringComparison.OrdinalIgnoreCase));

            if (UpLeftMiddle.KleurBlokje != Color.White && UpRightMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje != Color.White && UpMiddleDown.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "F", "U", "R", "U'", "R'", "F'");
            }
            else if (UpLeftMiddle.KleurBlokje == Color.White && UpRightMiddle.KleurBlokje == Color.White && UpMiddleUp.KleurBlokje != Color.White && UpMiddleDown.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "F", "R", "U", "R'", "U'", "F'");
            }
            else if (UpLeftMiddle.KleurBlokje != Color.White && UpRightMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje == Color.White && UpMiddleDown.KleurBlokje == Color.White)
            {
                outputArray = AddMul(outputArray, "U", "F", "R", "U", "R'", "U'", "F'");
            }
            else if (UpLeftMiddle.KleurBlokje == Color.White && UpMiddleUp.KleurBlokje == Color.White && UpRightMiddle.KleurBlokje != Color.White && UpMiddleDown.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "F", "U", "R", "U'", "R'", "F'");
            }
            else if (UpRightMiddle.KleurBlokje == Color.White && UpMiddleUp.KleurBlokje == Color.White && UpLeftMiddle.KleurBlokje != Color.White && UpMiddleDown.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "U'", "F", "U", "R", "U'", "R'", "F'");
            }
            else if (UpRightMiddle.KleurBlokje == Color.White && UpMiddleDown.KleurBlokje == Color.White && UpLeftMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "U", "U", "F", "U", "R", "U'", "R'", "F'");
            }
            else if (UpLeftMiddle.KleurBlokje == Color.White && UpMiddleDown.KleurBlokje == Color.White && UpRightMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje != Color.White)
            {
                outputArray = AddMul(outputArray, "U", "F", "U", "R", "U'", "R'", "F'");
            }

            return outputArray.ToArray();
        }


        #endregion

        //Bovenste vlak maken (OLL)
        #region Wit vlak

        public static string[] MaakWitVlak(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();
            Blokje UpLeftUp = blokjes.Find(b => b.AdresBlokje.Equals("UpLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje UpRightUp = blokjes.Find(b => b.AdresBlokje.Equals("UpRightUp", StringComparison.OrdinalIgnoreCase));
            Blokje UpLeftDown = blokjes.Find(b => b.AdresBlokje.Equals("UpLeftDown", StringComparison.OrdinalIgnoreCase));
            Blokje UpRightDown = blokjes.Find(b => b.AdresBlokje.Equals("UpRightDown", StringComparison.OrdinalIgnoreCase));
            Blokje LeftRightUp = blokjes.Find(b => b.AdresBlokje.Equals("LeftRightUp", StringComparison.OrdinalIgnoreCase));


            //Wit, Groen, Rood
            CornerKleur witGroenRood = new CornerKleur(blokjes.Find(x => x.OorspronkelijkAdres == "UpRightDown"), blokjes.Find(x => x.OorspronkelijkAdres == "FrontRightUp"), blokjes.Find(x => x.OorspronkelijkAdres == "RightLeftUp"));
            CornerKleur witGroenOranje = new CornerKleur(blokjes.Find(x => x.OorspronkelijkAdres == "UpLeftDown"), blokjes.Find(x => x.OorspronkelijkAdres == "FrontLeftUp"), blokjes.Find(x => x.OorspronkelijkAdres == "LeftRightUp"));

            CornerKleur witBlauwOranje = new CornerKleur(blokjes.Find(x => x.OorspronkelijkAdres == "UpLeftUp"), blokjes.Find(x => x.OorspronkelijkAdres == "BackRightUp"), blokjes.Find(x => x.OorspronkelijkAdres == "LeftLeftUp"));
            CornerKleur witBlauwRood = new CornerKleur(blokjes.Find(x => x.OorspronkelijkAdres == "UpRightUp"), blokjes.Find(x => x.OorspronkelijkAdres == "BackLeftUp"), blokjes.Find(x => x.OorspronkelijkAdres == "RightRightUp"));




            //Checken hoeveel witte blokjes er boven zitten
            int aantalwitteboven = 0;

            if (UpLeftUp.KleurBlokje == Color.White)
            {
                aantalwitteboven++;
            }
            if (UpRightUp.KleurBlokje == Color.White)
            {
                aantalwitteboven++;
            }
            if (UpLeftDown.KleurBlokje == Color.White)
            {
                aantalwitteboven++;
            }
            if (UpRightDown.KleurBlokje == Color.White)
            {
                aantalwitteboven++;
            }



            if (aantalwitteboven == 1) //Wanneer er 1 witte boven zit
            {
                //Doorlopen en een move doen. Op een bepaald moment komt deze goed te zitten
                if (UpLeftDown.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "R", "U", "R'", "U", "R", "U", "U", "R'");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U");
                }
            }

            else if (aantalwitteboven == 2)
            {
                //Klaarmaken voor special case
                Blokje UpMiddleDown = blokjes.Find(x => x.AdresBlokje == "UpMiddleDown");
                Blokje UpRightMiddle = blokjes.Find(x => x.AdresBlokje == "UpRightMiddle");
                Blokje UpLeftMiddle = blokjes.Find(x => x.AdresBlokje == "UpLeftMiddle");
                Blokje UpMiddleUp = blokjes.Find(x => x.AdresBlokje == "UpMiddleUp");

                if (UpMiddleDown.KleurBlokje != Color.White && UpRightMiddle.KleurBlokje != Color.White && UpLeftMiddle.KleurBlokje == Color.White && UpMiddleUp.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");
                    //Maal 2 want eerste zorg voor 2de
                    outputArray = AddMul(outputArray, "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");

                    return outputArray.ToArray();
                }
                else if (UpMiddleDown.KleurBlokje == Color.White && UpRightMiddle.KleurBlokje != Color.White && UpLeftMiddle.KleurBlokje == Color.White && UpMiddleUp.KleurBlokje != Color.White)
                {
                    outputArray = AddMul(outputArray, "U", "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");
                    //Maal 2 want eerste zorg voor 2de
                    outputArray = AddMul(outputArray, "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");

                    return outputArray.ToArray();
                }
                else if (UpMiddleDown.KleurBlokje == Color.White && UpRightMiddle.KleurBlokje == Color.White && UpLeftMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje != Color.White)
                {
                    outputArray = AddMul(outputArray, "U", "U", "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");
                    //Maal 2 want eerste zorg voor 2de
                    outputArray = AddMul(outputArray, "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");

                    return outputArray.ToArray();
                }
                else if (UpMiddleDown.KleurBlokje != Color.White && UpRightMiddle.KleurBlokje == Color.White && UpLeftMiddle.KleurBlokje != Color.White && UpMiddleUp.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "U'", "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");
                    //Maal 2 want eerste zorg voor 2de
                    outputArray = AddMul(outputArray, "L'", "R", "U", "R'", "U'", "L", "R'", "F", "R", "F'");

                    return outputArray.ToArray();
                }
                //Einde Special Case

                else if (UpLeftUp.KleurBlokje == Color.White && UpRightUp.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "R", "U", "R'", "U", "R", "U", "U", "R'");
                }
                else if (UpLeftUp.KleurBlokje == Color.White && UpRightDown.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "R", "U", "R'", "U", "R", "U", "U", "R'");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U");
                }
            } //Wanneer 2 boven → 2 mogelijkheden 

            else if (aantalwitteboven == 0)
            {
                if (LeftRightUp.KleurBlokje == Color.White)
                {
                    outputArray = AddMul(outputArray, "R", "U", "R'", "U", "R", "U", "U", "R'");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U");
                }
            }

            return outputArray.ToArray();
        }

        #endregion

        //Permutatie laatste laag
        #region PLL

        //Maken van 2 blokjes aan 1 kant
        public static string[] MaakHoekjesWitVlak(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();
            Blokje BackRightUp = blokjes.Find(x => x.AdresBlokje.Equals("BackRightUp", StringComparison.OrdinalIgnoreCase));
            Blokje BackLeftUp = blokjes.Find(x => x.AdresBlokje.Equals("BackLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje FrontLeftUp = blokjes.Find(x => x.AdresBlokje.Equals("FrontLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje FrontRightUp = blokjes.Find(x => x.AdresBlokje.Equals("FrontRightUp", StringComparison.OrdinalIgnoreCase));
            Blokje RightLeftUp = blokjes.Find(x => x.AdresBlokje.Equals("RightLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje RightRightUp = blokjes.Find(x => x.AdresBlokje.Equals("RightRightUp", StringComparison.OrdinalIgnoreCase));
            Blokje LeftLeftUp = blokjes.Find(x => x.AdresBlokje.Equals("LeftLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje LeftRightUp = blokjes.Find(x => x.AdresBlokje.Equals("LeftRightUp", StringComparison.OrdinalIgnoreCase));

            if (BackRightUp.KleurBlokje == BackLeftUp.KleurBlokje)
            {
                outputArray = AddMul(outputArray, "R'", "F", "R'", "B", "B", "R", "F'", "R'");
                outputArray = AddMul(outputArray, "B", "B", "R", "R", "U'");
            }
            else
            {
                outputArray = AddMul(outputArray, "U");
            }

            if ((FrontLeftUp.KleurBlokje != FrontRightUp.KleurBlokje) && (RightLeftUp.KleurBlokje != RightRightUp.KleurBlokje) && (LeftLeftUp.KleurBlokje != LeftRightUp.KleurBlokje) && (BackLeftUp.KleurBlokje != BackRightUp.KleurBlokje))
            {
                outputArray = AddMul(outputArray, "R'", "F", "R'", "B", "B", "R", "F'", "R'");
                outputArray = AddMul(outputArray, "B", "B", "R", "R", "U'");
            }

            return outputArray.ToArray();
        }


        //THE END
        public static string[] TheEnd(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();

            Blokje G1 = blokjes.Find(x => x.AdresBlokje.Equals("FrontLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje G2 = blokjes.Find(x => x.AdresBlokje.Equals("FrontMiddleUp", StringComparison.OrdinalIgnoreCase));
            Blokje G3 = blokjes.Find(x => x.AdresBlokje.Equals("FrontRightUp", StringComparison.OrdinalIgnoreCase));

            Blokje R1 = blokjes.Find(x => x.AdresBlokje.Equals("RightLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje R2 = blokjes.Find(x => x.AdresBlokje.Equals("RightMiddleUp", StringComparison.OrdinalIgnoreCase));
            Blokje R3 = blokjes.Find(x => x.AdresBlokje.Equals("RightRightUp", StringComparison.OrdinalIgnoreCase));

            Blokje B1 = blokjes.Find(x => x.AdresBlokje.Equals("BackLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje B2 = blokjes.Find(x => x.AdresBlokje.Equals("BackMiddleUp", StringComparison.OrdinalIgnoreCase));
            Blokje B3 = blokjes.Find(x => x.AdresBlokje.Equals("BackRightUp", StringComparison.OrdinalIgnoreCase));

            Blokje O1 = blokjes.Find(x => x.AdresBlokje.Equals("LeftLeftUp", StringComparison.OrdinalIgnoreCase));
            Blokje O2 = blokjes.Find(x => x.AdresBlokje.Equals("LeftMiddleUp", StringComparison.OrdinalIgnoreCase));
            Blokje O3 = blokjes.Find(x => x.AdresBlokje.Equals("LeftRightUp", StringComparison.OrdinalIgnoreCase));

            //Welke 3 kleuren zijn hetzelfde?
            bool groenHetzelfde = (G1.KleurBlokje == G2.KleurBlokje) && (G2.KleurBlokje == G3.KleurBlokje);
            bool roodHetzelfde = (R1.KleurBlokje == R2.KleurBlokje) && (R2.KleurBlokje == R3.KleurBlokje);
            bool blauwHetzelfde = (B1.KleurBlokje == B2.KleurBlokje) && (B2.KleurBlokje == B3.KleurBlokje);
            bool oranjeHetzelfde = (O1.KleurBlokje == O2.KleurBlokje) && (O2.KleurBlokje == O3.KleurBlokje);

            if (groenHetzelfde && !roodHetzelfde && !blauwHetzelfde && !oranjeHetzelfde)
            {
                //Kijken welke draai het is
                //Naar rechts draaien
                if (O1.KleurBlokje == B2.KleurBlokje || B1.KleurBlokje == R2.KleurBlokje || R1.KleurBlokje == O2.KleurBlokje)
                {
                    outputArray = AddMul(outputArray, "U", "U");
                    outputArray = AddMul(outputArray, "R", "U'", "R", "U", "R", "U", "R", "U'", "R'", "U'", "R", "R");
                    outputArray = AddMul(outputArray, "U", "U");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U", "U");
                    outputArray = AddMul(outputArray, "R","R","U","R","U","R'","U'","R'","U'","R'","U","R'");
                    outputArray = AddMul(outputArray, "U", "U");
                }
            }
            else if (!groenHetzelfde && roodHetzelfde && !blauwHetzelfde && !oranjeHetzelfde)
            {
                if (O1.KleurBlokje == B2.KleurBlokje && B1.KleurBlokje == G2.KleurBlokje && G1.KleurBlokje == O2.KleurBlokje)
                {
                    outputArray = AddMul(outputArray, "U'");
                    outputArray = AddMul(outputArray, "R", "U'", "R", "U", "R", "U", "R", "U'", "R'", "U'", "R", "R");
                    outputArray = AddMul(outputArray, "U");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U'");
                    outputArray = AddMul(outputArray, "R", "R", "U", "R", "U", "R'", "U'", "R'", "U'", "R'", "U", "R'");
                    outputArray = AddMul(outputArray, "U");
                }
            }
            else if (!groenHetzelfde && !roodHetzelfde && blauwHetzelfde && !oranjeHetzelfde)
            {
                if (O1.KleurBlokje == G2.KleurBlokje && G1.KleurBlokje == R2.KleurBlokje && R1.KleurBlokje == O2.KleurBlokje)
                {
                    outputArray = AddMul(outputArray, "R", "R", "U", "R", "U", "R'", "U'", "R'", "U'", "R'", "U", "R'");
                }
                else
                {
                    outputArray = AddMul(outputArray, "R", "U'", "R", "U", "R", "U", "R", "U'", "R'", "U'", "R", "R");
                }
            }
            else if (!groenHetzelfde && !roodHetzelfde && !blauwHetzelfde && oranjeHetzelfde)
            {
                if (R1.KleurBlokje == B2.KleurBlokje && B1.KleurBlokje == G2.KleurBlokje && G1.KleurBlokje == R2.KleurBlokje)
                {
                    outputArray = AddMul(outputArray, "U");
                    outputArray = AddMul(outputArray, "R", "R", "U", "R", "U", "R'", "U'", "R'", "U'", "R'", "U", "R'");
                    outputArray = AddMul(outputArray, "U'");
                }
                else
                {
                    outputArray = AddMul(outputArray, "U");
                    outputArray = AddMul(outputArray, "R", "U'", "R", "U", "R", "U", "R", "U'", "R'", "U'", "R", "R");
                    outputArray = AddMul(outputArray, "U'");
                }
            }
            else if (!groenHetzelfde && !roodHetzelfde && !blauwHetzelfde && !oranjeHetzelfde)
            {
                outputArray = AddMul(outputArray, "R", "R", "U", "R", "U", "R'", "U'", "R'", "U'", "R'", "U", "R'");
            }

            return outputArray.ToArray();
        }


        public static string[] TurnToCorrectSide(List<Blokje> blokjes)
        {
            List<string> outputArray = new List<string>();
            Blokje BackMiddleUp = blokjes.Find(x => x.AdresBlokje.Equals("BackMiddleUp"));
            Blokje BackMiddleDown = blokjes.Find(x => x.AdresBlokje.Equals("BackMiddleDown"));

            if (BackMiddleUp.KleurBlokje != BackMiddleDown.KleurBlokje)
            {
                outputArray = AddMul(outputArray, "U");
            }

            return outputArray.ToArray();
        }




        #endregion

        //Extra methodes
        #region Adden

        private static List<string> AddMul(List<string> arr, string turnCase1, string turnCase2 = "", string turnCase3 = "", string turnCase4 = "", string turnCase5 = "", string turnCase6 = "", string turnCase7 = "", string turnCase8 = "", string turnCase9 = "", string turnCase10 = "", string turnCase11 = "", string turnCase12 = "", string turnCase13 = "")
        {
            arr.Add(turnCase1);
            if (turnCase2 != "")
                arr.Add(turnCase2);
            if (turnCase3 != "")
                arr.Add(turnCase3);
            if (turnCase4 != "")
                arr.Add(turnCase4);
            if (turnCase5 != "")
                arr.Add(turnCase5);
            if (turnCase6 != "")
                arr.Add(turnCase6);
            if (turnCase7 != "")
                arr.Add(turnCase7);
            if (turnCase8 != "")
                arr.Add(turnCase8);
            if (turnCase9 != "")
                arr.Add(turnCase9);
            if (turnCase10 != "")
                arr.Add(turnCase10);
            if (turnCase11 != "")
                arr.Add(turnCase11);
            if (turnCase12 != "")
                arr.Add(turnCase12);
            if (turnCase13 != "")
                arr.Add(turnCase13);
            arr.Remove("");
            return arr;
        }
        #endregion
    }
}