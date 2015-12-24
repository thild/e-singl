using System.Linq;
using System.Threading.Tasks;
using Singl.Models;

namespace Singl.Services
{
    //Turma
    public class SetorConhecimentoService : ISetorConhecimentoService
    {

        private DatabaseContext _context;

        public SetorConhecimentoService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IQueryable<SetorConhecimento>> GetAsync(string sigla)
        {
            return Task.FromResult(Get(sigla));
        }


        public Task<IQueryable<SetorConhecimento>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public IQueryable<SetorConhecimento> Get(string sigla)
        {
           return _context.SetoresConhecimento.Where(m => m.Sigla == sigla.ToUpper()).AsQueryable();
        }

        public IQueryable<SetorConhecimento> GetAll()
        {
            return _context.SetoresConhecimento.AsQueryable();
        }
    }

    public interface ISetorConhecimentoService
    {
        Task<IQueryable<SetorConhecimento>> GetAsync(string sigla);
        Task<IQueryable<SetorConhecimento>> GetAllAsync();
        IQueryable<SetorConhecimento> Get(string sigla);
        IQueryable<SetorConhecimento> GetAll();
    }

}