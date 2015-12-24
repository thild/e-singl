using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Singl.Models;

namespace Singl.Services
{
    //Turma
    public class SetorAdministrativoService : ISetorAdministrativoService
    {

        private DatabaseContext _context;

        public SetorAdministrativoService(DatabaseContext context)
        {
            _context = context;
        }

        public Task<IQueryable<SetorAdministrativo>> GetAsync(Guid? superSetorId)
        {
            return Task.FromResult(Get(superSetorId));
        }


        public Task<IQueryable<SetorAdministrativo>> GetAllAsync()
        {
            return Task.FromResult(GetAll());
        }

        public IQueryable<SetorAdministrativo> Get(Guid? superSetorId)
        {
           return _context.SetoresAdministrativos.Where(m => m.SuperSetorId == superSetorId).AsQueryable();
        }

        public IQueryable<SetorAdministrativo> GetAll()
        {
            return _context.SetoresAdministrativos.AsQueryable();
        }
        
        public IQueryable<SetorAdministrativo> GetAllButMeAndChilds(Guid? me)
        {
            return _context.SetoresAdministrativos.Where(m => m.Id != me && m.SuperSetorId != me).AsQueryable();
        }        
    }

    public interface ISetorAdministrativoService
    {
        Task<IQueryable<SetorAdministrativo>> GetAsync(Guid? superSetorId);
        Task<IQueryable<SetorAdministrativo>> GetAllAsync();
        IQueryable<SetorAdministrativo> Get(Guid? superSetorId);
        IQueryable<SetorAdministrativo> GetAll();
        IQueryable<SetorAdministrativo> GetAllButMeAndChilds(Guid? me);
    }

}