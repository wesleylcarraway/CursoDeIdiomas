using CursoDeIdiomas.Domain.Core;
using System.Linq.Expressions;

namespace CursoDeIdiomas.Application.Params
{
    public abstract class BaseParams<T> where T : Registro
    {
        public int Take { get; set; } = 10;
        public int Skip { get; set; } = 0;
        public abstract Expression<Func<T, bool>> Filter();
        protected BaseParams() { }
    }
}
