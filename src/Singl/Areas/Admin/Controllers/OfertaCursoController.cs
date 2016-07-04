using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OfertaCursoController : Controller
    {
        private DatabaseContext _context;

        public OfertaCursoController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: OfertaCurso
        public IActionResult Index()
        {
            var ofertaCurso = _context.OfertasCurso.Include(o => o.Curso);
            return View(ofertaCurso.ToList());
        }

        // GET: OfertaCurso/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ofertaCurso = _context.OfertasCurso.Single(m => m.Id == id);
            if (ofertaCurso == null)
            {
                return NotFound();
            }

            return View(ofertaCurso);
        }

        // GET: OfertaCurso/Create
        public IActionResult Create()
        {
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Curso");
            return View();
        }

        // POST: OfertaCurso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OfertaCurso ofertaCurso)
        {
            if (ModelState.IsValid)
            {
                ofertaCurso.Id = Guid.NewGuid();
                _context.OfertasCurso.Add(ofertaCurso);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Curso", ofertaCurso.CursoId);
            return View(ofertaCurso);
        }

        // GET: OfertaCurso/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OfertaCurso ofertaCurso = _context.OfertasCurso.Single(m => m.Id == id);
            if (ofertaCurso == null)
            {
                return NotFound();
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Curso", ofertaCurso.CursoId);
            return View(ofertaCurso);
        }

        // POST: OfertaCurso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OfertaCurso ofertaCurso)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ofertaCurso);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["CursoId"] = new SelectList(_context.Cursos, "Id", "Curso", ofertaCurso.CursoId);
            return View(ofertaCurso);
        }

        // GET: OfertaCurso/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OfertaCurso ofertaCurso = _context.OfertasCurso.Single(m => m.Id == id);
            if (ofertaCurso == null)
            {
                return NotFound();
            }

            return View(ofertaCurso);
        }

        // POST: OfertaCurso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            OfertaCurso ofertaCurso = _context.OfertasCurso.Single(m => m.Id == id);
            _context.OfertasCurso.Remove(ofertaCurso);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
