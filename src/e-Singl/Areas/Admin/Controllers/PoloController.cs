using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PoloController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Polo
        public IActionResult Index()
        {
            return View(db.Polos.ToList());
        }

        // GET: Polo/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Polo polo = db.Polos.Single(m => m.Id == id);
            if (polo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(polo);
        }

        // GET: Polo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Polo polo)
        {
            if (ModelState.IsValid)
            {
                polo.Id = Guid.NewGuid();
                db.Polos.Add(polo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polo);
        }

        // GET: Polo/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Polo polo = db.Polos.Single(m => m.Id == id);
            if (polo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(polo);
        }

        // POST: Polo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Polo polo)
        {
            if (ModelState.IsValid)
            {
                db.Update(polo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(polo);
        }

        // GET: Polo/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Polo polo = db.Polos.Single(m => m.Id == id);
            if (polo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(polo);
        }

        // POST: Polo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Polo polo = db.Polos.Single(m => m.Id == id);
            db.Polos.Remove(polo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
