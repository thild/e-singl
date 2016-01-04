using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
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
                .OrderBy(m => m.Nome)
                .ToList();
        }
 
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
			var movie = _context.UnidadesUniversitarias.Single(m => m.Id == id);
			if (movie == null) {
				return new HttpNotFoundResult();
			} else {
				return new ObjectResult(movie);
            }
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]UnidadeUniversitaria unidadeUniversitaria)
        {
			if (ModelState.IsValid)
			{
                System.Console.WriteLine(unidadeUniversitaria.Id);
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
		[HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
			var movie = _context.UnidadesUniversitarias.Single(m => m.Id == id);
			_context.UnidadesUniversitarias.Remove(movie);
			_context.SaveChanges();
            return new HttpStatusCodeResult(200);
        }        
    }
}