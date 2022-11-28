﻿using AutoMapper;
using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels.Turma;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _turmaRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unityOfWork;

        public TurmaService(ITurmaRepository turmaRepository, IMapper mapper, IUnitOfWork unityOfWork)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;

            _turmaRepository.AddPreQuery(x => x.Include(x => x.Alunos));
        }

        public async Task<IEnumerable<TurmaResponse>> GetAsync(TurmaParams queryParams)
        {
            return _mapper.Map<IEnumerable<TurmaResponse>>(await _turmaRepository.GetAllAsync(queryParams.Skip, queryParams.Take, queryParams.Filter()));
        }

        public async Task<TurmaResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<TurmaResponse>(await _turmaRepository.GetByIdAsync(id));
        }

        public async Task<TurmaResponse> AddAsync(TurmaRequest turmaRequest)
        {
            //var validation = await _validator.ValidateAsync(contactRequest);
            //if (!validation.IsValid)
            //throw new BadRequestException(validation);

            var turma = _mapper.Map<Turma>(turmaRequest);

            await _turmaRepository.AddAsync(turma);

            await _unityOfWork.CommitAsync();
            return _mapper.Map<TurmaResponse>(turma);
        }

        public async Task<TurmaResponse> UpdateAsync(TurmaRequest turmaRequest, int id)
        {
            var existing = await _turmaRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Turma com id: {id} não existe! ");

            _turmaRepository.AddPreQuery(x => x.Where(c => c.Id != id));
            //var validation = await _validator.ValidateAsync(alunoRequest);
            //if (!validation.IsValid)
            //throw new BadRequestException(validation);

            _mapper.Map<TurmaRequest, Turma>(turmaRequest, existing);
            await _turmaRepository.UpdateAsync(existing);
            await _unityOfWork.CommitAsync();
            return _mapper.Map<TurmaResponse>(existing);
        }

        public async Task<TurmaResponse> RemoveAsync(int id)
        {
            var existing = await _turmaRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Turma com id: {id} não existe! ");

            await _turmaRepository.DeleteAsync(id);
            await _unityOfWork.CommitAsync();
            return _mapper.Map<TurmaResponse>(existing);
        }

        public async Task<int> CountAsync(TurmaParams queryParams)
        {
            return await _turmaRepository.CountAsync(queryParams.Filter());
        }
    }
}
