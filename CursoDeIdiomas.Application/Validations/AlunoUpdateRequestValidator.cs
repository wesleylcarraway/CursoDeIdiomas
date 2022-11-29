using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Domain.Interfaces;

namespace CursoDeIdiomas.Application.Validations
{
    public class AlunoUpdateRequestValidator : AlunoBaseRequestValidator<AlunoUpdateRequest>
    {
        private readonly ITurmaRepository _turmaRepository;
        public AlunoUpdateRequestValidator(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository) : base(alunoRepository, turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }
    }
}
