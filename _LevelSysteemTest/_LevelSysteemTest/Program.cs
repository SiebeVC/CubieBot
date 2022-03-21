using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _LevelSysteemTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int xp;

            while (true)
            {
                Console.Write("Geef een xp aantal in: ");
                xp = int.Parse(Console.ReadLine());

                Console.WriteLine("Level is: " + LevelBerekenen(xp)[0]);
                Console.WriteLine("Xp over is: " + LevelBerekenen(xp)[1]);
                Console.WriteLine("Percentage van volgend level is: " + LevelBerekenen(xp)[2]);
                //Console.WriteLine(Math.Pow(144, 0.25));
                //Console.WriteLine(Math.Sqrt(144));
            }

        }

        public static double[] LevelBerekenen(int xp)
        {
            double[] arrXPLVL = new double[3];
            double level, xpOver;
            double percentage;

            //Werkt
            level = Math.Floor(Math.Pow(xp, 0.3333333333333333333333333));
            double ok = Math.Pow(level, 3);
            xpOver = (xp - ok );

            //Werkt nog niet
            percentage = Math.Round(xpOver / (Math.Pow(level + 1, 3) - Math.Pow(level, 3)) * 100, 2);

            arrXPLVL[0] = level;
            arrXPLVL[1] = xpOver;
            arrXPLVL[2] = percentage;

            return arrXPLVL;
        }
    }
}
