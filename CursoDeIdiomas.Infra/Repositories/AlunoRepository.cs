using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Infra.Context;

namespace CursoDeIdiomas.Infra.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
