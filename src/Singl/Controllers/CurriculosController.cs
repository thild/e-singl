using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Controllers
{
    [Route("[controller]")]
    public class CurriculosController : Controller
    {
        private DatabaseContext _context;

        public CurriculosController(DatabaseContext context)
        {
            _context = context;    
        }

        // GET: Curriculo
        [HttpGet("{codigoCurso}")]
        [Route("[action]/{codigoCurso}")]
        public IActionResult Index(string codigoCurso)
        {
            if (codigoCurso == null)
            {
                return HttpNotFound();
            }

            var curriculo = _context.Curriculos
                .Include(m => m.Curso)
                .Include(m => m.Disciplinas)
                .Single(m => m.Curso.Codigo == codigoCurso && 
                        m.SituacaoCurriculo == SituacaoCurriculo.Vigente);
            if (curriculo == null)
            {
                return HttpNotFound();
            }

            return View(curriculo);
        }
    }
}
