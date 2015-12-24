using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class CursosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Curso
        [HttpGet("{*departamento}")]
        public IActionResult Index(string departamento)
        {
            if (string.IsNullOrEmpty(departamento))
            {
                return new HttpStatusCodeResult(404);
            }
            
            return View(db.Departamentos
                          .Include(m => m.Cursos)
                          .Where(m => m.Sigla == departamento).Single());
        }

        // GET: Curso/Details/5
        [HttpGet("{codigo}")]
        public IActionResult Details(string codigo)
        {
            if (codigo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var curso = db.Cursos
                .Include(m => m.Curriculos)
                .ThenInclude(m => m.Disciplinas)
                .Single(m => m.Codigo == codigo);
                
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // GET: Curso/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
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
        [Route("[action]/{codigo}")]
        public IActionResult Edit(string codigo)
        {
            if (codigo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var curso = db.Cursos
                .Include(m => m.Curriculos)
                .ThenInclude(m => m.Disciplinas)
                .Single(m => m.Codigo == codigo);
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit")]

        public IActionResult Edit(Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Update(curso);
                db.SaveChanges();
                var departamento = db.Departamentos
                    .Where(m => m.Id == curso.DepartamentoId).Single();                
                return RedirectToAction("Index", new {departamento = departamento.Sigla});
            }

            return View(curso);
        }

        // GET: Curso/Delete/5
        [ActionName("Delete")]
        [Route("Delete/{codigo}")]
        public IActionResult Delete(string codigo)
        {
            if (codigo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Curso curso = db.Cursos.Single(m => m.Codigo == codigo);
            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string codigo)
        {
            Curso curso = db.Cursos.Single(m => m.Codigo == codigo);
            db.Cursos.Remove(curso);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
