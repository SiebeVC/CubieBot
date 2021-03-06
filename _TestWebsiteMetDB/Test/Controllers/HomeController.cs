using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Test.Models;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        Activititeiten activititeiten;

        public HomeController()
        {
            if (activititeiten == null)
                activititeiten = new Activititeiten();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogBoek()
        {
            return View(activititeiten.lstActiviteiten);
        }
    }
}