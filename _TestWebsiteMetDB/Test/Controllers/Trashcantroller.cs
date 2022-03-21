using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class Trashcantroller : Controller
    {
        // GET: Trashcantroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trashcantroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // GET: Trashcantroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trashcantroller/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Trashcantroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trashcantroller/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                
                return RedirectToAction("Logboek");
            }
            catch
            {
                return View();
            }
        }
    }
}
