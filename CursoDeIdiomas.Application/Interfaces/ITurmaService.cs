using CursoDeIdiomas.Application.Params;
using CursoDeIdiomas.Application.ViewModels.Turma;

namespace CursoDeIdiomas.Application.Interfaces
{
    public interface ITurmaService
    {
        Task<IEnumerable<TurmaResponse>> GetAsync(TurmaParams queryParams = null);
        Task<TurmaResponse> GetByIdAsync(int id);
        Task<TurmaResponse> AddAsync(TurmaRequest turmaRequest);
        Task<TurmaResponse> UpdateAsync(TurmaRequest turmaRequest, int id);
        Task<TurmaResponse> RemoveAsync(int id);
        Task<int> CountAsync(TurmaParams queryParams);
    }
}
