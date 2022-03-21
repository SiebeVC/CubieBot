using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MeerdereTalenCubieBotWebsite.Models;

namespace MeerdereTalenCubieBotWebsite.Controllers
{
    public class nlController : Controller
    {
        static LogBoekElementen LijstEle;
        static Deadlines lijstDeadlines;
        public nlController()
        {
            if (LijstEle == null || lijstDeadlines == null)
            {
                LijstEle = new LogBoekElementen();
                lijstDeadlines = new Deadlines();

                //Waarden doorgeven
                ViewBag.DataElementen = LijstEle;
                ViewBag.DataDeadlines = lijstDeadlines;
            }
        }
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Logboek()
        {

            ViewBag.DataElementen = LijstEle;

            return View();
        }


        public ActionResult Deadlines()
        {
            ViewBag.DataDeadlines = lijstDeadlines;

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Wie zijn wij?";

            return View();
        }
    }
}