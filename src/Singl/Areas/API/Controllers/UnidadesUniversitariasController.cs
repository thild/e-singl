using System;
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
        public IActionResult Get()
        {
            return Ok(_context.UnidadesUniversitarias
                .Include(m => m.Campi)
                .OrderBy(m => m.Nome)
                .ToList());
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
                        
            return Ok(uu);
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
					return Ok(unidadeUniversitaria);
				}
				else
				{
					var original = _context.UnidadesUniversitarias.Single(m => m.Id == unidadeUniversitaria.Id);
					original.Nome = unidadeUniversitaria.Nome;
					original.Sigla = unidadeUniversitaria.Sigla;
					_context.SaveChanges();
					return Ok(original);
				}
			}

			// This will work in later versions of ASP.NET 5
			return BadRequest(ModelState);
		}


		//[Authorize("CanEdit", "true")]
		[HttpDelete("{sigla}")]
        public IActionResult Delete(string sigla)
        {
            if (string.IsNullOrEmpty(sigla))
            {
                return NotFound();
            }
            var obj = _context.UnidadesUniversitarias.Single(m => m.Sigla == sigla.ToUpper());
            if (obj == null)
            {
                return NotFound();
            }            
            _context.UnidadesUniversitarias.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }        
    }
}