using CursoDeIdiomas.Application.ViewModels.Aluno;

namespace CursoDeIdiomas.Application.ViewModels.Turma
{
    public class TurmaRequest
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int CursoId { get; set; }
    }
}
