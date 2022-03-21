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
    [Authorize(Roles = "Admin, Jury")]
    public class DeadlinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Deadlines
        [Authorize(Roles = "Admin, Jury")]
        public ActionResult Index()
        {
            return View(db.Deadlines.ToList());
        }

        // GET: Deadlines/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadline deadline = db.Deadlines.Find(id);
            if (deadline == null)
            {
                return HttpNotFound();
            }
            return View(deadline);
        }

        // GET: Deadlines/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            if (RolesBepaler.WelkeRole(User.Identity.Name) == "Admin")
                return View("../deadlines/Create");
            else
                return View("GeenToegang");
        }

        // POST: Deadlines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "DeadlineId,Wat,Wanneer,WatNed,WatFra,WatEng,Link")] Deadline deadline)
        {
            if (ModelState.IsValid)
            {
                db.Deadlines.Add(deadline);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deadline);
        }

        // GET: Deadlines/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadline deadline = db.Deadlines.Find(id);
            if (deadline == null)
            {
                return HttpNotFound();
            }
            return View(deadline);
        }

        // POST: Deadlines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "DeadlineId,Wat,Wanneer,WatNed,WatFra,WatEng,Link")] Deadline deadline)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deadline).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deadline);
        }

        // GET: Deadlines/Delete/
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deadline deadline = db.Deadlines.Find(id);
            if (deadline == null)
            {
                return HttpNotFound();
            }

            return View(deadline);
        }

        // POST: Deadlines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Deadline deadline = db.Deadlines.Find(id);
            db.Deadlines.Remove(deadline);
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
