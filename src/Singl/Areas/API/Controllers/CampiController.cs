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
    public class CampiController : Controller
    {
        private DatabaseContext _context;

        public CampiController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Campus> Get()
        {
            System.Console.WriteLine("Get()");
            return _context.Campi
                .Include(m => m.SetoresConhecimento)
                .Include(m => m.SetoresAdministrativos)
                .OrderBy(m => m.Nome)
                .ToList();
        }
 
        [HttpGet("{sigla}")]
        public IActionResult Get(string sigla)
        {
            
            if (string.IsNullOrEmpty(sigla))
            {
                return new HttpStatusCodeResult(404);
            }

            var campus = _context.Campi
                .Include(m => m.SetoresConhecimento)
                .Include(m => m.SetoresAdministrativos)
                .ThenInclude(m => m.SuperSetor)
                .Single(m => m.Sigla == sigla.ToUpper());
                
            campus.SetoresConhecimento = campus.SetoresConhecimento.OrderBy(m => m.Nome).ToList();
            
            var dto = new {Campus = campus, 
                UnidadeUniversitaria = 
                _context.UnidadesUniversitarias.Single(m => m.Id == 
                    campus.UnidadeUniversitariaId)};
            
                
            if (campus == null)
            {
                return new HttpNotFoundResult();
            }
                        
            return new ObjectResult(dto);
		} 
        
        [HttpPost]
		//[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Campus campus)
        {
			if (ModelState.IsValid)
			{
				if (campus.Id == Guid.Empty)
				{
					_context.Campi.Add(campus);
					_context.SaveChanges();
					return new ObjectResult(campus);
				}
				else
				{
					var original = _context.Campi.Single(m => m.Id == campus.Id);
					original.Nome = campus.Nome;
					original.Sigla = campus.Sigla;
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
                return new HttpNotFoundResult();
            }
            var obj = _context.Campi.Single(m => m.Sigla == sigla.ToUpper());
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }            
            _context.Campi.Remove(obj);
            _context.SaveChanges();
            return new HttpOkResult();
        }        
    }
}