using CursoDeIdiomas.Application.ViewModels.Turma;

namespace CursoDeIdiomas.Application.ViewModels.Aluno
{
    public class AlunoRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public IEnumerable<TurmaSemCadastroDeAlunosRequest> Turmas { get; set; }
    }
}
