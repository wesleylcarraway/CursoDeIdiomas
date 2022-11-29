namespace CursoDeIdiomas.Application.Interfaces
{
    public interface IMatriculaService
    {
        Task Register(int turmaId, int alunoId);
    }
}
