using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIPKubusProject.DBModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public double Level { get; set; }
        public double Experience { get; set; }
        bool LogInLocked { get; set; }

        public virtual List<Solve> Solves { get; set; }
        public virtual List<Pattern> Patterns { get; set; }

        #region Constructors

        public User()
        {

        }

        public User(string username)
        {
            User user = GetUserByName(username);

            Username = user.Username;
            Password = user.Password;
            Level = user.Level;
            Experience = user.Experience;
            LogInLocked = user.LogInLocked;
            Solves = user.Solves;
            Patterns = user.Patterns;
        }

        #endregion

        public static User GetUserByName(string userName)
        {
            if (!String.IsNullOrWhiteSpace(userName))
            {

                string[] waardes = DatabaseMethods.DatabaseRead("Select * From tblAccount Where Username = '" + userName + "';");
                User returnUser = new User()
                {
                    Id = int.Parse(waardes[0]),
                    Username = waardes[1],
                    Password = waardes[2],
                    Level = double.Parse(waardes[3]),
                    Experience = double.Parse(waardes[4]),
                    LogInLocked = bool.Parse(waardes[5]),
                };

                returnUser.Solves = Solve.GetSolvesVanUser(returnUser);
                returnUser.Patterns = Pattern.GetPatternsVanUser(returnUser);
                return returnUser;
            }
            else
                return null;
        }
    }
}
