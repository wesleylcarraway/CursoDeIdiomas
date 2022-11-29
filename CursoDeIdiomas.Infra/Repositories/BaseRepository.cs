using CursoDeIdiomas.Domain.Core;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CursoDeIdiomas.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Registro
    {
        protected readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;
        private IQueryable<T> _preQuery;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
            _preQuery = _dbSet.AsQueryable();
        }

        public virtual IQueryable<T> Query()
        {
            return _preQuery;
        }

        public virtual void AddPreQuery(Func<IQueryable<T>, IQueryable<T>> query)
        {
            _preQuery = query.Invoke(_preQuery);
        }

        protected virtual IQueryable<T> GetQueryable(
            int? skip = null,
            int? take = null,
            Expression<Func<T, bool>> filter = null,
            bool asNoTracking = true)
        {
            IQueryable<T> query = Query();
            if (filter is not null && filter.Parameters[0].Name != "f")
                query = query.Where(filter);

            if (asNoTracking)
                query = query.AsNoTracking();

            if (skip.HasValue)
                query = query.Skip((int)skip);

            if (take.HasValue)
                query = query.Take((int)take);

            return query;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CriadoEm = DateTime.Now;
            var query = _dbSet.Add(entity);
            return await Task.FromResult(query.Entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.AtualizadoEm = DateTime.Now;
            var query = _dbSet.Update(entity);
            return await Task.FromResult(query.Entity);
        }

        public async Task<T> DeleteAsync(int id)
        {
            var modelToBeRemoved = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (modelToBeRemoved == null)
                throw new InvalidOperationException($"Id: {id} to remove {typeof(T).Name} is invalid");

            var query = _dbSet.Remove(modelToBeRemoved);

            return await Task.FromResult(query.Entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            int? skip = null,
            int? take = null,
            Expression<Func<T, bool>> filter = null,
            bool asNoTracking = true)
        {
            return await GetQueryable(skip, take, filter, asNoTracking).ToListAsync();
        }

        public async Task<int> CountAsync(
            Expression<Func<T, bool>> filter = null,
            bool asNoTracking = true
        )
        {
            return (await GetQueryable(null, null, filter, asNoTracking).ToListAsync()).Count();
        }
    }
}
