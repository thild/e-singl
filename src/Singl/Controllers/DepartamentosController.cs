using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class DepartamentosController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Departamento
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.Departamentos
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .ToList());
        }

        // GET: Departamento/5
        [HttpGet("{sigla}/{unidadeUniversitaria}")]
        [Route("[action]/{sigla}/{unidadeUniversitaria}")]
        public IActionResult Details(string sigla, string unidadeUniversitaria)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var departamentos = db.Departamentos
                .Include(m => m.Cursos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var departamento = departamentos.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }
    }
}
