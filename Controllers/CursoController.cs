using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Neadm.Models;

namespace Neadm.Controllers
{
    public class CursoController : Controller
    {
        private NeadmDbContext db = new NeadmDbContext();

        // GET: Curso
        public IActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        // GET: Curso/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Curso curso = db.Cursos.Single(m => m.Id == id);
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // GET: Curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Curso curso)
        {
            if (ModelState.IsValid)
            {
                curso.Id = Guid.NewGuid();
                db.Cursos.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Curso/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Curso curso = db.Cursos.Single(m => m.Id == id);
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Update(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(curso);
        }

        // GET: Curso/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Curso curso = db.Cursos.Single(m => m.Id == id);
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Curso curso = db.Cursos.Single(m => m.Id == id);
            db.Cursos.Remove(curso);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
