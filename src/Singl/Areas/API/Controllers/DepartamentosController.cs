using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class DepartamentosController : Controller
    {
        private DatabaseContext _context;

        public DepartamentosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return _context.Departamentos
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .OrderBy(m => m.Nome)
                .ToList();
        }
 
        [HttpGet("{sigla}/{unidadeUniversitaria}")]
        public IActionResult Get(string sigla, string unidadeUniversitaria)
        {
            
            if (string.IsNullOrEmpty(sigla) || 
                string.IsNullOrEmpty(unidadeUniversitaria))
            {
                return new HttpNotFoundResult();
            }

            var Departamentos = _context.Departamentos
                .Include(m => m.Cursos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var obj = Departamentos.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                                
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }
                        
            return new ObjectResult(obj);
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Departamento departamento)
        {
			if (ModelState.IsValid)
			{
				if (departamento.Id == Guid.Empty)
				{
					_context.Departamentos.Add(departamento);
					_context.SaveChanges();
					return new ObjectResult(departamento);
				}
				else
				{
					var original = _context.Departamentos.Single(m => m.Id == departamento.Id);
					original.Nome = departamento.Nome;
					original.Sigla = departamento.Sigla;
					_context.SaveChanges();
					return new ObjectResult(original);
				}
			}

			// This will work in later versions of ASP.NET 5
			return new BadRequestObjectResult(ModelState);
		}


		//[Authorize("CanEdit", "true")]
		[HttpDelete("{sigla}/{unidadeUniversitaria}")]
        public IActionResult Delete(string sigla, string unidadeUniversitaria)
        {
            if (string.IsNullOrEmpty(sigla) || 
                string.IsNullOrEmpty(unidadeUniversitaria))
            {
                return new HttpNotFoundResult();
            }

            var departamentos = _context.Departamentos
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var obj = departamentos.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);

            if (obj == null)
            {
                return new HttpNotFoundResult();
            }
            return new HttpOkResult();
        }        
    }
}