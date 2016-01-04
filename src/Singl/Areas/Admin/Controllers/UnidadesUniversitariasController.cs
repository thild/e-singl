using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class UnidadesUniversitariasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: UnidadeUniversitaria
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.UnidadesUniversitarias
                .Include(m => m.Campi)
                .ToList());
        }

        // GET: UnidadeUniversitaria/5
        [HttpGet("{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var UnidadeUniversitaria = db.UnidadesUniversitarias
                .Include(m => m.Campi)
                .Single(m => m.Sigla == sigla);
                
            if (UnidadeUniversitaria == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(UnidadeUniversitaria);
        }

        // GET: UnidadeUniversitaria/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnidadeUniversitaria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(UnidadeUniversitaria UnidadeUniversitaria)
        {
            if (ModelState.IsValid)
            {
                UnidadeUniversitaria.Id = Guid.NewGuid();
                db.UnidadesUniversitarias.Add(UnidadeUniversitaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(UnidadeUniversitaria);
        }

        // GET: UnidadeUniversitaria/Edit/DEDUF
        [Route("[action]/{sigla}")]
        public IActionResult Edit(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var UnidadeUniversitaria = db.UnidadesUniversitarias
                .Single(m => m.Sigla == sigla);
            if (UnidadeUniversitaria == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(UnidadeUniversitaria);
        }

        // POST: UnidadeUniversitaria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(UnidadeUniversitaria unidadeUniversitaria)
        {
            if (ModelState.IsValid)
            {
                db.Update(unidadeUniversitaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadeUniversitaria);
        }

        // GET: UnidadeUniversitaria/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var UnidadeUniversitaria = db.UnidadesUniversitarias.Single(m => m.Sigla == sigla);
            if (UnidadeUniversitaria == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(UnidadeUniversitaria);
        }

        // POST: UnidadeUniversitaria/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla)
        {
            var UnidadeUniversitaria = db.UnidadesUniversitarias.Single(m => m.Sigla == sigla);
            db.UnidadesUniversitarias.Remove(UnidadeUniversitaria);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
