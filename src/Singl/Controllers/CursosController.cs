using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class CursosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Curso
        public IActionResult Index()
        {
            return View(db.Cursos.ToList());
        }

        [Route("[action]/{departamento}")]
        public IActionResult Departamento(string departamento)
        {
            if (string.IsNullOrEmpty(departamento))
            {
                return new HttpStatusCodeResult(404);
            }
            return View(db.Departamentos
                          .Include(m => m.Cursos)
                          .Where(m => m.Sigla == departamento).Single());
        }


        // GET: Curso/Details/5
        [HttpGet("{codigo}")]
        [Route("[action]/{codigo}")]
        public IActionResult Details(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return new HttpStatusCodeResult(404);
            }

            var curso = db.Cursos
                .Include(m => m.Curriculos)
                .ThenInclude(m => m.Disciplinas)
                .Single(m => m.Codigo == codigo);

            if (curso == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(curso);
        }
    }
}
