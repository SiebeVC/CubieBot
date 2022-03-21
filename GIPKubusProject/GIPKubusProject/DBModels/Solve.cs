using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.DBModels
{
    public class Solve
    {
        public int Id { get; set; }
        public double Tijd { get; set; }
        public string Scramble { get; set; }


        public User User { get; set; }

        public static List<Solve> GetSolvesVanUser(User user)
        {
            string[] waardesSolves;
            List<Solve> solves = new List<Solve>();
            try
            {
                if (user != null)
                {
                    waardesSolves = DatabaseMethods.DatabaseRead("SELECT * FROM tblSolves WHERE Username = '" + user.Username + "';");

                    if (waardesSolves.Length > 0)
                    {
                        for (int i = 0; i < waardesSolves.Length; i += 4)
                        {
                            solves.Add(new Solve()
                            {
                                Id = int.Parse(waardesSolves[i]),
                                Tijd = double.Parse(waardesSolves[i + 1]),
                                User = user,
                                Scramble = waardesSolves[i + 3]
                            });
                        }

                        return solves;
                    }
                    else
                        return solves;
                }
                else
                    return solves;
            }
            catch (Exception)
            {
                return new List<Solve>();
            }
        }
    }
}
