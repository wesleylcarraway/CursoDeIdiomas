namespace CursoDeIdiomas.Application.ViewModels.Turma
{
    public class TurmaSemCadastroDeAlunosRequest
    {
        public int Numero { get; set; }
        public DateTime AnoLetivo { get; set; }
        public int CursoId { get; set; }
    }
}
