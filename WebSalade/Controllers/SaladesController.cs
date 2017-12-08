using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst2;

namespace WebSalade.Controllers
{
    public class SaladesController : Controller
    {
        private SaladesContext db = new SaladesContext();

        // GET: Salades
        public ActionResult Index()
        {
            return View(db.Salades.ToList());
        }

        // GET: Salades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // GET: Salades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salades/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Description")] Salade salade)
        {
            if (ModelState.IsValid)
            {
                db.Salades.Add(salade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salade);
        }

        // GET: Salades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // POST: Salades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Description")] Salade salade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salade);
        }

        // GET: Salades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }
            return View(salade);
        }

        // POST: Salades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Salade salade = db.Salades.Find(id);
            db.Salades.Remove(salade);
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
