using CursoDeIdiomas.Domain.Models;
using LinqKit;
using System.Linq.Expressions;

namespace CursoDeIdiomas.Application.Params
{
    public class AlunoParams : BaseParams<Aluno>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public override Expression<Func<Aluno, bool>> Filter()
        {
            return FilterContact();
        }
        protected ExpressionStarter<Aluno> FilterContact()
        {
            var predicate = PredicateBuilder.New<Aluno>();

            if (!string.IsNullOrEmpty(Nome))
                predicate = predicate.And(x => x.Nome.Contains(Nome));

            if (!string.IsNullOrEmpty(Cpf))
                predicate = predicate.And(x => x.Nome.Contains(Cpf));

            if (!string.IsNullOrEmpty(Email))
                predicate = predicate.And(x => x.Nome.Contains(Email));

            return predicate;
        }
    }
}
