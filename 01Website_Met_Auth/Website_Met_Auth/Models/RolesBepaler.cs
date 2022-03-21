using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_Met_Auth.Models
{
    public class RolesBepaler
    {
        public static ApplicationDbContext db = new ApplicationDbContext();

        public static string WelkeRole(string naam)
        {
            string gecontrolleerdEmail = "";
            if (naam != "")
              gecontrolleerdEmail = db.Users.ToList().Find(o => o.UserName == naam).Email;


            //Admins Controlleren
            if (gecontrolleerdEmail.ToLower() == "siebe.vancampenhout@student.romerocollege.be" || gecontrolleerdEmail.ToLower() == "robin.vermeir@student.romerocollege.be")
                return "Admin";

            else if (gecontrolleerdEmail.ToLower() == "jurycubiebot@romerocollege.be")
                return "Jury";

            else
                return "";
        }
    }
}