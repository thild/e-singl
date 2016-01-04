using System.Linq;
using System.Threading.Tasks;
using Singl.Models;

namespace Singl.Services
{
    //Turma
    public class CampusService : ICampusService
    {

        private DatabaseContext _context;

        public CampusService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IQueryable<Campus>> GetAsync(string sigla)
        {
            return Task.FromResult(Get(sigla));
        }


        public Task<IQueryable<Campus>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public IQueryable<Campus> Get(string sigla)
        {
           return _context.Campi.Where(m => m.Sigla == sigla.ToUpper()).AsQueryable();
        }

        public IQueryable<Campus> GetAll()
        {
            return _context.Campi.AsQueryable();
        }
    }

    public interface ICampusService
    {
        Task<IQueryable<Campus>> GetAsync(string sigla);
        Task<IQueryable<Campus>> GetAllAsync();
        IQueryable<Campus> Get(string sigla);
        IQueryable<Campus> GetAll();
    }

}