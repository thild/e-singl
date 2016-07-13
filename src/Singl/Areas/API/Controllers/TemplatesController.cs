using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Singl.Models;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class TemplatesController : Controller
    {
        private DatabaseContext _context;

        public TemplatesController(DatabaseContext context)
        {
            _context = context;
        }

        //[HttpGet()]
        [HttpGet("{*path}")]
        public IActionResult Get(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return NotFound();
            }

            var obj = _context.Templates
                .SingleOrDefault(m => m.Path == path);

            if (obj == null)
            {
                return NotFound();
            }
            return Content(obj.Html, "text/html");

        }

        [HttpPost]
        //[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Template template)
        {
            if (ModelState.IsValid)
            {
                //TODO: remover if quando a validação estiver correta
                if (!string.IsNullOrEmpty(template.Path))
                {
                    var original = _context.Templates.SingleOrDefault(m => m.Path == template.Path);
                    if (original == null)
                    {
                        _context.Templates.Add(template);

                    }
                    else
                    {
                        original.Path = template.Path;
                        original.Html = template.Html;
                    }
                    try
                    {
                        _context.SaveChanges();
                    }
                    catch (System.Exception)
                    {
                        return BadRequest(ModelState);
                    }
                    return Ok();
                }
            }

            // This will work in later versions of ASP.NET 5
            return BadRequest(ModelState);
        }
    }
}