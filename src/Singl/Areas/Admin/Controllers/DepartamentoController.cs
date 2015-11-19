using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartamentoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Departamento
        public IActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }

        // GET: Departamento/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Id == id);
                
            if (Departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Departamento);
        }

        // GET: Departamento/Details/5
        public IActionResult Info(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Id == id);
            if (Departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Departamento);
        }

        // GET: Departamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento Departamento)
        {
            if (ModelState.IsValid)
            {
                Departamento.Id = Guid.NewGuid();
                db.Departamentos.Add(Departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Departamento);
        }

        // GET: Departamento/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var Departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Id == id);
            if (Departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Departamento);
        }

        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Departamento Departamento)
        {
            foreach(var i in ModelState)
            {
                Console.WriteLine(i.Key);
                foreach(var e in i.Value.Errors) 
                    Console.WriteLine(e.ErrorMessage);
            }
                    
            if (ModelState.IsValid)
            {
                db.Update(Departamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Departamento);
        }

        // GET: Departamento/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Departamento Departamento = db.Departamentos.Single(m => m.Id == id);
            if (Departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(Departamento);
        }

        // POST: Departamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Departamento Departamento = db.Departamentos.Single(m => m.Id == id);
            db.Departamentos.Remove(Departamento);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
