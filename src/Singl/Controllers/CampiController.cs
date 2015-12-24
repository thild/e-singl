using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class CampiController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Campus
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.Campi.ToList());
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

            var departamento = db.Campi
                .Include(m => m.SetoresConhecimento)
                .Single(m => m.Sigla == sigla.ToUpper());
                
            if (departamento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(departamento);
        }
    }
}
