using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class UnidadesUniversitariasController : Controller
    {
        private DatabaseContext _context;

        public UnidadesUniversitariasController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<UnidadeUniversitaria> Get()
        {
            return _context.UnidadesUniversitarias
                .Include(m => m.Campi)
                .OrderBy(m => m.Nome)
                .ToList();
        }
 
        [HttpGet("{sigla}")]
        public IActionResult Get(string sigla)
        {
            
            if (string.IsNullOrEmpty(sigla))
            {
                return new StatusCodeResult(404);
            }

            var uu = _context.UnidadesUniversitarias
                .Include(m => m.Campi)
                .Single(m => m.Sigla == sigla.ToUpper());
                
            uu.Campi = uu.Campi
                .OrderByDescending(m => m.Sede)
                .ThenBy(m => m.Avancado)
                .ThenBy(m => m.Nome)
                .ToList();
                
            if (uu == null)
            {
                return new NotFoundResult();
            }
                        
            return new ObjectResult(uu);
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]UnidadeUniversitaria unidadeUniversitaria)
        {
			if (ModelState.IsValid)
			{
				if (unidadeUniversitaria.Id == Guid.Empty)
				{
					_context.UnidadesUniversitarias.Add(unidadeUniversitaria);
					_context.SaveChanges();
					return new ObjectResult(unidadeUniversitaria);
				}
				else
				{
					var original = _context.UnidadesUniversitarias.Single(m => m.Id == unidadeUniversitaria.Id);
					original.Nome = unidadeUniversitaria.Nome;
					original.Sigla = unidadeUniversitaria.Sigla;
					_context.SaveChanges();
					return new ObjectResult(original);
				}
			}

			// This will work in later versions of ASP.NET 5
			return new BadRequestObjectResult(ModelState);
		}


		//[Authorize("CanEdit", "true")]
		[HttpDelete("{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return new NotFoundResult();
            }
            var obj = _context.UnidadesUniversitarias.Single(m => m.Sigla == sigla.ToUpper());
            if (obj == null)
            {
                return new NotFoundResult();
            }            
            _context.UnidadesUniversitarias.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }        
    }
}