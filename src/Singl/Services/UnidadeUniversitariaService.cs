using System.Linq;
using System.Threading.Tasks;
using Singl.Models;

namespace Singl.Services
{
    //Turma
    public class UnidadeUniversitariaService : IUnidadeUniversitariaService
    {

        private DatabaseContext _context;

        public UnidadeUniversitariaService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IQueryable<UnidadeUniversitaria>> GetAsync(string sigla)
        {
            return Task.FromResult(Get(sigla));
        }


        public Task<IQueryable<UnidadeUniversitaria>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public IQueryable<UnidadeUniversitaria> Get(string sigla)
        {
           return _context.UnidadesUniversitarias.Where(m => m.Sigla == sigla.ToUpper()).AsQueryable();
        }

        public IQueryable<UnidadeUniversitaria> GetAll()
        {
            return _context.UnidadesUniversitarias.AsQueryable();
        }
    }

    public interface IUnidadeUniversitariaService
    {
        Task<IQueryable<UnidadeUniversitaria>> GetAsync(string sigla);
        Task<IQueryable<UnidadeUniversitaria>> GetAllAsync();
        IQueryable<UnidadeUniversitaria> Get(string sigla);
        IQueryable<UnidadeUniversitaria> GetAll();
    }

}