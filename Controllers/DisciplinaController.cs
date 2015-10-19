using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Neadm.Models;
using Neadm.ViewModels;

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

            var disciplina = db.Disciplinas.Project().To<DisciplinaEditViewModel>().Single(m => m.Id == id);
            System.Console.WriteLine(disciplina);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DisciplinaEditViewModel disciplina)
        {
            Console.WriteLine(disciplina.CursoId);
            if (ModelState.IsValid)
            {
                var c = db.Cursos.Single(m => m.Id == disciplina.CursoId);
                if (c != null)
                {
                    var d = Mapper.Map<Disciplina>(disciplina);
                    d.Curso = c;
                    db.Update(d);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
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
