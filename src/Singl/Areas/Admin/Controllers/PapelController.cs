using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Singl.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PapelController : Controller
    {
       
        private DatabaseContext db = new DatabaseContext();

        // GET: Papel
        public IActionResult Index()
        {
            return View(db.Papeis.ToList());
        }

        // GET: Papel/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            Papel Papel = db.Papeis.Single(m => m.Id == id.Value);
            if (Papel == null)
            {
                return new StatusCodeResult(404);
            }

            return View(Papel);
        }

        // GET: Papel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Papel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Papel Papel)
        {
            if (ModelState.IsValid)
            {
                Papel.Id = Guid.NewGuid();
                db.Papeis.Add(Papel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Papel);
        }

        // GET: Papel/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            Papel Papel = db.Papeis.Single(m => m.Id == id);
            if (Papel == null)
            {
                return new StatusCodeResult(404);
            }

            return View(Papel);
        }

        // POST: Papel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Papel Papel)
        {
            if (ModelState.IsValid)
            {
                db.Update(Papel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Papel);
        }

        // GET: Papel/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(404);
            }

            Papel Papel = db.Papeis.Single(m => m.Id == id);
            if (Papel == null)
            {
                return new StatusCodeResult(404);
            }

            return View(Papel);
        }

        // POST: Papel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Papel Papel = db.Papeis.Single(m => m.Id == id);
            db.Papeis.Remove(Papel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        
    }
}
