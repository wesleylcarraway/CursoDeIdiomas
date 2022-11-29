using CursoDeIdiomas.Application.ViewModels.Curso;

namespace CursoDeIdiomas.Application.ViewModels.Turma
{
    public class TurmaMinimalResponse
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int CursoId { get; set; }
        public CursoResponse Curso { get; set; }
    }
}
