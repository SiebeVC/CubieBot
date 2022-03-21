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
    public class PersoonsController : Controller
    {
        DomainController dc = DomainController.Instance;
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Persoons
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(dc.Personen.ToList());
        }

        [Authorize()]
        // GET: Persoons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persoon persoon = dc.GetPersoon(id);

            VMPersoon VM = new VMPersoon(persoon);
            VM.Logboek = persoon.LogboekItems.OrderByDescending(l => l.Datum).ToList(); ;

                
            if (persoon == null)
            {
                return HttpNotFound();
            }

            return View(VM);
        }


        // GET: Persoons/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persoons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Voornaam,Achternaam,Email,GeboorteDatum,Gemeente")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                dc.CreatePersoon(persoon);

                return RedirectToAction("Index");
            }

            //Terug naar create
            return View(persoon);
        }

        // GET: Persoons/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persoon persoon = dc.GetPersoon(id);

            if (persoon == null)
            {
                return HttpNotFound();
            }

            return View(persoon);
        }

        // POST: Persoons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Voornaam,Achternaam,Email,GeboorteDatum,Gemeente")] Persoon persoon)
        {
            if (ModelState.IsValid)
            {
                if (dc.EditPersoon(persoon) != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(persoon);
                }
            }

            return View(persoon);
        }


        // GET: Persoons/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Persoon persoon = dc.GetPersoon(id);

            if (persoon == null)
            {
                return HttpNotFound();
            }

            return View(persoon);
        }

        // POST: Persoons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Persoon persoon = dc.GetPersoon(id);

            dc.DeletePersoon(persoon);

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
