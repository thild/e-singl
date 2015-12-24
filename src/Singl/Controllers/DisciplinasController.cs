using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class DisciplinasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Disciplina
        public IActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        // GET: Disciplina/5
        [HttpGet("{codigo}")]
        [Route("[action]/{codigo}")]
        public IActionResult Details(string codigo)
        {
            if (codigo == null)
            {
                return new HttpStatusCodeResult(404);
            }

            var disciplina = db.Disciplinas
                .Include(m => m.Curriculo)
                .ThenInclude(m => m.Curso)
                .Single(m => m.Codigo == codigo);
            if (disciplina == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(disciplina);
        }
    }
}
