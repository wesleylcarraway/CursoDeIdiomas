using CursoDeIdiomas.Application.ViewModels.Turma;
using CursoDeIdiomas.Domain.Core;

namespace CursoDeIdiomas.Application.ViewModels.Aluno
{
    public class AlunoResponse : Registro
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public IEnumerable<TurmaResponse> Turmas { get; set; }
    }
}
