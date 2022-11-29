using AutoMapper;
using CursoDeIdiomas.Application.Exceptions;
using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Services
{
    public class MatriculaService : IMatriculaService
    {
        public readonly IMatriculaRepository _matriculaRepository;
        public readonly ITurmaRepository _turmaRepository;

        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }

        public MatriculaService(
            IMatriculaRepository matriculaRepository,
            ITurmaRepository turmaRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
            )
        {
            _matriculaRepository = matriculaRepository;
            _turmaRepository = turmaRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

            _turmaRepository.AddPreQuery(x => x.Include(x => x.Alunos));
        }

        public async Task Register(int turmaId, int alunoId)
        {
            var turma = await _turmaRepository.GetByIdAsync(turmaId);
            if (turma is null)
                throw new NotFoundException("Turma não encontrada.");

            if(turma.Alunos.Any(x => x.Id == alunoId))
                throw new Exception($"Este aluno ja está matriculado nesta turma.");

            if (turma.Alunos.Count() < 5)
            {
                var matricula = new Matricula
                {
                    TurmaId = turmaId,
                    AlunoId = alunoId
                };

                await _matriculaRepository.AddAsync(matricula);
                await _unitOfWork.CommitAsync();
            }
            else
                throw new Exception($"Uma turma não pode ter mais de 5 alunos.");      
        }
    }
}
