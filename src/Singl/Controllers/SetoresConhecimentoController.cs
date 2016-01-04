using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class SetoresConhecimentoController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Departamento
        [HttpGet()]
        public IActionResult Index()
        {
            return View(db.SetoresConhecimento
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .OrderBy(m => m.Nome)            
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

            var setoresConhecimento = db.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                
            setorConhecimento.Departamentos = setorConhecimento.Departamentos
                .OrderBy(m => m.Nome).ToList();
                
            if (setorConhecimento == null)
            {
                return new HttpStatusCodeResult(404);
            }

            return View(setorConhecimento);
        }
    }
}
