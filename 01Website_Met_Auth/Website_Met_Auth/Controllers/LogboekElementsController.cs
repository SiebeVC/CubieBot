using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_Met_Auth.Models;

namespace Website_Met_Auth.Controllers
{
    [Authorize(Roles = "Admin,Jury")]
    public class LogboekElementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LogboekElements
        [Authorize(Roles = "Admin,Jury")]
        public ActionResult Index()
        {
            List<LogboekElement> elementen = db.LogboekElementen.ToList();
            elementen.Reverse();
            return View(elementen);
        }

        // GET: LogboekElements/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogboekElement logboekElement = db.LogboekElementen.Find(id);
            if (logboekElement == null)
            {
                return HttpNotFound();
            }
            return View(logboekElement);
        }

        // GET: LogboekElements/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogboekElements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ElementId,Naam,Wanneer,Hoelang,WatNed,WatFra,WatEng")] LogboekElement logboekElement)
        {
            if (ModelState.IsValid)
            {
                db.LogboekElementen.Add(logboekElement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logboekElement);
        }

        // GET: LogboekElements/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogboekElement logboekElement = db.LogboekElementen.Find(id);
            if (logboekElement == null)
            {
                return HttpNotFound();
            }

            return View(logboekElement);
        }

        // POST: LogboekElements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ElementId,Naam,Wanneer,Hoelang,WatNed,WatFra,WatEng")] LogboekElement logboekElement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logboekElement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logboekElement);
        }

        // GET: LogboekElements/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogboekElement logboekElement = db.LogboekElementen.Find(id);
            if (logboekElement == null)
            {
                return HttpNotFound();
            }
            return View(logboekElement);
        }

        // POST: LogboekElements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            LogboekElement logboekElement = db.LogboekElementen.Find(id);
            db.LogboekElementen.Remove(logboekElement);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
