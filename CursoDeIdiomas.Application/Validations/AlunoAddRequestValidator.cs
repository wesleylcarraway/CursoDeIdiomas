using CursoDeIdiomas.Application.Utils;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Domain.Interfaces;
using FluentValidation;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Validations
{
    public class AlunoAddRequestValidator : AlunoBaseRequestValidator<AlunoAddRequest>
    {
        private readonly ITurmaRepository _turmaRepository;
        public AlunoAddRequestValidator(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository) : base(alunoRepository, turmaRepository)
        {
            _turmaRepository = turmaRepository;

            RuleFor(x => x.IdDasTurmasParaCadastro)
                .MustAsync((ids, cancelToken) => VerificarSeTurmaExiste(ids, cancelToken))
                .WithMessage("Pelo menos uma das turmas especificadas não existe.");           
        }
        private async Task<bool> VerificarSeTurmaExiste(IEnumerable<int> idsDasTurmas, CancellationToken cancellationToken = default)
        {
            var turmas = await _turmaRepository
                .Query().ToListAsync();

            return idsDasTurmas.All(x => turmas.Any(t => t.Id == x));
        }
    }
}
