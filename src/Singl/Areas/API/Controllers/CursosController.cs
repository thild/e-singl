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
        
        [HttpGet("{codigo}/info")]
        public IActionResult Info(string codigo)
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
                
            if (curso == null)
            {
                return new HttpNotFoundResult();
            }
            //TODO: Gambiarra master. Descobrir porque o Theninclude (Pessoa) não é retornado em 1 
            var docentesCurso = _context.DocentesCurso
                .Include(m => m.Docente)
                .ThenInclude(m => m.Pessoa)
                .Where(m => m.CursoId == curso.Id).Select(m => new {m.Docente, m.Docente.Pessoa});

            // 1    
            curso.Docentes = docentesCurso
                .Select(m => m.Docente)
                .OrderBy(m => m.Pessoa.Nome)
                .ToList();
                
            foreach (var item in curso.Docentes)
            {
                item.Pessoa = docentesCurso.Where(m => m.Docente.Id == item.Id).Select(m => m.Pessoa).Single();
            }                

            curso.Curriculo.Disciplinas = 
                curso.Curriculo.Disciplinas
                    .OrderBy(m => m.Serie)
                    .ThenBy(m => m.Semestre)
                    .ThenBy(m => m.Ordem)
                    .ThenBy(m => m.Nome)
                    .ToList();
                    
            curso.Polos = _context.PolosCurso
                .Where(m => m.CursoId == curso.Id)
                .Select(m => m.Polo)
                .OrderBy(m => m.Nome)
                .ToList();
                
            curso.Vinculos = _context.VinculosCurso
                .Include(m => m.Papel)
                .Where(m => m.CursoId == curso.Id && m.Fim == DateTimeOffset.MaxValue)
                .Select( m =>
                    new VinculoCurso {
                        CursoId = m.CursoId,
                        Curso = m.Curso,
                        Fim = m.Fim,
                        Inicio = m.Inicio,
                        PapelId = m.PapelId,
                        Papel = m.Papel,   
                        PessoaId = m.PessoaId,
                        Pessoa = m.Pessoa   
                    }
                    )
                    .OrderBy(m => m.Papel.Categoria)
                    .ThenBy(m => m.Papel.Ordem)
                    .ToList();

            var dto = curso.ToDto();
            dto.MetadataUI = _context.MetadataUI.SingleOrDefault(m => m.ModelId == curso.Id);

            return new ObjectResult(dto);
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