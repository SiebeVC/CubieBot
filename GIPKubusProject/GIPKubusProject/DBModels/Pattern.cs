using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.DBModels
{
    public class Pattern
    {
        public int Id { get; set; }
        public string Patroon { get; set; }
        public User User { get; set; }
        public string Naam { get; set; }

        public static List<Pattern> GetPatternsVanUser(User user)
        {
            string[] waardePatterns;
            List<Pattern> Patterns = new List<Pattern>();
            try
            {
                if (user != null)
                {
                    waardePatterns = DatabaseMethods.DatabaseRead("SELECT * FROM tblPatterns WHERE Username = '" + user.Username + "';");

                    if (waardePatterns.Length > 0)
                    {
                        for (int i = 0; i < waardePatterns.Length; i += 4)
                        {
                            Patterns.Add(new Pattern()
                            {
                                Id = int.Parse(waardePatterns[i]),
                                Patroon = waardePatterns[i + 1],
                                User = user,
                                Naam = waardePatterns[i + 3]
                            });
                        }

                        return Patterns;
                    }
                    else
                        return Patterns;
                }
                else
                    return Patterns;
            }
            catch (Exception)
            {
                return new List<Pattern>();
            }
        }
    }
}
