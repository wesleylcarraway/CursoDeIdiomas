namespace CursoDeIdiomas.Application.ViewModels.Aluno
{
    public abstract class AlunoBaseRequest
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
    }
}
