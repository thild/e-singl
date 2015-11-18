using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Singl.Models;
using Singl.ViewModels;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DisciplinaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Disciplina
        public IActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        // GET: Disciplina/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }

        // GET: Disciplina/Create
        public IActionResult Create()
        {
                Console.WriteLine("Teste1");
            
            return View(new DisciplinaCreateViewModel());
        }

        // POST: Disciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DisciplinaCreateViewModel disciplina)
        {
            Console.WriteLine("Teste2");
            
            if (ModelState.IsValid)
            {
                var c = db.Curriculos.Single(m => m.Id == disciplina.CurriculoId);
                if (c != null)
                {
                    var d = Mapper.Map<Disciplina>(disciplina);
                    d.Curriculo = c;
                    db.Disciplinas.Add(d);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            //var disciplina = db.Disciplinas.Project().To<DisciplinaEditViewModel>().Single(m => m.Id == id);
            var disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }
            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Update(disciplina);
                db.SaveChanges();
                //return Redirect(Request.Headers["Referer"]);
                return RedirectToAction("Index");
            }
            return View(disciplina);
        }

        // GET: Disciplina/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var disciplina = db.Disciplinas.Single(m => m.Id == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var disciplina = db.Disciplinas.Single(m => m.Id == id);
            db.Disciplinas.Remove(disciplina);
            db.SaveChanges();

            return RedirectToAction("Details", "Curriculo", new {id = disciplina.CurriculoId});
        }
    }
}
