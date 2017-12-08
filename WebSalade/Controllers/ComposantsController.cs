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
    public class ComposantsController : Controller
    {
        private SaladesContext db = new SaladesContext();

        // GET: Composants
        public ActionResult Index()
        {
            return View(db.Composants.ToList());
        }

        // GET: Composants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composants.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // GET: Composants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Composants/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] Composant composant)
        {
            if (ModelState.IsValid)
            {
                db.Composants.Add(composant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(composant);
        }

        // GET: Composants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composants.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // POST: Composants/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] Composant composant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(composant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(composant);
        }

        // GET: Composants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Composant composant = db.Composants.Find(id);
            if (composant == null)
            {
                return HttpNotFound();
            }
            return View(composant);
        }

        // POST: Composants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Composant composant = db.Composants.Find(id);
            db.Composants.Remove(composant);
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
