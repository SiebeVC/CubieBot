using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Website2CubieBot.Models;

namespace Website2CubieBot.Controllers
{
    public class HomeController : Controller
    {
        DomainController dc = DomainController.Instance;

        public ActionResult Index(TaalKeuze taal = TaalKeuze.Nederlands)
        {
            //Zoeken van tekst word gedaan als volgend:
            //Als eerst bepalen we de pagina (controller/view) → in dit geval is dit "home/index"
            string pagina = "home/index";

            //Hierna bepalen we welke taal er opgegeven is. Hiervoor kijken we naar de parameter (taal)
            //Dan roepen we de functie op die al de taal ophaald waarvan de pagina hetzelfde is en de taalkeuze ook
            //Deze steken we dan in een lijst die we als model doorgeven aan de view
            List<Taal> lstInhoud = dc.GetTalenVanPagina(pagina, taal);
            //lstInhoud = new List<Taal>();
            return View(lstInhoud);
        }

        public ActionResult About(TaalKeuze taal = TaalKeuze.Nederlands)
        {
            List<Taal> lstTaal = dc.GetTalenVanPagina("home/about", taal);

            return View(lstTaal);
        }

        public ActionResult Vooruitgang(TaalKeuze taal = TaalKeuze.Nederlands)
        {
            List<Taal> lstTaal = dc.GetTalenVanPagina("home/vooruitgang",taal); 

            return View(lstTaal);
        }

        [Authorize(Roles = "Admin,Jury")]
        public ActionResult Bestanden()
        {
            return View();
        }
    }
}