using AutoMapper;
using CursoDeIdiomas.Application.Exceptions;
using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Infra.UnitOfWork;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITurmaRepository _turmaRepository;
        private readonly IValidator<AlunoAddRequest> _addValidator;
        private readonly IValidator<AlunoUpdateRequest> _updateValidator;

        public AlunoService(
            IAlunoRepository alunoRepository,
            IMapper mapper, IUnitOfWork unityOfWork,
            ITurmaRepository turmaRepository,
            IValidator<AlunoAddRequest> addValidator,
            IValidator<AlunoUpdateRequest> updateValidator
            )
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _unitOfWork = unityOfWork;
            _turmaRepository = turmaRepository;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
            _alunoRepository.AddPreQuery(x => x.Include(x => x.Turmas).ThenInclude(x => x.Curso));
            _turmaRepository.AddPreQuery(x => x.Include(x => x.Alunos));
            
        }

        public async Task<IEnumerable<AlunoResponse>> GetAsync(AlunoParams queryParams)
        {
            return _mapper.Map<IEnumerable<AlunoResponse>>(await _alunoRepository.GetAllAsync(queryParams.Skip, queryParams.Take, queryParams.Filter()));
        }

        public async Task<AlunoResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<AlunoResponse>(await _alunoRepository.GetByIdAsync(id));
        }

        public async Task<AlunoResponse> AddAsync(AlunoAddRequest alunoRequest)
        {
            var validation = await _addValidator.ValidateAsync(alunoRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            var aluno = _mapper.Map<Aluno>(alunoRequest);
      
            await _alunoRepository.AddAsync(aluno);
            
            await _unitOfWork.CommitAsync();

            await SeRegistrarEmUmaTurma(alunoRequest.IdDasTurmasParaCadastro, aluno.Id);
            return _mapper.Map<AlunoResponse>(aluno);
        }

        public async Task<AlunoResponse> UpdateAsync(AlunoUpdateRequest alunoRequest, int id)
        {
            var existing = await _alunoRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Aluno com id: {id} não existe! ");   

            _alunoRepository.AddPreQuery(x => x.Where(c => c.Id != id));
            var validation = await _updateValidator.ValidateAsync(alunoRequest);
            if (!validation.IsValid)
                throw new BadRequestException(validation);

            _mapper.Map<AlunoUpdateRequest, Aluno>(alunoRequest, existing);
            await _alunoRepository.UpdateAsync(existing);
            await _unitOfWork.CommitAsync();
      
            return _mapper.Map<AlunoResponse>(existing);
        }

        public async Task<AlunoResponse> RemoveAsync(int id)
        {
            var existing = await _alunoRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Aluno com id: {id} não existe! ");

            await _alunoRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<AlunoResponse>(existing);
        }

        public async Task<int> CountAsync(AlunoParams queryParams)
        {
            return await _alunoRepository.CountAsync(queryParams.Filter());
        }

        private async Task SeRegistrarEmUmaTurma(IEnumerable<int> IdDasTurmasParaCadastro, int alunoId)
        {
            var aluno = await _alunoRepository.GetByIdAsync(alunoId);

            foreach (int id in IdDasTurmasParaCadastro)
            {
                var turma = await _turmaRepository.GetByIdAsync(id);
                if (turma is null)
                    throw new NotFoundException("O id informado não existe!");

                if (turma.Alunos.Count() < 5)
                {
                    aluno.Turmas.Add(turma);
                    turma.Alunos.Add(aluno);
                }
                else 
                    throw new Exception($"Uma turma não pode ter mais de 5 alunos.");
            }
           
            await _unitOfWork.CommitAsync();
        }
    }
}
