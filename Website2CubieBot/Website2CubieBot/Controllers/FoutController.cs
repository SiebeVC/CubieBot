using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Website2CubieBot.Models;

namespace Website2CubieBot.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FoutController : Controller
    {
        DomainController dc = DomainController.Instance;

        // GET: Fout
        public ActionResult Index()
        {
            return View(dc.Fouten);
        }
    }
}