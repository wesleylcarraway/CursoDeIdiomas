using CursoDeIdiomas.Application.ViewModels.Aluno;
using CursoDeIdiomas.Application.ViewModels.Curso;
using CursoDeIdiomas.Domain.Core;
using CursoDeIdiomas.Domain.Models.Enums;

namespace CursoDeIdiomas.Application.ViewModels.Turma
{
    public class TurmaResponse : Registro
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public IEnumerable<AlunoResponse> Alunos { get; set; }
        public CursoResponse Curso { get; set; }
        public int CursoId { get; set; }
    }
}
