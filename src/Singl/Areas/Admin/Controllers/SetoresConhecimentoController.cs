using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return View(db.SetoresConhecimento
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .OrderBy(m => m.Sigla)
                .ToList());
        }

        // GET: SetorConhecimento/5
        [HttpGet("{sigla}/{unidadeUniversitaria}")]
        public IActionResult Details(string sigla, string unidadeUniversitaria)
        {
            
            if (string.IsNullOrEmpty(sigla) || 
                string.IsNullOrEmpty(unidadeUniversitaria))
            {
                return new NotFoundResult();
            }

            //TODO: Verificar se na versao final do EF ainda throw "Specified cast is not valid" com a query
            // var setoresConhecimento = db.SetoresConhecimento
            //    .Include(m => m.Departamentos)
            //    .Include(m => m.Campus)
            //    .ThenInclude(m => m.UnidadeUniversitaria)
            //    .Single(m => m.Sigla == sigla && 
            //        m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
            var setoresConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                                
            if (setorConhecimento == null)
            {
                return new StatusCodeResult(404);
            }

            return View(setorConhecimento);
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
        public IActionResult Create(SetorConhecimento setorConhecimento)
        {
            if (ModelState.IsValid)
            {
                setorConhecimento.Id = Guid.NewGuid();
                db.SetoresConhecimento.Add(setorConhecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setorConhecimento);
        }

        // GET: SetorConhecimento/Edit/DEDUF
        [Route("[action]/{sigla}/{unidadeUniversitaria}")]
        public IActionResult Edit(string sigla, string unidadeUniversitaria)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var setoresConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                
            if (setorConhecimento == null)
            {
                return new StatusCodeResult(404);
            }

            return View(setorConhecimento);
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
        [Route("[action]/{sigla}/{unidadeUniversitaria}")]
        public IActionResult Delete(string sigla, string unidadeUniversitaria)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var setoresConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);

            if (setorConhecimento == null)
            {
                return new StatusCodeResult(404);
            }

            return View(setorConhecimento);
        }

        // POST: SetorConhecimento/Delete/5
        [HttpPost, ActionName("Delete"), Route("[action]/{sigla}/{unidadeUniversitaria}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string sigla, string unidadeUniversitaria)
        {
            var setoresConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                
            db.SetoresConhecimento.Remove(setorConhecimento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
