using GIPKubusProject.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.csFiles
{
    public class Kubus
    {
        public List<Blokje> Blokjes { get; set; }

        public Kubus()
        {
            Blokjes = new List<Blokje>();
        }

        public Kubus(List<Blokje> blokjes)
        {
            Blokjes = blokjes;
        }

        #region Methods

        public List<Blokje> TurnU(bool isPrime = false)
        {
            return Turns.U(Blokjes, isPrime);
        }
        public List<Blokje> TurnD(bool isPrime = false)
        {
            return Turns.D(Blokjes, isPrime);
        }
        public List<Blokje> TurnF(bool isPrime = false)
        {
            return Turns.F(Blokjes, isPrime);
        }
        public List<Blokje> TurnR(bool isPrime = false)
        {
            return Turns.R(Blokjes, isPrime);
        }
        public List<Blokje> TurnB(bool isPrime = false)
        {
            return Turns.B(Blokjes, isPrime);
        }
        public List<Blokje> TurnL(bool isPrime = false)
        {
            return Turns.L(Blokjes, isPrime);
        }

        public int[] ScrambleGenerator(byte hoeveel)
        {
            //D
            Random random = new Random();
            List<int> scrambleList = new List<int>();

            //P
            for (int i = 0; i < hoeveel; i++)
            {
                int randomgtl = random.Next(1, 13); //12 mogelijkheden
                scrambleList.Add(randomgtl);
            }

            return scrambleList.ToArray();
        }
        #endregion
    }
}
