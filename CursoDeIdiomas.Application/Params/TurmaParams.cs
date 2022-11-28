using CursoDeIdiomas.Domain.Models;
using LinqKit;
using System.Linq.Expressions;

namespace CursoDeIdiomas.Application.Params
{
    public class TurmaParams : BaseParams<Turma>
    {
        public int? Numero{ get; set; }

        public override Expression<Func<Turma, bool>> Filter()
        {
            return FilterContact();
        }
        protected ExpressionStarter<Turma> FilterContact()
        {
            var predicate = PredicateBuilder.New<Turma>();

            if (Numero.HasValue)
                predicate = predicate.And(x => x.Numero == Numero);

            return predicate;
        }
    }
}
