using CursoDeIdiomas.Domain.Core;
using System.Linq.Expressions;

namespace CursoDeIdiomas.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : Registro
    {
        IQueryable<T> Query();
        void AddPreQuery(Func<IQueryable<T>, IQueryable<T>> query);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(
            int? skip = null,
            int? take = null, Expression<Func<T, bool>> filter = null, bool asNoTracking = true);
        Task<T> GetByIdAsync(int id);
        Task<int> CountAsync(Expression<Func<T, bool>> filter = null,
            bool asNoTracking = true);
    }
}
