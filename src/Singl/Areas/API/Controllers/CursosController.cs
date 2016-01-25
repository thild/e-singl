using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class CursosController : Controller
    {
        private DatabaseContext _context;

        public CursosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var list = _context.Cursos
                .Include(m => m.Departamento)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .Include(m => m.Curriculos)
                .ThenInclude(m => m.Disciplinas)
                .OrderBy(m => m.Nome)
                .ToList();

            List<dynamic> retList = new List<dynamic>();       
            
            foreach (var item in list)
            {
                retList.Add(
                   item.ToDto()
                );
            }                         
                
            return retList;
        }
 
        [HttpGet("{codigo}")]
        public IActionResult Get(string codigo)
        {
            
            if (string.IsNullOrEmpty(codigo))
            {
                return new HttpNotFoundResult();
            }

            var curso = _context.Cursos
                .Include(m => m.Departamento)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .Include(m => m.Curriculos)
                .ThenInclude(m => m.Disciplinas)
                .Single(m => m.Codigo == codigo.ToUpper());
                
            curso.Curriculo.Disciplinas = 
                curso.Curriculo.Disciplinas
                    .OrderBy(m => m.Serie)
                    .ThenBy(m => m.Semestre)
                    .ThenBy(m => m.Ordem)
                    .ThenBy(m => m.Nome)
                    .ToList();
                
            if (curso == null)
            {
                return new HttpNotFoundResult();
            }
                          
            return new ObjectResult(curso.ToDto());
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Curso curso)
        {
			if (ModelState.IsValid)
			{
				if (curso.Id == Guid.Empty)
				{
					_context.Cursos.Add(curso);
					_context.SaveChanges();
					return new ObjectResult(curso);
				}
				else
				{
					var original = _context.Cursos.Single(m => m.Id == curso.Id);
					original.Nome = curso.Nome;
					original.Codigo = curso.Codigo;
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
            var obj = _context.Cursos.Single(m => m.Codigo == codigo.ToUpper());
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }            
            _context.Cursos.Remove(obj);
            _context.SaveChanges();
            return new HttpOkResult();
        }        
    }
}