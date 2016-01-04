using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class CidadesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Cidade
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.Cidades.ToList());
        }

        // GET: Cidade/5
        [HttpGet("{id}")]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Cidade = db.Cidades
                .Single(m => m.Id == id);
                
            if (Cidade == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Cidade);
        }

        // GET: Cidade/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cidade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(Cidade Cidade)
        {
            if (ModelState.IsValid)
            {
                Cidade.Id = Guid.NewGuid();
                db.Cidades.Add(Cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Cidade);
        }

        // GET: Cidade/Edit/DEDUF
        [Route("[action]/{id}")]
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Cidade = db.Cidades
                .Single(m => m.Id == id);
            if (Cidade == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Cidade);
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(Cidade Cidade)
        {
            if (ModelState.IsValid)
            {
                db.Update(Cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Cidade);
        }

        // GET: Cidade/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Cidade = db.Cidades.Single(m => m.Id == id);
            if (Cidade == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var Cidade = db.Cidades.Single(m => m.Id == id);
            db.Cidades.Remove(Cidade);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
