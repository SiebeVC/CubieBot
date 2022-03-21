using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GIPKubusProject
{
    /// <summary>
    /// Class bokjes, Er zijn 27 objecten van nodig
    /// </summary>
    public class Blokje
    {
        #region Properties

        /// <summary>
        /// Adres van het blokje, Adres is het paneel van waar het blokje zich bevind
        /// </summary>
        public string AdresBlokje { get; set; }

        /// <summary>
        /// Kleur van het blokje
        /// </summary>
        public Color KleurBlokje { get; set; }

        /// <summary>
        /// Het oorspronkelijk adres, Het adres waar het blokje thuishoort als de kubus is opgelost
        /// </summary>
        public string OorspronkelijkAdres { get; set; }

        #endregion

        int i = 0;

        /// <summary>
        /// Constructor van Blokje
        /// </summary>
        /// <param name="naam">De naam van het blokje</param>
        /// <param name="adresBlokje">Het adres van het blokje</param>
        public Blokje(string naam, string adresBlokje, string oorspronkelijkAdres = "")
        {
            // Dit slecteerd de kleur uit de naam
            // Dit gebeurd aan de hand van de eerste letter
            switch (naam.Substring(0,1))
            {
                case "G":
                    KleurBlokje = Color.FromArgb(11,238,50);
                    break;

                case "B":
                    KleurBlokje =  Color.FromArgb(33,96,112); //Logo Kleur
                    break;

                case "O":
                    KleurBlokje = Color.FromArgb(240,78,0);
                    break;

                case "R":
                    KleurBlokje = Color.FromArgb(173,19,19); //Logo Kleur
                    break;

                case "Y":
                    KleurBlokje = Color.Yellow;
                    break;

                default:
                    KleurBlokje = Color.White;
                    break;
            }

            AdresBlokje = adresBlokje;


            if (i == 0) 
            {
                OorspronkelijkAdres = adresBlokje;
                i++;
            }

        }

        public Blokje()
        {

        }
    }
}
