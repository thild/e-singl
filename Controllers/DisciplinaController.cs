using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Neadm.Models;

namespace Neadm.Controllers
{
    public class DisciplinaController : Controller
    {
        private NeadmDbContext db = new NeadmDbContext();

        // GET: Disciplina
        public IActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        // GET: Disciplina/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Disciplina disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }

        // GET: Disciplina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                disciplina.Id = Guid.NewGuid();
                db.Disciplinas.Add(disciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Disciplina disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Update(disciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disciplina);
        }

        // GET: Disciplina/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Disciplina disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Disciplina disciplina = db.Disciplinas.Single(m => m.Id == id);
            db.Disciplinas.Remove(disciplina);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
