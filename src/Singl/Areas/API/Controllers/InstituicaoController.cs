using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Singl.Areas.API.Controllers
{
    [Area("API")]
    [Route("[area]/[controller]")]
    public class InstituicaoController : Controller
    {
        private DatabaseContext _context;

        public InstituicaoController(DatabaseContext context)
        {
            _context = context;    
        }

        [HttpGet()]
        public IActionResult Get()
        {
            return new ObjectResult(_context.Instituicao.Single());
        }

        [HttpGet("info")]
        public IActionResult Info()
        {

              var instituicao = _context.Instituicao.FirstOrDefault();
                
            if (instituicao == null)
            {
                return new NotFoundResult();
            }

            var dto = instituicao.ToDto();
            dto.MetadataUI = _context.MetadataUI.SingleOrDefault(m => m.ModelId == instituicao.Id);

            return new ObjectResult(dto);
        }        
        

//         // GET: Instituicao/Edit/5
//         public IActionResult Edit()
//         {
// 
//             Instituicao instituicao = _context.Instituicao.Single();
//             if (instituicao == null)
//             {
//                 return NotFound();
//             }
//             return View(instituicao);
//         }
// 
//         // POST: Instituicao/Edit/5
//         [HttpPost]
//         [ValidateAntiForgeryToken]
//         public IActionResult Edit(Instituicao instituicao)
//         {
//             if (ModelState.IsValid)
//             {
//                 _context.Update(instituicao);
//                 _context.SaveChanges();
//                 return RedirectToAction("Index");
//             }
//             return View(instituicao);
//         }
    }
}
