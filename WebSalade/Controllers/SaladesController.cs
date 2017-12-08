using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirst2;
using WebSalade.ViewModel;

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
            var saladeViewModel = new SaladeViewModel
            {
                Salade = db.Salades.Include(i => i.Composants).First(i => i.ID == id)
            };
            if (saladeViewModel == null)
            {
                return HttpNotFound();
            }
            var allComposant = db.Composants.ToList();
            saladeViewModel.AllComposant = allComposant.Select(o => new SelectListItem { Text = o.Nom, Value = o.ID.ToString() });
            Salade salade = db.Salades.Find(id);
            if (salade == null)
            {
                return HttpNotFound();
            }


            return View(saladeViewModel);
        }

        // POST: Salades/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SaladeViewModel saladeViewModel)
        {

            if (saladeViewModel == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                var saladeToUpdate = db.Salades
                    .Include(i => i.Composants).First(i => i.ID == saladeViewModel.Salade.ID);

                if (TryUpdateModel(saladeToUpdate, "Salade", new string[] { "Nom", "Description" }))
                {
                    var newComposant = db.Composants.Where(
                        m => saladeViewModel.SelectedComposant.Contains(m.ID)).ToList();

                    var updatedComposant = new HashSet<int>(saladeViewModel.SelectedComposant);
                    foreach (Composant composant in db.Composants)
                    {
                        if (!updatedComposant.Contains(composant.ID))
                        {
                            saladeToUpdate.Composants.Remove(composant);
                        }
                        else
                        {
                            saladeToUpdate.Composants.Add(composant);
                        }
                    }

                    db.Entry(saladeToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            
            return View(saladeViewModel.Salade);
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
