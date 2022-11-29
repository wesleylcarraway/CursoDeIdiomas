using CursoDeIdiomas.Domain.Core;
using CursoDeIdiomas.Domain.Models.Enums;

namespace CursoDeIdiomas.Domain.Models
{
    public class Turma : Registro
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public List<Aluno> Alunos { get; set; } = new List<Aluno>();
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}
