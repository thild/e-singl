using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class CampiController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Campus
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.Campi.ToList());
        }

        // GET: Campus/5
        [HttpGet("{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var campus = db.Campi
                .Include(m => m.SetoresConhecimento)
                .Include(m => m.UnidadeUniversitaria)
                .Single(m => m.Sigla == sigla);
                
            if (campus == null)
            {
                return new StatusCodeResult(404);
            }

            return View(campus);
        }

        // GET: Campus/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(Campus campus)
        {
            if (ModelState.IsValid)
            {
                campus.Id = Guid.NewGuid();
                db.Campi.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        // GET: Campus/Edit/DEDUF
        [Route("[action]/{sigla}")]
        public IActionResult Edit(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var campus = db.Campi
                .Include(m => m.SetoresConhecimento)
                .Include(m => m.UnidadeUniversitaria)
                .Single(m => m.Sigla == sigla);
            if (campus == null)
            {
                return new StatusCodeResult(404);
            }

            return View(campus);
        }

        // POST: Campus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Update(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campus);
        }

        // GET: Campus/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var campus = db.Campi.Single(m => m.Sigla == sigla);
            if (campus == null)
            {
                return new StatusCodeResult(404);
            }

            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla)
        {
            var campus = db.Campi.Single(m => m.Sigla == sigla);
            db.Campi.Remove(campus);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
