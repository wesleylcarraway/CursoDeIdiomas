using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels.Aluno;

namespace CursoDeIdiomas.Application.Interfaces
{
    public interface IAlunoService
    {
        Task<IEnumerable<AlunoResponse>> GetAsync(AlunoParams queryParams = null);
        Task<AlunoResponse> GetByIdAsync(int id);
        Task<AlunoResponse> AddAsync(AlunoAddRequest alunoRequest);
        Task<AlunoResponse> UpdateAsync(AlunoUpdateRequest alunoRequest, int id);
        Task<AlunoResponse> RemoveAsync(int id);
        Task<int> CountAsync(AlunoParams queryParams);
    }
}
