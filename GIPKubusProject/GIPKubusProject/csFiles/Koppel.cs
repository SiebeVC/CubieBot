using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject
{
    public class Koppel
    {
        public Blokje Kant1 { get; set; }
        public Blokje Kant2 { get; set; }
        public Blokje Kant3 { get; set; }

        //Groen en blauw krijgen voorang voor de naam
        //daarna wit en geel
        //Dit zal het adres als naam krijgen
        public string Naam { get; set; }

        public Koppel()
        {

        }

        public static List<Koppel> Initial(List<Koppel> lstKop, string oorspronk, Color kleur)
        {
            Blokje blok = new Blokje()
            {
                OorspronkelijkAdres = oorspronk,
                KleurBlokje = kleur //Staat ook goed
                //Adres niet nodig want is variabel
            };

            string naam;

            switch (blok.OorspronkelijkAdres)
            {
                //Blokjes met groen (Edge)
                case "FrontMiddleDown":
                    naam = "FrontMiddleDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;

                case "DownMiddleUp":
                    naam = "FrontMiddleDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "FrontMiddleUp":
                    naam = "FrontMiddleUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "UpMiddleDown":
                    naam = "FrontMiddleUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "FrontLeftMiddle":
                    naam = "FrontLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;

                case "LeftRightMiddle":
                    naam = "FrontLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "FrontRightMiddle":
                    naam = "FrontRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;

                case "RightLeftMiddle":
                    naam = "FrontRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;

                // Blauwe Edges //
                case "BackMiddleUp":
                    naam = "BackMiddleUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;

                case "UpMiddleUp":
                    naam = "BackMiddleUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "BackMiddleDown":
                    naam = "BackMiddleDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "DownMiddleDown":
                    naam = "BackMiddleDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "BackRightMiddle":
                    naam = "BackRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "LeftLeftMiddle":
                    naam = "BackRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "BackLeftMiddle":
                    naam = "BackLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "RightRightMiddle":
                    naam = "BackLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;

                // Overige Wit //
                case "UpRightMiddle":
                    naam = "UpRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "RightMiddleUp":
                    naam = "UpRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "UpLeftMiddle":
                    naam = "UpLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "LeftMiddleUp":
                    naam = "UpLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // Overige Geel
                case "DownLeftMiddle":
                    naam = "DownLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "LeftMiddleDown":
                    naam = "DownLeftMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                // -- //
                case "DownRightMiddle":
                    naam = "DownRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "RightMiddleDown":
                    naam = "DownRightMiddle";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;


                // Hoeken Groen //
                case "FrontLeftUp":
                    naam = "FrontLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "UpLeftDown":
                    naam = "FrontLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "LeftRightUp":
                    naam = "FrontLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "FrontRightUp": 
                    naam = "FrontRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "UpRightDown":
                    naam = "FrontRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "RightLeftUp":
                    naam = "FrontRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "FrontLeftDown": 
                    naam = "FrontLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "DownLeftUp":
                    naam = "FrontLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "LeftRightDown":
                    naam = "FrontLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "FrontRightDown": 
                    naam = "FrontRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "DownRightUp":
                    naam = "FrontRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "RightLeftDown":
                    naam = "FrontRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;

                // Hoeken blauw //
                case "BackLeftUp":
                    naam = "BackLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "UpRightUp":
                    naam = "BackLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "RightRightUp":
                    naam = "BackLeftUp";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "BackRightUp":
                    naam = "BackRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "UpLeftUp":
                    naam = "BackRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "LeftLeftUp":
                    naam = "BackRightUp";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "BackLeftDown":
                    naam = "BackLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "DownRightDown":
                    naam = "BackLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "RightRightDown":
                    naam = "BackLeftDown";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;
                // -- //
                case "BackRightDown":
                    naam = "BackRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 1);
                    break;
                case "DownLeftDown":
                    naam = "BackRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 2);
                    break;
                case "LeftLeftDown":
                    naam = "BackRightDown";
                    lstKop = YesDRY(lstKop, naam, blok, 3);
                    break;

                default:
                    break;
            }

            return lstKop;
        }

        private static List<Koppel> YesDRY(List<Koppel> lstKop, string naam, Blokje blok, byte _123)
        {
            Koppel koppel = new Koppel();

            if (_123 == 1)
            {
                if (KoppelExist(lstKop, naam))
                {
                    lstKop[lstKop.IndexOf(lstKop.Find(k => k.Naam == naam))].Kant1 = blok;
                }
                else
                {
                    koppel.Kant1 = blok;
                    koppel.Naam = naam;
                    lstKop.Add(koppel);
                }
            }
            else if (_123 == 2)
            {
                if (KoppelExist(lstKop, naam))
                {
                    lstKop[lstKop.IndexOf(lstKop.Find(k => k.Naam == naam))].Kant2 = blok;
                }
                else
                {
                    koppel.Kant2 = blok;
                    koppel.Naam = naam;
                    lstKop.Add(koppel);
                }
            }
            else
            {
                if (KoppelExist(lstKop, naam))
                {
                    lstKop[lstKop.IndexOf(lstKop.Find(k => k.Naam == naam))].Kant3 = blok;
                }
                else
                {
                    koppel.Kant3 = blok;
                    koppel.Naam = naam;
                    lstKop.Add(koppel);
                }
            }

            return lstKop;
        }

        public static bool KoppelExist(List<Koppel> koppels, string naam)
        {
            if (koppels.Find(k => k.Naam == naam) != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
