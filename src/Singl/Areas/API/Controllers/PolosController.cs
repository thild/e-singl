using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Singl.Extensions;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class PolosController : Controller
    {
        private DatabaseContext _context;

        public PolosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var list = _context.Polos
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

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            if (id == Guid.Empty)
            {
                return new HttpNotFoundResult();
            }

            var polo = _context.Polos
                .Single(m => m.Id == id);

            if (polo == null)
            {
                return new HttpNotFoundResult();
            }

            return new ObjectResult(polo.ToDto());
        }

        [HttpGet("{id}/info")]
        public IActionResult Info(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpNotFoundResult();
            }

            var polo = _context.Polos
              .Single(m => m.Id == id);

            if (polo == null)
            {
                return new HttpNotFoundResult();
            }
            
            polo.Cursos = _context.PolosCurso
                .Where(m => m.PoloId == polo.Id)
                .Select(m => m.Curso)
                .OrderBy(m => m.Nome)
                .ToList();            

            var dto = polo.ToDto();
            dto.MetadataUI = _context
                .MetadataUI
                .SingleOrDefault(m => m.ModelId == polo.Id);

            return new ObjectResult(dto);
        }

        [HttpPost]
        //[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Polo polo)
        {
            if (ModelState.IsValid)
            {
                if (polo.Id == Guid.Empty)
                {
                    _context.Polos.Add(polo);
                    _context.SaveChanges();
                    return new ObjectResult(polo);
                }
                else
                {
                    var original = _context.Polos.Single(m => m.Id == polo.Id);
                    original.Fill(polo);
                    _context.SaveChanges();
                    return new ObjectResult(original);
                }
            }

            // This will work in later versions of ASP.NET 5
            return new BadRequestObjectResult(ModelState);
        }


        //[Authorize("CanEdit", "true")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new HttpNotFoundResult();
            }
            var obj = _context.Polos.Single(m => m.Id == id);
            if (obj == null)
            {
                return new HttpNotFoundResult();
            }
            _context.Polos.Remove(obj);
            _context.SaveChanges();
            return new HttpOkResult();
        }
    }
}