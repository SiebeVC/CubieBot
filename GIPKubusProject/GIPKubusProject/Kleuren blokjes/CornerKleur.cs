using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace GIPKubusProject.Kleuren_blokjes
{
    //Een hoek van de kubus
    public class CornerKleur
    {
        #region Properties

        /// <summary>
        /// Kleur 1/3 van het hoekblokje
        /// </summary>
        public Blokje BlokjeKleur1 { get; set; }

        /// <summary>
        /// Kleur 2/3 van het hoekblokje
        /// </summary>
        public Blokje BlokjeKleur2 { get; set; }

        /// <summary>
        /// Kleur 3/3 van het hoekblokje
        /// </summary>
        public Blokje BlokjeKleur3 { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// De constructor van CornerKleur (Cornerblokje)
        /// </summary>
        /// <param name="Kleur1">Eerste kleur van het cornerblokje</param>
        /// <param name="Kleur2">Tweede kleur van het cornerblokje</param>
        /// <param name="Kleur3">Derde kleur van het vornerblokje</param>
        public CornerKleur(Blokje Kleur1, Blokje Kleur2, Blokje Kleur3)
        {
            BlokjeKleur1 = Kleur1;
            BlokjeKleur2 = Kleur2;
            BlokjeKleur3 = Kleur3;
        }

        #endregion
    }
}
