using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class DepartamentosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Departamento
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }

        // GET: Departamento/5
        [HttpGet("{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Sigla == sigla);
                
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }

        // GET: Departamento/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                departamento.Id = Guid.NewGuid();
                db.Departamentos.Add(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Departamento/Edit/DEDUF
        [Route("[action]/{sigla}")]
        public IActionResult Edit(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Sigla == sigla);
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                db.Update(departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Departamento/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var departamento = db.Departamentos.Single(m => m.Sigla == sigla);
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla)
        {
            var departamento = db.Departamentos.Single(m => m.Sigla == sigla);
            db.Departamentos.Remove(departamento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
