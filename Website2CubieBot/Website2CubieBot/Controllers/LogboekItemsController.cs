using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website2CubieBot.Models;

using Website2CubieBot.Models.ViewModels;

namespace Website2CubieBot.Controllers
{
    [Authorize()]
    public class LogboekItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private DomainController dc = DomainController.Instance;

        // GET: LogboekItems
        public ActionResult Index()
        {
            return View(dc.LogboekItems.OrderByDescending(t =>t.Datum).ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: LogboekItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LogboekItem logboekItem = dc.GetLogboekItem(id);

            if (logboekItem == null)
            {
                return HttpNotFound();
            }
            return View(logboekItem);
        }

        // GET: LogboekItems/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            VMLogboekItem VM = new VMLogboekItem();
            VM.Personen = dc.Personen.ToList();

            return View(VM);
        }

        // POST: LogboekItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(VMLogboekItem VM)
        {
            if (ModelState.IsValid)
            {
                LogboekItem item = VM.LogboekItem;
                item.Persoon = dc.Personen.Find(VM.LogboekItem.Persoon.Id);

                dc.CreateLogboekItem(item);

                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        // GET: LogboekItems/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LogboekItem logboekItem = dc.GetLogboekItem(id);
            VMLogboekItem VM = new VMLogboekItem();
            VM.LogboekItem = logboekItem;
            VM.Personen = dc.Personen.ToList();

            if (logboekItem == null)
            {
                return HttpNotFound();
            }
            return View(VM);
        }

        // POST: LogboekItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(/*[Bind(Include = "Id,Titel,Inhoud,Datum")] LogboekItem logboekItem*/ VMLogboekItem VM)
        {
            if (ModelState.IsValid)
            {
                VM.LogboekItem.Persoon = dc.GetPersoon(VM.LogboekItem.Persoon.Id);
                dc.EditLogboekItem(VM.LogboekItem);
                return RedirectToAction("Index");
            }
            return View(VM);
        }

        // GET: LogboekItems/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogboekItem logboekItem = db.LogboekItems.Find(id);
            if (logboekItem == null)
            {
                return HttpNotFound();
            }
            return View(logboekItem);
        }

        // POST: LogboekItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            LogboekItem logboekItem = db.LogboekItems.Find(id);
            db.LogboekItems.Remove(logboekItem);
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
