using System.Linq;
using Microsoft.AspNet.Mvc;
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
        [HttpGet("{routeName}")]
        public IActionResult Get(string routeName)
        {

            if (string.IsNullOrEmpty(routeName))
            {
                return new HttpNotFoundResult();
            }

            var obj = _context.Templates
                .SingleOrDefault(m => m.Name == routeName);

            if (obj == null)
            {
                //return new HttpNotFoundResult();
            }
            else
            {
                return Content(obj.Html, "text/html"); ;
            }

            var html = "";
            switch (routeName)
            {
                case "NEADEnsino":
                    html = @"<h1>
                        Cursos | Materiais Didáticos | Bibliotecas | Área do Professor | Área do Aluno
                    </h1>";
                    break;
                case "NEADPesquisa":
                    html = "<h1>Pesquisa</h1>";
                    break;
                case "NEADExtensao":
                    html = "<h1>Extensão</h1>";
                    break;
                case "NEADAdministrativo":
                    html = "<h1>Administrativo</h1>";
                    break;
            }
            return Content(html, "text/html"); ;
        }

        [HttpPost]
        //[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]Template template)
        {
            if (ModelState.IsValid)
            {
                //TODO: remover if quando a validação estiver correta
                if (!string.IsNullOrEmpty(template.Name))
                {
                    var original = _context.Templates.SingleOrDefault(m => m.Name == template.Name);
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
                        //System.Console.WriteLine(ex);
                        return new BadRequestObjectResult(ModelState);
                    }
                    return new ObjectResult(template);
                }
            }

            // This will work in later versions of ASP.NET 5
            return new BadRequestObjectResult(ModelState);
        }
    }
}