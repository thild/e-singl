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
    public class DepartamentosController : Controller
    {
        private DatabaseContext _context;

        public DepartamentosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var list = _context.Departamentos
                .Include(m => m.SetorConhecimento)
                .ThenInclude(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .Include(m => m.Cursos)
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
 
        [HttpGet("{sigla}/{unidadeUniversitaria}")]
        public IActionResult Get(string sigla, string unidadeUniversitaria)
        {
            if (string.IsNullOrEmpty(sigla) || 
                string.IsNullOrEmpty(unidadeUniversitaria))
            {
                return new NotFoundResult();
            }

            var departamentos = _context.Departamentos
                .Include(m => m.SetorConhecimento)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria)
                .Include(m => m.Cursos)
                .OrderBy(m => m.Nome)
                .ToList();
                
            var item = departamentos.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                
            item.Cursos = item.Cursos.OrderBy(m => m.Nome).ToList();
                            
            if (item == null)
            {
                return new NotFoundResult();
            }
                        
            return new ObjectResult(item.ToDto());
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
                return new NotFoundResult();
            }

            var departamentos = _context.Departamentos
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var obj = departamentos.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);

            if (obj == null)
            {
                return new NotFoundResult();
            }
            return Ok();
        }        
    }
}