using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace GIPKubusProject.Kleuren_blokjes
{
    // De zijkanten van de kubus
    public class EdgesKleur
    {
        #region Properties

        /// <summary>
        /// Kleur 1/2 van het kantblokje
        /// </summary>
        public Blokje BlokjeKleurEdge1 { get; set; }

        /// <summary>
        /// Kleur 2/2 van het kantblokje
        /// </summary>
        public Blokje BlokjeKleurEdge2 { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor van EdgesKleur
        /// </summary>
        /// <param name="kleur1">De eerste kleur van het Edgeblokje</param>
        /// <param name="kleur2">De tweede kleur van het Edgeblokje</param>
        public EdgesKleur(Blokje kleur1, Blokje kleur2)
        {
            BlokjeKleurEdge1 = kleur1;
            BlokjeKleurEdge2 = kleur2;
        }

        #endregion
    }
}
