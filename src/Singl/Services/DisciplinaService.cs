using System;
using System.Linq;
using System.Threading.Tasks;
using Singl.Models;

namespace Singl.Services
{
    //Turma
    public class DisciplinaService : IDisciplinaService
    {
        
        private DatabaseContext _context;

        public DisciplinaService(DatabaseContext context)
        {
            _context = context;    
        }
        
        public Task<Disciplina[]> GetDisciplinas(Guid curriculoId)
            {
                var disciplinas = _context.Disciplinas.Where(m => m.CurriculoId == curriculoId).ToArray();
                return Task.FromResult(disciplinas);
            }        
        
     
    }
    
    public interface IDisciplinaService 
    {
        Task<Disciplina[]> GetDisciplinas(Guid curriculoId);
    }
    
}