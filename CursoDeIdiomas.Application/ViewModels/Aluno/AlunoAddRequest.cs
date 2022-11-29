using CursoDeIdiomas.Application.ViewModels.Turma;

namespace CursoDeIdiomas.Application.ViewModels.Aluno
{
    public class AlunoAddRequest : AlunoBaseRequest
    {
        public IEnumerable<int> IdDasTurmasParaCadastro { get; set; }
    }
}
