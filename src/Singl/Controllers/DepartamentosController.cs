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
            return View(db.Departamentos.ToList());
        }

        // GET: Departamento/5
        [HttpGet("{sigla}")]
        [Route("[action]/{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var departamento = db.Departamentos
                .Include(m => m.Cursos)
                .Single(m => m.Sigla == sigla.ToUpper());
                
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }
    }
}
