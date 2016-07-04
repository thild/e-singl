using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Singl.Extensions;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class CidadesController : Controller
    {
        private DatabaseContext _context;

        public CidadesController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<dynamic> Get()
        {
            var list = _context.Cidades
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
                return new NotFoundResult();
            }

            var Cidade = _context.Cidades
                .Single(m => m.Id == id);

            if (Cidade == null)
            {
                return new NotFoundResult();
            }

            return new ObjectResult(Cidade.ToDto());
        }

        [HttpGet("{id}/info")]
        public IActionResult Info(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new NotFoundResult();
            }

            var cidade = _context.Cidades
              .Single(m => m.Id == id);

            if (cidade == null)
            {
                return new NotFoundResult();
            }
            
            var dto = cidade.ToDto();
            dto.MetadataUI = _context
                .MetadataUI
                .SingleOrDefault(m => m.ModelId == cidade.Id);

            return new ObjectResult(dto);
        }

        [HttpPost]
        //[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Cidade cidade)
        {
            System.Console.WriteLine("Cidade");
            if (ModelState.IsValid)
            {
                if (cidade.Id == Guid.Empty)
                {
                    _context.Cidades.Add(cidade);
                    _context.SaveChanges();
                    return new ObjectResult(cidade);
                }
                else
                {
                    var original = _context.Cidades.Single(m => m.Id == cidade.Id);
                    original.Fill(cidade);
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
                return new NotFoundResult();
            }
            var obj = _context.Cidades.Single(m => m.Id == id);
            if (obj == null)
            {
                return new NotFoundResult();
            }
            _context.Cidades.Remove(obj);
            _context.SaveChanges();
            return Ok();
        }
    }
}