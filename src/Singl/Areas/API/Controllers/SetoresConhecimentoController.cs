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
    public class SetoresConhecimentoController : Controller
    {
        private DatabaseContext _context;

        public SetoresConhecimentoController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SetorConhecimento> Get()
        {
            return _context.SetoresConhecimento
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

            var setoresConhecimento = _context.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var setorConhecimento = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);
                                
            if (setorConhecimento == null)
            {
                return new HttpNotFoundResult();
            }
            
            setorConhecimento.Departamentos = setorConhecimento.Departamentos.OrderBy(m => m.Nome).ToList();
            
            // var dto = new {SetorConhecimento = setorConhecimento, 
            //     UnidadeUniversitaria = 
            //     _context.UnidadesUniversitarias.Single(m => m.Id == 
            //         setorConhecimento.Campus.UnidadeUniversitariaId)};
            return new ObjectResult(setorConhecimento);
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]SetorConhecimento setorConhecimento)
        {
			if (ModelState.IsValid)
			{
				if (setorConhecimento.Id == Guid.Empty)
				{
					_context.SetoresConhecimento.Add(setorConhecimento);
					_context.SaveChanges();
					return new ObjectResult(setorConhecimento);
				}
				else
				{
					var original = _context.SetoresConhecimento.Single(m => m.Id == setorConhecimento.Id);
					original.Nome = setorConhecimento.Nome;
					original.Sigla = setorConhecimento.Sigla;
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

            var setoresConhecimento = _context.SetoresConhecimento
                .Include(m => m.Departamentos)
                .Include(m => m.Campus)
                .ThenInclude(m => m.UnidadeUniversitaria).ToList();
                
            var obj = setoresConhecimento.Single(m => m.Sigla == sigla && 
                m.Campus.UnidadeUniversitaria.Sigla == unidadeUniversitaria);

            if (obj == null)
            {
                return new HttpNotFoundResult();
            }
            return new HttpOkResult();
        }        
    }
}