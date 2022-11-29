using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Application.ViewModels.Curso;
using CursoDeIdiomas.Domain.Core;

namespace CursoDeIdiomas.Application.ViewModels.Turma
{
    public class TurmaResponse : Registro
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public List<AlunoMinimalResponse> Alunos { get; set; }
        public CursoResponse Curso { get; set; }
        public int CursoId { get; set; }
    }
}
