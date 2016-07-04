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
    public class SetoresAdministrativosController : Controller
    {
        private DatabaseContext _context;

        public SetoresAdministrativosController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<SetorAdministrativo> Get()
        {
            return _context.SetoresAdministrativos
                .Include(m => m.Campus)
                .OrderBy(m => m.Nome)
                .ToList();
        }

        [HttpGet("{sigla}/{campus}")]
        public IActionResult Get(string sigla, string campus)
        {

            if (string.IsNullOrEmpty(sigla) ||
                string.IsNullOrEmpty(campus))
            {
                return new NotFoundResult();
            }

            var setoresAdministrativos = _context.SetoresAdministrativos
                .Include(m => m.Subsetores)
                .Include(m => m.Campus).ToList();

            var setorAdministrativo = setoresAdministrativos.Single(m => m.Sigla == sigla &&
                m.Campus.Sigla == campus);

            if (setorAdministrativo == null)
            {
                return new NotFoundResult();
            }

            setorAdministrativo.Subsetores = setorAdministrativo.Subsetores.OrderBy(m => m.Nome).ToList();

            // var dto = new {SetorAdministrativo = SetorAdministrativo, 
            //     Campus = _context.Campi.Single(m => m.Id == SetorAdministrativo.CampusId)};

            return new ObjectResult(setorAdministrativo);
        }

        [HttpGet("{sigla}/{campus}/info")]
        public IActionResult Info(string sigla, string campus)
        {
            if (string.IsNullOrEmpty(sigla) ||
                           string.IsNullOrEmpty(campus))
            {
                return new NotFoundResult();
            }

            var setoresAdministrativos = _context.SetoresAdministrativos
                .Include(m => m.Subsetores)
                .Include(m => m.Campus).ToList();

            var model = setoresAdministrativos.Single(m => m.Sigla == sigla &&
                m.Campus.Sigla == campus);

            if (model == null)
            {
                return new NotFoundResult();
            }

            model.Subsetores = model.Subsetores.OrderBy(m => m.Nome).ToList();

            var dto = model.ToDto();
            dto.MetadataUI = _context.MetadataUI.SingleOrDefault(m => m.ModelId == model.Id);

            return new ObjectResult(dto);
        }

        [HttpPost]
        //[Authorize("CanEdit", "true")]
        public IActionResult Post([FromBody]SetorAdministrativo SetorAdministrativo)
        {
            if (ModelState.IsValid)
            {
                if (SetorAdministrativo.Id == Guid.Empty)
                {
                    _context.SetoresAdministrativos.Add(SetorAdministrativo);
                    _context.SaveChanges();
                    return new ObjectResult(SetorAdministrativo);
                }
                else
                {
                    var original = _context.SetoresAdministrativos.Single(m => m.Id == SetorAdministrativo.Id);
                    original.Nome = SetorAdministrativo.Nome;
                    original.Sigla = SetorAdministrativo.Sigla;
                    _context.SaveChanges();
                    return new ObjectResult(original);
                }
            }

            // This will work in later versions of ASP.NET 5
            return new BadRequestObjectResult(ModelState);
        }


        //[Authorize("CanEdit", "true")]
        [HttpDelete("{sigla}/{campus}")]
        public IActionResult Delete(string sigla, string campus)
        {
            if (string.IsNullOrEmpty(sigla) ||
                string.IsNullOrEmpty(campus))
            {
                return new NotFoundResult();
            }

            var SetoresAdministrativos = _context.SetoresAdministrativos
                .Include(m => m.Subsetores)
                .Include(m => m.Campus)
                .ToList();

            var obj = SetoresAdministrativos.Single(m => m.Sigla == sigla &&
                m.Campus.Sigla == campus);

            if (obj == null)
            {
                return new NotFoundResult();
            }
            return Ok();
        }
    }
}