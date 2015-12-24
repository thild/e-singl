using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]")]
    public class SetoresConhecimentoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: SetorConhecimento
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.SetoresConhecimento.Include(m => m.Cidade).ToList());
        }

        // GET: SetorConhecimento/5
        [HttpGet("{sigla}/{cidade}")]
        public IActionResult Details(string sigla, string cidade)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var SetorConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Cidade)
                .Single(m => m.Sigla == sigla && m.Cidade.Sigla == cidade);
                
            if (SetorConhecimento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(SetorConhecimento);
        }

        // GET: SetorConhecimento/Create
        [Route("[action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: SetorConhecimento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Create(SetorConhecimento SetorConhecimento)
        {
            if (ModelState.IsValid)
            {
                SetorConhecimento.Id = Guid.NewGuid();
                db.SetoresConhecimento.Add(SetorConhecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(SetorConhecimento);
        }

        // GET: SetorConhecimento/Edit/DEDUF
        [Route("[action]/{sigla}/{cidade}")]
        public IActionResult Edit(string sigla, string cidade)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var SetorConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Cidade)
                .Single(m => m.Sigla == sigla && m.Cidade.Sigla == cidade);
            if (SetorConhecimento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(SetorConhecimento);
        }

        // POST: SetorConhecimento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[action]")]
        public IActionResult Edit(SetorConhecimento SetorConhecimento)
        {
            if (ModelState.IsValid)
            {
                db.Update(SetorConhecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(SetorConhecimento);
        }

        // GET: SetorConhecimento/Delete/5
        [ActionName("Delete")]
        [Route("[action]/{sigla}/{cidade}")]
        public IActionResult Delete(string sigla, string cidade)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var SetorConhecimento = db.SetoresConhecimento.Single(m => m.Sigla == sigla && m.Cidade.Sigla == cidade);
            if (SetorConhecimento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(SetorConhecimento);
        }

        // POST: SetorConhecimento/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}/{cidade}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla, string cidade)
        {
            var SetorConhecimento = db.SetoresConhecimento.Single(m => m.Sigla == sigla && m.Cidade.Sigla == cidade);
            db.SetoresConhecimento.Remove(SetorConhecimento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
