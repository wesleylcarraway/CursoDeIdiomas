using CursoDeIdiomas.Domain.Core;

namespace CursoDeIdiomas.Domain.Models
{
    public class Matricula : Registro
    {
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Turma Turma { get; set; }
        public int TurmaId { get; set; }
        public int Numero { get; set; }
    }
}
