using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MeerdereTalenCubieBotWebsite.Models;

namespace MeerdereTalenCubieBotWebsite.Controllers
{
    public class frController : Controller
    {
        static LogBoekElementen LijstEle;
        static Deadlines lijstDeadlines;
        public frController()
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

        public ActionResult Nous()
        {
            return View();
        }

        public ActionResult Journal()
        {
            ViewBag.DataElementen = LijstEle;

            return View();
        }

        public ActionResult Delais()
        {
            ViewBag.DataDeadlines = lijstDeadlines;

            return View();
        }
    }
}