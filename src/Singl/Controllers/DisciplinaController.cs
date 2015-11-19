using System;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Singl.Models;
using Singl.ViewModels;

namespace Singl.Controllers
{
    public class DisciplinaController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Disciplina
        public IActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        // GET: Disciplina/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var disciplina = db.Disciplinas
                .Include(m => m.Curriculo)
                .ThenInclude(m => m.Curso)
                .Single(m => m.Codigo == id);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }
    }
}
