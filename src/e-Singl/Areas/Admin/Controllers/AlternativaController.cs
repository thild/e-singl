using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AlternativaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Alternativa
        public IActionResult Index()
        {
            return View(db.Set<Alternativa>().ToList());
        }

        // GET: Alternativa/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Alternativa alternativa = db.Set<Alternativa>().Single(m => m.Id == id);
            if (alternativa == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(alternativa);
        }

        // GET: Alternativa/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alternativa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                alternativa.Id = Guid.NewGuid();
                db.Set<Alternativa>().Add(alternativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alternativa);
        }

        // GET: Alternativa/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Alternativa alternativa = db.Set<Alternativa>().Single(m => m.Id == id);
            if (alternativa == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(alternativa);
        }

        // POST: Alternativa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Alternativa alternativa)
        {
            if (ModelState.IsValid)
            {
                db.Update(alternativa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alternativa);
        }

        // GET: Alternativa/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Alternativa alternativa = db.Set<Alternativa>().Single(m => m.Id == id);
            if (alternativa == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(alternativa);
        }

        // POST: Alternativa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Alternativa alternativa = db.Set<Alternativa>().Single(m => m.Id == id);
            db.Set<Alternativa>().Remove(alternativa);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
