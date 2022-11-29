using CursoDeIdiomas.Application.ViewModels.Turma;
using CursoDeIdiomas.Domain.Core;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models.Enums;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Validations
{
    public class TurmaRequestValidator : AbstractValidator<TurmaRequest>
    {
        private readonly ITurmaRepository _turmaRepository;
        public TurmaRequestValidator(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;

            RuleFor(x => x.AnoLetivo)
                .NotEmpty().WithMessage("Campo Obrigatório");           

            RuleFor(x => x.CursoId)
                .Must(type => Enumeration.GetAll<Curso>().Any(x => x.Id == type))
                .WithMessage("{PropertyName} Curso inválido.");

            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("Campo Obrigatório");

            RuleFor(x => x.Numero)
                .MustAsync((numero, cancelToken) => turmaRepository.Query().AsNoTracking().AllAsync(x => x.Numero != numero, cancelToken))
                .WithMessage("{PropertyName}: Já existe uma turma com este número.");
        }
    }
}
