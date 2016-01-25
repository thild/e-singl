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
    public class DisciplinasController : Controller
    {
        private DatabaseContext _context;

        public DisciplinasController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Disciplina> Get()
        {
            return _context.Disciplinas
                    .OrderBy(m => m.Serie)
                    .ThenBy(m => m.Semestre)
                    .ThenBy(m => m.Ordem)
                    .ThenBy(m => m.Nome)
                    .ToList();
        }
 
        [HttpGet("{codigo}")]
        public IActionResult Get(string codigo)
        {
            
            if (string.IsNullOrEmpty(codigo))
            {
                return new HttpNotFoundResult();
            }

            var obj = _context.Disciplinas
                .Single(m => m.Codigo == codigo.ToUpper());
                
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }
                        
            return new ObjectResult(obj);
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Disciplina disciplina)
        {
			if (ModelState.IsValid)
			{
				if (disciplina.Id == Guid.Empty)
				{
					_context.Disciplinas.Add(disciplina);
					_context.SaveChanges();
					return new ObjectResult(disciplina);
				}
				else
				{
					var original = _context.Disciplinas.Single(m => m.Id == disciplina.Id);
					original.Nome = disciplina.Nome;
					original.Codigo = disciplina.Codigo;
					_context.SaveChanges();
					return new ObjectResult(original);
				}
			}

			// This will work in later versions of ASP.NET 5
			return new BadRequestObjectResult(ModelState);
		}


		//[Authorize("CanEdit", "true")]
		[HttpDelete("{codigo}")]
        public IActionResult Delete(string codigo)
        {
            if (string.IsNullOrEmpty(codigo))
            {
                return new HttpNotFoundResult();
            }
            var obj = _context.Disciplinas.Single(m => m.Codigo == codigo.ToUpper());
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }            
            _context.Disciplinas.Remove(obj);
            _context.SaveChanges();
            return new HttpOkResult();
        }        
    }
}