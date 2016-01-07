using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class UnidadesUniversitariasController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Campus
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.UnidadesUniversitarias
                .OrderBy(m => m.Nome)
                .ToList());
        }

        // GET: Campus/5
        [HttpGet("{sigla}")]
        [Route("[action]/{sigla}")]
        public IActionResult Details(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var uu = db.UnidadesUniversitarias
                .Include(m => m.Campi)
                .Single(m => m.Sigla == sigla.ToUpper());
                
            uu.Campi = uu.Campi.OrderBy(m => m.Nome).ToList();
                
            if (uu == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(uu);
        }
    }
}
