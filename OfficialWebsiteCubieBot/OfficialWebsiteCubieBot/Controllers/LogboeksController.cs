using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OfficialWebsiteCubieBot.Models;

namespace OfficialWebsiteCubieBot.Controllers
{
    public class LogboeksController : Controller
    {
        private LogboekContext db = new LogboekContext();

        // GET: Logboeks
        public ActionResult Index()
        {
            return View(db.Logboeken.ToList());
        }

        // GET: Logboeks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logboek logboek = db.Logboeken.Find(id);
            if (logboek == null)
            {
                return HttpNotFound();
            }
            return View(logboek);
        }

        // GET: Logboeks/Create
        public ActionResult Create()
        {
            return View(Logboek.BereidLogboekVoor());
        }

        // POST: Logboeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Omschrijving,Wanneer,Hoelang,Persoon")] Logboek logboek)
        {
            if (ModelState.IsValid)
            {
                db.Logboeken.Add(logboek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logboek);
        }

        // GET: Logboeks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logboek logboek = db.Logboeken.Find(id);
            if (logboek == null)
            {
                return HttpNotFound();
            }
            return View(logboek);
        }

        // POST: Logboeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Omschrijving,Wanneer,Hoelang,Persoon")] Logboek logboek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logboek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logboek);
        }

        // GET: Logboeks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logboek logboek = db.Logboeken.Find(id);
            if (logboek == null)
            {
                return HttpNotFound();
            }
            return View(logboek);
        }

        // POST: Logboeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logboek logboek = db.Logboeken.Find(id);
            db.Logboeken.Remove(logboek);
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
