using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Infra.Context;

namespace CursoDeIdiomas.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationContext _context { get; set; }
        public UnitOfWork(ApplicationContext Context)
        {
            _context = Context;
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
