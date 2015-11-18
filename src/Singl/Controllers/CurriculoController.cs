using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl;
using Singl.Models;
using Singl.ViewModels;

namespace Singl.Controllers
{
    public class CurriculoController : Controller
    {
        private DatabaseContext _context;

        public CurriculoController(DatabaseContext context)
        {
            _context = context;    
        }

        // GET: Curriculo
        public IActionResult Index(Guid cursoId)
        {
            if (cursoId == null)
            {
                return HttpNotFound();
            }

            var curriculo = _context.Curriculos
                .Include(m => m.Curso)
                .Include(m => m.Disciplinas)
                .Single(m => m.CursoId == cursoId && 
                        m.SituacaoCurriculo == SituacaoCurriculo.Vigente);
            if (curriculo == null)
            {
                return HttpNotFound();
            }

            return View(curriculo);
        }
    }
}
