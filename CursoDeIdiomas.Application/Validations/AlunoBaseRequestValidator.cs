using CursoDeIdiomas.Application.Utils;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Domain.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Validations
{
    public class AlunoBaseRequestValidator<T> : AbstractValidator<T> where T : AlunoBaseRequest
    {
        private readonly ITurmaRepository _turmaRepository;
        public AlunoBaseRequestValidator(IAlunoRepository alunoRepository, ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;

            RuleFor(x => x.Cpf)
                .Must(x => ValidarCpf.IsCpf(x))
                .WithMessage("{PropertyName}: {PropertyValue} - CPF inválido.")
                .NotEmpty().WithMessage("Campo Obrigatório");

            RuleFor(x => x.Cpf)
                .MustAsync((cpf, cancelToken) => alunoRepository.Query().AsNoTracking().AllAsync(x => x.Cpf != cpf, cancelToken))
                .WithMessage("{PropertyName}: Já existe um aluno com este CPF.");

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty().WithMessage("Campo Obrigatório");

            RuleFor(x => x.Email)
                .MustAsync((email, cancelToken) => alunoRepository.Query().AsNoTracking().AllAsync(x => x.Email != email, cancelToken))
                .WithMessage("{PropertyName} Ja existe um aluno com este email.");

            RuleFor(x => x.Nome)
                .MinimumLength(3)
                .MaximumLength(100)
                .NotEmpty().WithMessage("Campo Obrigatório");
        }
    }
}
