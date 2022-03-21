using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MeerdereTalenCubieBotWebsite.Models;

namespace MeerdereTalenCubieBotWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Language()
        {
            return View();
        }
    }
}