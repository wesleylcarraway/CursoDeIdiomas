using CursoDeIdiomas.Domain.Core;

namespace CursoDeIdiomas.Domain.Models
{
    public class Aluno : Registro
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public List<Turma> Turmas { get; set; } = new List<Turma>();
    }
}
