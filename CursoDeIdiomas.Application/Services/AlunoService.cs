using AutoMapper;
using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Application.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unityOfWork;

        public AlunoService(IAlunoRepository alunoRepository, IMapper mapper, IUnitOfWork unityOfWork)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;

            _alunoRepository.AddPreQuery(x => x.Include(x => x.Turmas).ThenInclude(x => x.Curso));
        }

        public async Task<IEnumerable<AlunoResponse>> GetAsync(AlunoParams queryParams)
        {
            return _mapper.Map<IEnumerable<AlunoResponse>>(await _alunoRepository.GetAllAsync(queryParams.Skip, queryParams.Take, queryParams.Filter()));
        }

        public async Task<AlunoResponse> GetByIdAsync(int id)
        {
            return _mapper.Map<AlunoResponse>(await _alunoRepository.GetByIdAsync(id));
        }

        public async Task<AlunoResponse> AddAsync(AlunoRequest alunoRequest)
        {
            //var validation = await _validator.ValidateAsync(contactRequest);
            //if (!validation.IsValid)
                //throw new BadRequestException(validation);

            var aluno = _mapper.Map<Aluno>(alunoRequest);
           
            await _alunoRepository.AddAsync(aluno);
            
            await _unityOfWork.CommitAsync();
            return _mapper.Map<AlunoResponse>(aluno);
        }

        public async Task<AlunoResponse> UpdateAsync(AlunoRequest alunoRequest, int id)
        {
            var existing = await _alunoRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Aluno com id: {id} não existe! ");   

            _alunoRepository.AddPreQuery(x => x.Where(c => c.Id != id));
            //var validation = await _validator.ValidateAsync(alunoRequest);
            //if (!validation.IsValid)
                //throw new BadRequestException(validation);

            _mapper.Map<AlunoRequest, Aluno>(alunoRequest, existing);
            await _alunoRepository.UpdateAsync(existing);
            await _unityOfWork.CommitAsync();
            return _mapper.Map<AlunoResponse>(existing);
        }

        public async Task<AlunoResponse> RemoveAsync(int id)
        {
            var existing = await _alunoRepository.GetByIdAsync(id);
            if (existing is null)
                throw new Exception($"Aluno com id: {id} não existe! ");

            await _alunoRepository.DeleteAsync(id);
            await _unityOfWork.CommitAsync();
            return _mapper.Map<AlunoResponse>(existing);
        }

        public async Task<int> CountAsync(AlunoParams queryParams)
        {
            return await _alunoRepository.CountAsync(queryParams.Filter());
        }
    }
}
