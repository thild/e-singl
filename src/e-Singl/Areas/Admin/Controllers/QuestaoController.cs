using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Singl.Models;

namespace Singl.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestaoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Questao
        public IActionResult Index()
        {
            return View(db.Set<Questao>().ToList());
        }

        // GET: Questao/Details/5
        public IActionResult Details(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Questao questao = db.Set<Questao>().Single(m => m.Id == id);
            if (questao == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(questao);
        }

        // GET: Questao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Questao questao)
        {
            if (ModelState.IsValid)
            {
                questao.Id = Guid.NewGuid();
                db.Set<Questao>().Add(questao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questao);
        }

        // GET: Questao/Edit/5
        public IActionResult Edit(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Questao questao = db.Set<Questao>().Single(m => m.Id == id);
            if (questao == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(questao);
        }

        // POST: Questao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Questao questao)
        {
            if (ModelState.IsValid)
            {
                db.Update(questao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questao);
        }

        // GET: Questao/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(System.Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            Questao questao = db.Set<Questao>().Single(m => m.Id == id);
            if (questao == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(questao);
        }

        // POST: Questao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(System.Guid id)
        {
            Questao questao = db.Set<Questao>().Single(m => m.Id == id);
            db.Set<Questao>().Remove(questao);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
