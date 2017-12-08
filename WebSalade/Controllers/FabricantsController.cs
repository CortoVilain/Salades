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
    public class FabricantsController : Controller
    {
        private SaladesContext db = new SaladesContext();

        // GET: Fabricants
        public ActionResult Index()
        {
            return View(db.Fabricants.ToList());
        }

        // GET: Fabricants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricant fabricant = db.Fabricants.Find(id);
            if (fabricant == null)
            {
                return HttpNotFound();
            }
            return View(fabricant);
        }

        // GET: Fabricants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fabricants/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom")] Fabricant fabricant)
        {
            if (ModelState.IsValid)
            {
                db.Fabricants.Add(fabricant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricant);
        }

        // GET: Fabricants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricant fabricant = db.Fabricants.Find(id);
            if (fabricant == null)
            {
                return HttpNotFound();
            }
            return View(fabricant);
        }

        // POST: Fabricants/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom")] Fabricant fabricant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricant);
        }

        // GET: Fabricants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricant fabricant = db.Fabricants.Find(id);
            if (fabricant == null)
            {
                return HttpNotFound();
            }
            return View(fabricant);
        }

        // POST: Fabricants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabricant fabricant = db.Fabricants.Find(id);
            db.Fabricants.Remove(fabricant);
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
