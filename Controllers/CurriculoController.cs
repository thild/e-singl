using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Neadm;
using Neadm.Models;
using Neadm.ViewModels;

namespace neadm.Controllers
{
    public class CurriculoController : Controller
    {
        private NeadmDbContext _context;

        public CurriculoController(NeadmDbContext context)
        {
            _context = context;    
        }

        // GET: Curriculo
        public IActionResult Index(Guid cursoId)
        {
            var vm = new CurriculoIndexViewModel {
                Curso = _context.Cursos.Single(m => m.Id == cursoId),
                Curriculos = _context.Curriculos.Where(m => m.CursoId == cursoId)
            };
            return View(vm);
        }

        // GET: Curriculo/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Curriculo curriculo = _context.Curriculos.Include(m => m.Curso).Single(m => m.Id == id);
            if (curriculo == null)
            {
                return HttpNotFound();
            }

            return View(curriculo);
        }

        // GET: Curriculo/Create
        public IActionResult Create(Guid cursoId)
        {
            var curso = _context.Cursos.Single(m => m.Id == cursoId);
            return View(new Curriculo{Curso = curso}); 
        }

        // POST: Curriculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                curriculo.Id = Guid.NewGuid();
                curriculo.Curso = _context.Cursos.Single(m => m.Id == curriculo.CursoId);
                _context.Curriculos.Add(curriculo);
                _context.SaveChanges();
                return RedirectToAction("Index", new {cursoId = curriculo.Curso.Id});
            }
            return View(curriculo);
        }

        // GET: Curriculo/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var curriculo = _context.Curriculos.Include(m => m.Curso).Single(m => m.Id == id);
            if (curriculo == null)
            {
                return HttpNotFound();
            }
            return View(curriculo);
        }

        // POST: Curriculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Curriculo curriculo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(curriculo);
                _context.SaveChanges();
                return RedirectToAction("Index", new {cursoId = curriculo.CursoId});
            }
            return View(curriculo);
        }

        // GET: Curriculo/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var curriculo = _context.Curriculos.Single(m => m.Id == id);
            if (curriculo == null)
            {
                return HttpNotFound();
            }

            return View(curriculo);
        }

        // POST: Curriculo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var curriculo = _context.Curriculos.Single(m => m.Id == id);
            _context.Curriculos.Remove(curriculo);
            _context.SaveChanges();
            return RedirectToAction("Index", new {cursoId = curriculo.CursoId});
            
        }
    }
}
