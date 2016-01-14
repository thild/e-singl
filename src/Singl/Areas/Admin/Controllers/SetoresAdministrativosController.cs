using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class SetoresAdministrativosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: SetorAdministrativo
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.SetoresAdministrativos.ToList());
        }

        // GET: SetorAdministrativo/5
        [HttpGet("{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var SetorAdministrativo = db.SetoresAdministrativos
                .Include(m => m.Subsetores)
                .Single(m => m.Sigla == sigla);
                
            if (SetorAdministrativo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(SetorAdministrativo);
        }

        // GET: SetorAdministrativo/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SetorAdministrativo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(SetorAdministrativo setorAdministrativo)
        {
            if (ModelState.IsValid)
            {
                setorAdministrativo.Id = Guid.NewGuid();
                db.SetoresAdministrativos.Add(setorAdministrativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setorAdministrativo);
        }

        // GET: SetorAdministrativo/Edit/DEDUF
        [Route("[action]/{sigla}")]
        public IActionResult Edit(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var SetorAdministrativo = db.SetoresAdministrativos
                .Include(m => m.Subsetores)
                .Single(m => m.Sigla == sigla);
            if (SetorAdministrativo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(SetorAdministrativo);
        }

        // POST: SetorAdministrativo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(SetorAdministrativo setorAdministrativo)
        {
            if (ModelState.IsValid)
            {
                db.Update(setorAdministrativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setorAdministrativo);
        }

        // GET: SetorAdministrativo/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var setorAdministrativo = db.SetoresAdministrativos.Single(m => m.Sigla == sigla);
            if (setorAdministrativo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(setorAdministrativo);
        }

        // POST: SetorAdministrativo/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla)
        {
            var setorAdministrativo = db.SetoresAdministrativos.Single(m => m.Sigla == sigla);
            db.SetoresAdministrativos.Remove(setorAdministrativo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
